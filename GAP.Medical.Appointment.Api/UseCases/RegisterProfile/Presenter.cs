using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.RegisterProfile
{
    public class Presenter : IOutputHandler
    {
        public IActionResult ViewModel { get; private set; }
        public void Handle(Output output)
        {
            ProfileModel newProfile = new ProfileModel(
                output.Patient.Id,
                output.Patient.DocumentId,
                output.Patient.LastName,
                output.Patient.Email,
                output.Patient.Name,
                output.Patient.PhoneNumber
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
