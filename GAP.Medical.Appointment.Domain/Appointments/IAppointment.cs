using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Appointments
{
    public interface IAppointment: IAggregateRoot
    {
        bool ValidateAvailabilityDate(IEnumerable<IAppointment> apointmets);
    }
}
