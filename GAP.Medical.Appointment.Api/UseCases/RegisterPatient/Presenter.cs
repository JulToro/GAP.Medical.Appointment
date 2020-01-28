namespace GAP.Medical.Appointment.Api.UseCases.RegisterPatient
{
    using GAP.Medical.Appointment.Api.Models;
    using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public  class Presenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new BadRequestObjectResult(new { message = $"{message}:", currentDate = DateTime.Now });
        }

        public void Handle(Output output)
        {
            PatientModel newProfile = new PatientModel(
                output._patient.Id,
                output._patient.DocumentId,
                output._patient.LastName,
                output._patient.Email,
                output._patient.Name,
                output._patient.PhoneNumber
            );

            ViewModel = new CreatedAtRouteResult("GetPatient",
                new
                {
                    patientId = newProfile.Id
                },
                newProfile);
        }
    }
}
