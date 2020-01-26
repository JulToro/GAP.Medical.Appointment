using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.Boundaries.RegisterPatient
{
    public interface IUseCase
    {
        Task Execute(Input input);
    }
}
