using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Domain.Patients;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentContext _context;
        public PatientRepository(AppointmentContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(IPatient patient)
        {
            await _context.Patients.AddAsync((Patient)patient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(IPatient patient)
        {
            _context.Patients.Remove((Patient)patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IPatient> Get(Guid id)
        {
            var Patient = await _context.Patients.Where(x =>x.Id == id).Select(y => y).SingleOrDefaultAsync();

            return Patient;
        }

        public async Task<IPatient> Get(string user, string password)
        {
            var Patient = await _context.Patients.Where(x => x.Username == user && x.Password == password).Select(y => y).SingleOrDefaultAsync();

            return Patient;
        }

        public async Task Update(IPatient patient)
        {
            _context.Patients.Update((Patient)patient);
            await _context.SaveChangesAsync();
        }
    }
}
