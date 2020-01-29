using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Patients
{
    public interface IPatient : IAggregateRoot
    {
        IReadOnlyCollection<Guid> AppointmentIds { get; }

        string Validate();
    }
}
