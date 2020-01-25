using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.RegisterProfile
{
    public class ProfileModel
    {
        public Guid Id { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ProfileModel(Guid id, string documentId, string name, string lastName, string phoneNumer, string email ) 
        {
            Id = id;
            DocumentId = documentId;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumer;
            Email = email;
        }
    }
}
