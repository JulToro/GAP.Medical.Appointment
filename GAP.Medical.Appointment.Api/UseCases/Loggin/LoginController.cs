using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GAP.Medical.Appointment.Api.UseCases.Loggin
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}