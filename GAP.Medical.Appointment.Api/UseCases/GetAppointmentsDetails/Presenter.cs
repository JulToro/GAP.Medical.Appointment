using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetAppoinments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails
{
    public class Presenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(new { message = $"{message}:", currentDate = DateTime.Now });
        }

        public void Handle(Output output)
        {

            List<AppointmentModel> appointmens = new List<AppointmentModel>();

            foreach (var item in output.Appointments)
            {
                MedicalSpecialtyModel medialModel = new MedicalSpecialtyModel(
                                       item.MedicalSpecialty.Id,
                                       item.MedicalSpecialty.Name
                                     );
                appointmens.Add(new AppointmentModel(item.Id, item.PatientId, item.MedicalSpecialtyId, item.AssignedDate, medialModel));
            }

            PatientModel patientModel = new PatientModel(output.Patient.Id, output.Patient.DocumentId, output.Patient.Name, output.Patient.LastName, output.Patient.PhoneNumber, output.Patient.Email);

            PatientAppointmentModel newProfile = new PatientAppointmentModel(patientModel,
                                                                            appointmens  );

            ViewModel = new CreatedAtRouteResult("GetAppointment",
                new
                {
                    patientId = newProfile.Patient.Id
                },
                newProfile);
        }
    }
}
