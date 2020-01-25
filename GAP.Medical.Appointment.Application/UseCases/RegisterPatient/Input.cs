using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.RegisterPatient.UseCases
{
    public class Input
    {
        public Patient Patient { get; set; }
        public Input(Patient patient ) 
        {
            Patient = patient;
        }

    }
}
