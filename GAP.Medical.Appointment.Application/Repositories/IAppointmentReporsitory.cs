using GAP.Medical.Appointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Repositories
{
    public interface IAppointmentReporsitory
    {
        Task<IEnumerable<IAppointment>> GetbyPatientId(Guid PatientId);
        Task<IEnumerable<IAppointment>> Get(Guid AppointmentId);
        Task Add(IAppointment appointment);
        Task Update(IAppointment appointment);
        Task Delete(IAppointment appointment);
    }
}
