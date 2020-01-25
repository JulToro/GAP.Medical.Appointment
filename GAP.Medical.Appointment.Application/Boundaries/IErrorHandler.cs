using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries
{
    public interface IErrorHandler
    {
        void Error(string message);
    }
}
