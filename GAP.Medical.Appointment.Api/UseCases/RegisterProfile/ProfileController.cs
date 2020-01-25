using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Medical.Appointment.Application.RegisterPatient.UseCases;
using GAP.Medical.Appointment.Domain.Patients;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.RegisterProfile
{
    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Profile")]
    [EnableCors("MyPolicy")]
    public class ProfileController : Controller
    {
        private readonly IUseCase _registerPatient;
        private readonly Presenter _presenter;
        public ProfileController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _registerPatient = registerPatient;
            _presenter = presenter;
        }
        /// <summary>
        /// Get Profile 3
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(ICollection<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get()
        {
            ICollection<ProfileModel> result = null;
            ProfileModel profile = new ProfileModel(Guid.NewGuid(), "", "", "", "", "");
            result.Add(profile);

            return Ok(true);
        }

        /// <summary>
        /// Get appoitment by Patient
        /// </summary>
        /// <param name="id">Guid Id Patient</param>
        /// <returns></returns>
        [HttpGet("{PatientId}")]
        [ProducesResponseType(typeof(ProfileModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get(Guid PatientId)
        {
            ProfileModel result = new ProfileModel(Guid.NewGuid(), "", "", "", "", "");

            return Ok(result);
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
            await _registerPatient.Execute(new Input(new Patient(patient.DocumentId, patient.Name, patient.LastName, patient.PhoneNumber, patient.Email)));            
            return Ok(_presenter.ViewModel);
        }
    }
}