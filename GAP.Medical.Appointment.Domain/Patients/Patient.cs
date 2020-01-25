using GAP.Medical.Appointment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Patients
{
    public class Patient: IPatient
    {
        public Guid Id { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Patient(string documentId, string name, string lastName, string phoneNumber, string email) 
        {
            Id = Guid.NewGuid();
            DocumentId = documentId;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
