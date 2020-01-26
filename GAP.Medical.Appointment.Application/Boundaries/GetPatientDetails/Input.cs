using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails
{
    public class Input
    {
        public Guid PatientId { get; }

        public Input(Guid patientId)
        {
            PatientId = patientId;
        }

    }
}
