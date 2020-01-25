using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.RegisterPatient
{
    public sealed class Patient
    {
        public Guid Id { get;  }
        public string DocumentId { get; }
        public string Name { get;  }
        public string LastName { get;  }
        public string PhoneNumber { get;  }
        public string Email { get;  }

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
