using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.Models
{
    public class PatientApointmentModel
    {
        public PatientModel Patient { get; set; }
        public IEnumerable<AppointmentModel> Appointments { get; set; }
        public PatientApointmentModel(PatientModel patient, IEnumerable<AppointmentModel> appointments)
        {
            Patient = patient;
            Appointments = appointments;
        }
    }
}
