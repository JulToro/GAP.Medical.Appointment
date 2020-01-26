using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Appointments
{
    public class Appointment : IAppointment
    {
        public Guid Id { get; set; }
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

        public bool ValidateAvailabilityDate(IEnumerable<IAppointment> apointmets)
        {
            if (!ValidateDate())
            {
                return false;
            }

            foreach (var item in apointmets)
            {
                var appointment = (Appointment)item;
                var dateAssignedAppoinment = new DateTime(appointment.AssignedDate.Year, appointment.AssignedDate.Month, appointment.AssignedDate.Day);
                var datenewAppoinment = new DateTime(AssignedDate.Year, AssignedDate.Month, AssignedDate.Day);

                if (dateAssignedAppoinment == datenewAppoinment)
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateDate()
        {
            if (AssignedDate > DateTime.Now)
            {
                return true;
            }

            return false;

        }

        public bool ValidateCancelation()
        {
            if (AssignedDate < DateTime.Now.AddDays(-1))
            {
                return true;
            }

            return false;
        }


    }
}
