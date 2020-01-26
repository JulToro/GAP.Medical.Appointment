using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Application.Boundaries.GetAppoinments
{
    public class Output
    {
        public Patient Patient { get; set; }  
        public IEnumerable<Appointment> Appointments { get; set; }

        public Output(IPatient patient,  IEnumerable<Boundaries.GetAppoinments.Appointment> appointments) 
        {
            Patient = new Patient(patient);          
            Appointments = appointments;
        }

    }
}
