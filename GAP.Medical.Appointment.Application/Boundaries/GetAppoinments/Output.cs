using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
{
    public class Output
    {
        public Patient Patient { get; set; }
        public MedicalSpeciality MedicalSpeciality { get; set; }        
        public IEnumerable<Appointment> Appointments { get; set; }

        public Output(Patient patient, MedicalSpeciality medicalSpeciality, IEnumerable<Appointment> appointments) 
        {
            Patient = patient;
            MedicalSpeciality = medicalSpeciality;
            Appointments = appointments;
        }

    }
}
