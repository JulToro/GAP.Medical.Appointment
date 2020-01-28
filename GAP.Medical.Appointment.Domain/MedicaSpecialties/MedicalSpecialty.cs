using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.MedicaSpecialties
{
    public class MedicalSpecialty : IMedicalSpecialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Appointment.Domain.Appointments.Appointment> Appointments { get; set; }

        public MedicalSpecialty(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

    }
}
