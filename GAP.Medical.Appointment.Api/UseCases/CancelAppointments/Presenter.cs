using GAP.Medical.Appointment.Application.Boundaries.CancelAppointment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.CancelAppointments
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
            ViewModel = new CreatedAtRouteResult("DeleteAppointment",
                new
                {
                    sucessful = output._successful
                },
                output);
        }
    }
}
