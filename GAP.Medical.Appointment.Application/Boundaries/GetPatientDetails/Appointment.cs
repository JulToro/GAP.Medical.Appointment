using GAP.Medical.Appointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
        public DateTime AssignedDate { get; set; }


        public Appointment(IAppointment patient)
        {
            var Appointment = (Domain.Appointments.Appointment)patient;

            Id = Appointment.Id;
            PatientId = Appointment.PatientId;
            MedicalSpecialityId = Appointment.MedicalSpecialityId;
            AssignedDate = Appointment.AssignedDate;
        }
    }
}
