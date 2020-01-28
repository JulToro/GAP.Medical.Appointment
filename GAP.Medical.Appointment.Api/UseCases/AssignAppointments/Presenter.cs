using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.AssignAppointments
{
    public class Presenter: IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(new { message = $"{message}:", currentDate = DateTime.Now });            
        }

        public void Handle(Output output)
        {
            AppointmentModel newProfile = new AppointmentModel(
                output._appointment.Id,
                output._appointment.MedicalSpecialtyId,
                output._appointment.PatientId,
                output._appointment.AssignedDate,
                new MedicalSpecialtyModel(output._appointment.MedicalSpecialty.Id, output._appointment.MedicalSpecialty.Name)
            );

            ViewModel = new CreatedAtRouteResult("GetAppointment",
                new
                {
                    _appointment = newProfile.Id
                },
                newProfile);
        }
    }
}
