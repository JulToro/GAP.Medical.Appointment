namespace GAP.Medical.Appointment.Infrastructure.Repositories
{
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Domain.MedicaSpecialties;
    using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MedicalSpecialtiesRepository : IMedicalSpecialtiesRepository
    {
        private readonly AppointmentContext _context;
        public MedicalSpecialtiesRepository(AppointmentContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IMedicalSpecialty> Get(Guid id)
        {
            var medicalSpecialties = await _context.MedicalSpecialties.Where(x => x.Id == id).Select(y => y).SingleOrDefaultAsync();

            return medicalSpecialties;
        }

        public async Task<IEnumerable<IMedicalSpecialty>> Get()
        {
            var medicalSpecialities = await _context.MedicalSpecialties.Select(x=>x).ToListAsync();
            return medicalSpecialities;
        }
    }
}
