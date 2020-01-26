using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Appontments
{
    public class Appointment: IAppointment
    {
        public Guid Id { get;  set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public DateTime AssignedDate { get; set; }

        public Appointment(Guid patientId, Guid medicalSpecialtyId, DateTime assignedDate)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            MedicalSpecialtyId = medicalSpecialtyId;
            AssignedDate = assignedDate;
        }


    }
}
