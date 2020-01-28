using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GAP.Medical.Appointment.Api.Models;
using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.GetMedicalSpecialties
{ 
    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicalSpecialtyController : Controller
    {
        private readonly IUseCase _medicalSpecialties;
        private readonly Presenter _presenter;
        public MedicalSpecialtyController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _medicalSpecialties = registerPatient;
            _presenter = presenter;
        }       
        
        
        /// <summary>
        /// Get appoitment by Patient
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<MedicalSpecialtyModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get()
        {
            await _medicalSpecialties.Execute();
            return Ok(_presenter.ViewModel);
        }

    }
}