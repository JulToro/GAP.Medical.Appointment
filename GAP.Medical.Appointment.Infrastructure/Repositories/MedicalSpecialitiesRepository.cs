namespace GAP.Medical.Appointment.Infrastructure.Repositories
{
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Domain.MedicaSpecialties;
    using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class MedicalSpecialitiesRepository : IMedicalSpecialitiesRepository
    {
        private readonly AppointmentContext _context;
        public MedicalSpecialitiesRepository(AppointmentContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IMedicalSpeciality> Get(Guid id)
        {
            var medicalSpecialities = await _context.MedicalSpecialities.Where(x => x.Id == id).Select(y => y).SingleOrDefaultAsync();

            return medicalSpecialities;
        }
    }
}
