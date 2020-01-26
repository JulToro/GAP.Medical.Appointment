using GAP.Medical.Appointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Repositories
{
    public interface IAppointmentReporsitory
    {
        Task<IEnumerable<IAppointment>> Get(Guid medicalSpecialityId, DateTime dateIni, DateTime dateEnd);
        Task<IEnumerable<IAppointment>> Get(Guid PatientId);
        Task Add(IAppointment appointment);
        Task Update(IAppointment appointment);
        Task Delete(IAppointment appointment);
    }
}
