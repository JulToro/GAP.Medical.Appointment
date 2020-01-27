using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.Login
{
    public class Input
    {
        public string UserName { get; }
        public string Password { get; }

        public Input(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
