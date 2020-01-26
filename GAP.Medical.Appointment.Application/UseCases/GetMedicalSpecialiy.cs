namespace GAP.Medical.Appointment.Application.UseCases
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using GAP.Medical.Appointment.Application.Boundaries.GetMedicalSpeciality;
    using GAP.Medical.Appointment.Application.Repositories;

    public class GetMedicalSpecialiy : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IMedicalSpecialitiesRepository _iMedicalSpecialitiesRepository;
        public GetMedicalSpecialiy(
                               IMedicalSpecialitiesRepository iMedicalSpecialitiesRepository,
                               IOutputHandler outputHandler
                               )
        {
            _iMedicalSpecialitiesRepository = iMedicalSpecialitiesRepository;
            _outputHandler = outputHandler;
        }
        public async Task Execute()
        {
            var medicalSpecialities = await _iMedicalSpecialitiesRepository.Get();

            if (medicalSpecialities.Count() == 0) 
            {
                _outputHandler.Error("List of medical specialities it's no found");
                return;
            }

            Output output = new Output(medicalSpecialities);

            _outputHandler.Handle(output);
        }
    }
}
