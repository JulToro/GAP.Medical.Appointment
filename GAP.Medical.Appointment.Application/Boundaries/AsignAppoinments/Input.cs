namespace GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments
{
    using Appointments = GAP.Medical.Appointment.Domain.Appointments;

    public class Input
    {
        public Appointments.Appointment _Appointment { get; set; }
        public Input(Appointments.Appointment Appointment)
        {
            _Appointment = Appointment;
        }

    }
}
