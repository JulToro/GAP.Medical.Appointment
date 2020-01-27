using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAP.Medical.Appointment.Application.Boundaries.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.Loggin
{    
    
    /// <summary>
     /// Class Login 
     /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class LoginController : Controller
    {
        private readonly IUseCase _Patient;
        private readonly Presenter _presenter;
        public LoginController(
            IUseCase registerPatient,
            Presenter presenter
            )
        {
            _Patient = registerPatient;
            _presenter = presenter;
        }

        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Get([FromQuery] string user, [FromQuery] string password)
        {
            await _Patient.Execute(new Input(user, password));
            return Ok(_presenter.ViewModel);
        }
    }
}