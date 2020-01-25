using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.UseCases.GetPatientDetails
{
    public class Input
    {
        public Patient Patient { get; set; }
        public Input(Patient patient)
        {
            Patient = patient;
        }

    }
}
