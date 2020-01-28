namespace GAP.Medical.Appointment.Application.UseCases
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpecialty;
    using GAP.Medical.Appointment.Application.Repositories;

    public class GetMedicalSpecialty : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IMedicalSpecialtiesRepository _iMedicalSpecialtiesRepository;
        public GetMedicalSpecialty(
                               IMedicalSpecialtiesRepository iMedicalSpecialtiesRepository,
                               IOutputHandler outputHandler
                               )
        {
            _iMedicalSpecialtiesRepository = iMedicalSpecialtiesRepository;
            _outputHandler = outputHandler;
        }
        public async Task Execute()
        {
            var medicalSpecialties = await _iMedicalSpecialtiesRepository.Get();

            if (medicalSpecialties.Count() == 0) 
            {
                _outputHandler.Error("List of medical specialties it's no found");
                return;
            }

            Output output = new Output(medicalSpecialties);

            _outputHandler.Handle(output);
        }
    }
}
