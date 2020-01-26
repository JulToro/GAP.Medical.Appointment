using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.CancelAppointment
{
    public class Output
    {
        public bool _successful { get; }

        public Output(bool successful)
        {
            _successful = successful;
        }
    }
}
