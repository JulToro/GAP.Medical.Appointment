using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Patients
{
    public class AppointmentsCollection
    {
        private readonly IList<Guid> _appointmenIds;

        public AppointmentsCollection()
        {
            _appointmenIds = new List<Guid>();
        }

        public IReadOnlyCollection<Guid> GetAppoinmentIds()
        {
            IReadOnlyCollection<Guid> appointmentIds = new ReadOnlyCollection<Guid>(_appointmenIds);
            return appointmentIds;
        }

        public void Add(Guid appoinmentId)
        {
            _appointmenIds.Add(appoinmentId);
        }
    }
}
