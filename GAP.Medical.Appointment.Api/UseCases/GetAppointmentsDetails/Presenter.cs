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
            ViewModel = new NoContentResult();
        }

        public void Handle(Output output)
        {

            List<AppointmentModel> appointmens = new List<AppointmentModel>();

            foreach (var item in output.Appointments)
            {
                MedicalSpecialityModel medialModel = new MedicalSpecialityModel(
                                       item.MedicalSpeciality.Id,
                                       item.MedicalSpeciality.Name
                                     );
                appointmens.Add(new AppointmentModel(item.Id, item.PatientId, item.MedicalSpecialityId, item.AssignedDate, medialModel));
            }

            PatientModel patientModel = new PatientModel(output.Patient.Id, output.Patient.DocumentId, output.Patient.Name, output.Patient.LastName, output.Patient.PhoneNumber, output.Patient.Email);

            PatientApointmentModel newProfile = new PatientApointmentModel(patientModel,
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
