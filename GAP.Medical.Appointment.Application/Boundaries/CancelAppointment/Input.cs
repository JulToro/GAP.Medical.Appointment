using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.CancelAppointment
{
    public class Input
    {
        public Guid AppointmentId { get; }
        public Input(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
