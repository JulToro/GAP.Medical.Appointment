using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Repositories
{
    public interface IPatientRepository
    {
        Task<IPatient> Get(Guid id);
        Task Add(IPatient patient);
        Task Update(IPatient patient);
        Task Delete(IPatient patient);
    }
}
