using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty
{
    public class Output
    {
        public IEnumerable<MedicalSpecialty> MedicalSpecialties { get; }

        public Output(IEnumerable<IMedicalSpecialty> medicalSpecialties) 
        {
            List<MedicalSpecialty> listMedicalSpecialties = new List<MedicalSpecialty>();

            foreach (var item in medicalSpecialties) 
            {
                var specialty = (Domain.MedicaSpecialties.MedicalSpecialty)item;
                listMedicalSpecialties.Add(new MedicalSpecialty(specialty.Id, specialty.Name));
            }
            MedicalSpecialties = listMedicalSpecialties;
        }
    }
}
