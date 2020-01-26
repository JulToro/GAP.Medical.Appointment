using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apoitments =  GAP.Medical.Appointment.Domain.Appointments;

namespace GAP.Medical.Appointment.Infrastructure.Repositories
{
    public class AppointmentReporsitory : IAppointmentReporsitory
    {
        private readonly AppointmentContext _context;
        public AppointmentReporsitory(AppointmentContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task Add(IAppointment appointment)
        {
            await _context.Appointment.AddAsync((Apoitments.Appointment)appointment);
        }

        public async Task Delete(IAppointment appointment)
        {
             _context.Appointment.Remove((Apoitments.Appointment)appointment);
             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IAppointment>> Get(Guid medicalSpecialityId, DateTime dateIni, DateTime dateEnd)
        {
            var Appoitments =  await _context.Appointment.Where(x => x.MedicalSpeciality.Id == medicalSpecialityId && x.AssignedDate >= dateIni && x.AssignedDate <= dateEnd).Select(y=>y).ToListAsync(); 
                       
            return Appoitments;
        }

        public async Task<IEnumerable<IAppointment>> Get(Guid PatientId)
        {
            var Appoitments = await _context.Appointment.Where(x => x.PatientId == PatientId).Select(y => y).ToListAsync();

            return Appoitments;
        }

        public async Task Update(IAppointment appointment)
        {
            _context.Appointment.Update((Apoitments.Appointment)appointment);
            await _context.SaveChangesAsync();
        }
    }
}
