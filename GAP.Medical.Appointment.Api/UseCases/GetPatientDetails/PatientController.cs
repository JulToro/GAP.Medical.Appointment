namespace GAP.Medical.Appointment.Api.UseCases.GetProfilePatient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Api.Models;
    using GAP.Medical.Appointment.Api.UseCases.RegisterPatient;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class PatientController : Controller
    {
        //private readonly IUseCase _registerPatient;
        //private readonly Presenter _presenter;
        //public ProfileController(
        //    IUseCase registerPatient,
        //    Presenter presenter
        //    )
        //{
        //    _registerPatient = registerPatient;
        //    _presenter = presenter;
        //}
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
    }
}