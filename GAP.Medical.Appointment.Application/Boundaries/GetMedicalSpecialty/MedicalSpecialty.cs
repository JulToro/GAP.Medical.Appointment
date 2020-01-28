using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty
{
    public class MedicalSpecialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public MedicalSpecialty(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
