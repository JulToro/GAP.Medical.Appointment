﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}
