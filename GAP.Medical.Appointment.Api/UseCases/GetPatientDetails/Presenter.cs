using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.GetPatientDetails
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
            PatientModel newProfile = new PatientModel(
                output.Id,
                output.DocumentId,
                output.Name,
                output.LastName,
                output.PhoneNumber,
                output.Email
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
