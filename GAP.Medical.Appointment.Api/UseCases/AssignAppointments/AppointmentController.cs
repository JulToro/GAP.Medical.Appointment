namespace GAP.Medical.Appointment.Api.UseCases.AssignAppointments
{
    using System;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Appointments = GAP.Medical.Appointment.Domain.Appointments;

    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentController : Controller
    {
        private readonly IUseCase _registerAppoinment;
        private readonly Presenter _presenter;
        public AppointmentController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _registerAppoinment = registerPatient;
            _presenter = presenter;
        }
        /// <summary>
        /// Register Appointment
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody]RequirerAppoinment appointment)
        {
            await _registerAppoinment.Execute(new Input(new Appointments.Appointment(appointment.PatientId,appointment.MedicalSpecialityId,appointment.AssignedDate)));
            return Ok(_presenter.ViewModel);

        }
    }
}