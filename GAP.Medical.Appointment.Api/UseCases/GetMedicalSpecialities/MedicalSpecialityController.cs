using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialities
{ 
    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class MedicalSpecialityController : Controller
    {
        private readonly IUseCase _medicalSpecialities;
        private readonly Presenter _presenter;
        public MedicalSpecialityController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _medicalSpecialities = registerPatient;
            _presenter = presenter;
        }       
        
        
        /// <summary>
        /// Get appoitment by Patient
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<MedicalSpecialityModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get()
        {
            await _medicalSpecialities.Execute();
            return Ok(_presenter.ViewModel);
        }

    }
}