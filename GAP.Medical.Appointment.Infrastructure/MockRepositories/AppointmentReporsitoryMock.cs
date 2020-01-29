using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Infrastructure.MockRepositories
{
    public class AppointmentReporsitoryMock : IAppointmentReporsitory
    {
        public async Task Add(IAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(IAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IAppointment>> Get(Guid AppointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IAppointment>> GetbyPatientId(Guid PatientId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(IAppointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
