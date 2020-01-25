using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain
{
    public class Result<T>
    {
        public T Response { get; set; }
        public bool IsSuccess { get; set; }
        public string Exception { get; set; }

    }
}
