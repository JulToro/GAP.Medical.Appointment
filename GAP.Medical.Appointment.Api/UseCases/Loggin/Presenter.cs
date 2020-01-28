using GAP.Medical.Appointment.Application.Boundaries.Login;
using GAP.Medical.Appointment.Security.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.Loggin
{
    public class Presenter:IOutputHandler
    {
        private readonly IConfiguration _configuration;
        public Presenter(IConfiguration iConfiguration) 
        {
            _configuration = iConfiguration;
        }
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            ViewModel = new NoContentResult();
        }
        public void Handle(Output output)
        {
            JWToken jwtUser = new JWToken();
            string token = jwtUser.GenerateJWTToken(output.Patient, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"]);

            ViewModel = new CreatedAtRouteResult("GetToken",new { Token=token, Id = output.Patient.Id });
        }

    }
}
