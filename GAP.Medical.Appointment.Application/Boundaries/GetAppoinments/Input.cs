﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
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
