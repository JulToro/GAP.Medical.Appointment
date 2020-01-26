using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.Models
{
    public class MedicalSpecialityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MedicalSpecialityModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
