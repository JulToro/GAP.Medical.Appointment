using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Appontments
{
    public class Appointment: IAppointment
    {
        public Guid Id { get;  set; }
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialties { get; set; }
        public DateTime AssignedDate { get; set; }

        public Appointment(Guid patientId, Guid specialtiesMedicalId)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            MedicalSpecialties = specialtiesMedicalId;
        }
    }
}
