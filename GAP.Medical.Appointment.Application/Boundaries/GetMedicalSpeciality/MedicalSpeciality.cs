using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality
{
    public class MedicalSpeciality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public MedicalSpeciality(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
