using GAP.Medical.Appointment.Domain.Appontments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Repositories
{
    public interface IAppointmentReporsitory
    {
        Task<ICollection<IAppointment>> Get(Guid medicalSpecialityId, DateTime dateIni, DateTime dateEnd);
        Task<ICollection<IAppointment>> Get(Guid PatientId);
        Task Add(IAppointment appointment);
        Task Update(IAppointment appointment);
        Task Delete(IAppointment appointment);
    }
}
