using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.Models
{
    public class AppointmentModel
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public DateTime AssignedDate { get; set; }

        public MedicalSpecialtyModel MedicalSpecialty { get; set; }

        public AppointmentModel(Guid id, Guid patientId, Guid medicalSpecialtyId, DateTime assignedDate, MedicalSpecialtyModel medicalSpecialty)
        {
            Id = id;
            PatientId = patientId;
            MedicalSpecialtyId = medicalSpecialtyId;
            AssignedDate = assignedDate;
            MedicalSpecialty = medicalSpecialty;
        }
    }
}
