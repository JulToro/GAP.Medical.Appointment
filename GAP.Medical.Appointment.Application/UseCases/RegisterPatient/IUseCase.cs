using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.RegisterPatient.UseCases
{
    public interface IUseCase
    {
        Task Execute(Input input);
    }
}
