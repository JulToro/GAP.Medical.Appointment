using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Api.UseCases.AssignAppointments
{
    public class RequirerAppoinment
    {
        public Guid PatientId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
