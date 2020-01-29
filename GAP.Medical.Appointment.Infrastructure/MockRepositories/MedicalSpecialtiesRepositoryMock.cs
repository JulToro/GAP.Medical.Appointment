using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Infrastructure.MockRepositories
{
    public class MedicalSpecialtiesRepositoryMock : IMedicalSpecialtiesRepository
    {
        public async Task<IEnumerable<IMedicalSpecialty>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<IMedicalSpecialty> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
