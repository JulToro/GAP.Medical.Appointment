using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails
{
    public interface IOutputHandler : IErrorHandler
    {
        void Handle(Output output);
    }
}
