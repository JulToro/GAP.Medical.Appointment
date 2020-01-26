namespace GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments
{
    using GAP.Medical.Appointment.Domain.Appointments;
    using GAP.Medical.Appointment.Domain.MedicaSpecialties;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Output
    {
        public Appointment _appointment { get; set; }
        public Output(IAppointment appointment, IMedicalSpeciality medicalSpeciality)
        {
            _appointment = new GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments.Appointment(appointment, medicalSpeciality);
        }
    }
}
