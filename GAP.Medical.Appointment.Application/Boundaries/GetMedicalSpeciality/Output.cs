using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality
{
    public class Output
    {
        public IEnumerable<MedicalSpeciality> MedicalSpecialities { get; }

        public Output(IEnumerable<IMedicalSpeciality> medicalSpecialities) 
        {
            List<MedicalSpeciality> listMedicalSpecialities = new List<MedicalSpeciality>();

            foreach (var item in medicalSpecialities) 
            {
                var speciality = (Domain.MedicaSpecialties.MedicalSpeciality)item;
                listMedicalSpecialities.Add(new MedicalSpeciality(speciality.Id, speciality.Name));
            }
            MedicalSpecialities = listMedicalSpecialities;
        }
    }
}
