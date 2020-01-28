using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public DateTime AssignedDate { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
        public Appointment(IAppointment appointment, IMedicalSpecialty _medicalSpecialty)
        {
            var Appointment = (Domain.Appointments.Appointment)appointment;
            MedicalSpecialty = new MedicalSpecialty(_medicalSpecialty);
            Id = Appointment.Id;
            PatientId = Appointment.PatientId;
            MedicalSpecialtyId = Appointment.MedicalSpecialtyId;
            AssignedDate = Appointment.AssignedDate;
        }
    }
}
