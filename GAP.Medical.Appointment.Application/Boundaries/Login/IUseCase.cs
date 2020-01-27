using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Boundaries.Login
{
    public interface IUseCase
    {
        Task Execute(Input input);
    }
}
