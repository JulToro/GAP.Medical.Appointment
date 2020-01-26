using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
        public DateTime AssignedDate { get; set; }

        public MedicalSpeciality MedicalSpeciality { get; set; }
        public Appointment(IAppointment patient, IMedicalSpeciality IMedicalSpeciality)
        {
            var Appointment = (Domain.Appointments.Appointment)patient;

            Id = Appointment.Id;
            PatientId = Appointment.PatientId;
            MedicalSpecialityId = Appointment.MedicalSpecialityId;
            AssignedDate = Appointment.AssignedDate;
            MedicalSpeciality = new MedicalSpeciality(IMedicalSpeciality);
        }
    }
}
