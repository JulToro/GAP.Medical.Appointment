using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Infrastructure.MockRepositories
{
    public class PatientRepositoryMock : IPatientRepository
    {
        public async Task Add(IPatient patient)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(IPatient patient)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindDocumentId(string documentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IPatient> Get(string user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IPatient> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(IPatient patient)
        {
            throw new NotImplementedException();
        }
    }
}
