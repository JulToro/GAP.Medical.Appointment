using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.Login
{
    public class Output
    {
        public IPatient Patient { get; set; }
        public Output(IPatient patient)
        {
            Patient = patient;
        }
    }
}
