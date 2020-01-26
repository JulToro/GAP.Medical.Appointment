namespace GAP.Medical.Appointment.Api.UseCases.RegisterPatient
{
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
    using DomainPatient = GAP.Medical.Appointment.Domain.Patients;
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
        private readonly IUseCase _registerPatient;
        private readonly Presenter _presenter;
        public PatientController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _registerPatient = registerPatient;
            _presenter = presenter;
        }


        /// <summary>
        /// Register a new Patient
        /// </summary>
        /// <param name="patient">Patient</param>
        /// <returns></returns>
        [HttpPost()]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody]RegisterPatientRequest patient)
        {
            await _registerPatient.Execute(new Input(new DomainPatient.Patient(patient.DocumentId, patient.Name, patient.LastName, patient.PhoneNumber, patient.Email)));
            return Ok(_presenter.ViewModel);
        }
    }
}