using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Appontments
{
    public class Appointment: IAppointment
    {
        public Guid Id { get;  set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
        public DateTime AssignedDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual MedicalSpeciality MedicalSpeciality { get; set; }

        public Appointment(Guid patientId, Guid medicalSpecialityId, DateTime assignedDate)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            MedicalSpecialityId = medicalSpecialityId;
            AssignedDate = assignedDate;
        }


    }
}
