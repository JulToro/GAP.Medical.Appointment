using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments
{
    public class MedicalSpecialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MedicalSpecialty(IMedicalSpecialty _medicalSpecialty)
        {
            var medicalSpecialty = (Domain.MedicaSpecialties.MedicalSpecialty)_medicalSpecialty;
            Id = medicalSpecialty.Id;
            Name = medicalSpecialty.Name;
        }
    }
}
