

namespace GAP.Medical.Appointment.Api.UseCases.GetAppointmentsDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.GetAppoinments;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class Profile 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
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

    }
}