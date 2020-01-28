using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialties
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
            List<MedicalSpecialtyModel> medicalSpecialities = new List<MedicalSpecialtyModel>();
            foreach (var item in output.MedicalSpecialties) 
            {

                MedicalSpecialtyModel medialModel = new MedicalSpecialtyModel(
                                           item.Id,
                                           item.Name
                                         );
                medicalSpecialities.Add(medialModel);
            }

            ViewModel = new CreatedAtRouteResult("GetMedicalSpecialities",
                medicalSpecialities);

        }
    }
}
