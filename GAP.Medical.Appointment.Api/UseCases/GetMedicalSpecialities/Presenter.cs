using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialities
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
            List<MedicalSpecialityModel> medicalSpecialities = new List<MedicalSpecialityModel>();
            foreach (var item in output.MedicalSpecialities) 
            {

                MedicalSpecialityModel medialModel = new MedicalSpecialityModel(
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
