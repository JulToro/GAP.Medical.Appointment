namespace GAP.Medical.Appointment.Api.UseCases.CancelAppointments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.CancelAppointment;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    
    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    public class AppointmentController : Controller
    {
        private readonly IUseCase _CancelAppointment;
        private readonly Presenter _presenter;
        public AppointmentController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _CancelAppointment = registerPatient;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a new Patient
        /// </summary>
        /// <param name="idAppointment">Patient</param>
        /// <returns></returns>
        [HttpDelete()]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Delete(Guid idAppointment)
        {
            await _CancelAppointment.Execute(new Input(idAppointment));
            return Ok(_presenter.ViewModel);
        }
    }
}