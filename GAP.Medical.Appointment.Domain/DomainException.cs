using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage) : base(businessMessage)
        { }
    }
}
