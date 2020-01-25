using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases.GetPatientDetails
{
    public interface IUseCase
    {
        Task Execute(Input input);
    }
}
