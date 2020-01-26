using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
{
    public class MedicalSpeciality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MedicalSpeciality(IMedicalSpeciality _medicalSpeciality)
        {
            var medicalSpeciality = (Domain.MedicaSpecialties.MedicalSpeciality)_medicalSpeciality;
            Id = medicalSpeciality.Id;
            Name = medicalSpeciality.Name;
        }
    }
}
