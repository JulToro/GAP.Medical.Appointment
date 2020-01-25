using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.AssignAppointments
{
    public class AppointmentController : Controller
    {
        /// <summary>
        /// Get Profile 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{MedicalSpecialityId}")]
        [ProducesResponseType(typeof(AppointmentModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get(Guid MedicalSpecialityId)
        {
            AppointmentModel result = new AppointmentModel();

            return Ok(result);
        }
    }
}