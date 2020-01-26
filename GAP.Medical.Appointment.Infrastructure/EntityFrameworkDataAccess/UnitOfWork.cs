using GAP.Medical.Appointment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppointmentContext context;
        public UnitOfWork(AppointmentContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await context.SaveChangesAsync();
            return affectedRows;
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
