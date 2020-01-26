using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
{
    public class Patient
    {
        public Guid Id { get; }
        public string DocumentId { get; }
        public string Name { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        public Patient(IPatient patient)
        {
            var patientRegister = (Domain.Patients.Patient)patient;

            Id = patientRegister.Id;
            DocumentId = patientRegister.DocumentId;
            Name = patientRegister.Name;
            LastName = patientRegister.LastName;
            PhoneNumber = patientRegister.PhoneNumber;
            Email = patientRegister.Email;
        }
    }
}
