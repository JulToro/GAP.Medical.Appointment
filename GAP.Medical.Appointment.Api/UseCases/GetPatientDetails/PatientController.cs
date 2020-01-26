namespace GAP.Medical.Appointment.Api.UseCases.GetPatientDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Api.Models;
    using GAP.Medical.Appointment.Api.UseCases.RegisterPatient;
    using GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    public class PatientController : Controller
    {
        private readonly IUseCase _Patient;
        private readonly Presenter _presenter;
        public PatientController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _Patient = registerPatient;
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
            await _Patient.Execute(new Input(PatientId));
            return Ok(_presenter.ViewModel);
        }
    }
}