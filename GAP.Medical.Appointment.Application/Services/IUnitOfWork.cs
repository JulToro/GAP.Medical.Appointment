using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
