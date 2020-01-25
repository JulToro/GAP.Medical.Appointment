﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.MedicaSpecialties
{
    public class MedicalSpeciality : IMedicalSpeciality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MedicalSpeciality(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

    }
}
