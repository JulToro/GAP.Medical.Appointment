

namespace GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Api.Models;
    using GAP.Medical.Appointment.Application.Boundaries.GetAppoinments;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentController : Controller
    {
        private readonly IUseCase _GetAppoinment;
        private readonly Presenter _presenter;
        public AppointmentController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _GetAppoinment = registerPatient;
            _presenter = presenter;
        }

        /// <summary>
        /// Get appoitment by Patient
        /// </summary>
        /// <param name="PatientId">Guid Id Patient</param>
        /// <returns></returns>
        [HttpGet("{PatientId}")]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get(Guid PatientId)
        {
            await _GetAppoinment.Execute(new Input(PatientId));
            return Ok(_presenter.ViewModel);
        }
    }
}