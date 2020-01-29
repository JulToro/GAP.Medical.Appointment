using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Repositories
{
    public interface IPatientRepository
    {
        Task<bool> FindDocumentId(string documentId);
        Task<bool> FindUserName(string userName);
        Task<IPatient> Get(string user, string password);
        Task<IPatient> Get(Guid id);
        Task Add(IPatient patient);
        Task Update(IPatient patient);
        Task Delete(IPatient patient);
    }
}
