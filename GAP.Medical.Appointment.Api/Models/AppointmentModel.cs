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
        public Guid MedicalSpecialityId { get; set; }
        public DateTime AssignedDate { get; set; }

        public MedicalSpecialityModel MedicalSpeciality { get; set; }

        public AppointmentModel(Guid id, Guid patientId, Guid medicalSpecialityId, DateTime assignedDate, MedicalSpecialityModel medicalSpeciality)
        {
            Id = id;
            PatientId = patientId;
            MedicalSpecialityId = medicalSpecialityId;
            AssignedDate = assignedDate;
            MedicalSpeciality = medicalSpeciality;
        }
    }
}
