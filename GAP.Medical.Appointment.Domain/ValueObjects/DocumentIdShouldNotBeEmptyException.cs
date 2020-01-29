using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.ValueObjects
{
    public class DocumentIdShouldNotBeEmptyException: Exception
    {
        internal DocumentIdShouldNotBeEmptyException(string message) : base(message) { }
    }
}
