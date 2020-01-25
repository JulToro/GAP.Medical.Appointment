using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.RegisterPatient
{
    public class Output
    {
        public Patient Patient { get; set; }
        public Output(Patient patient)
        {
            Patient = patient;
        }
    }
}
