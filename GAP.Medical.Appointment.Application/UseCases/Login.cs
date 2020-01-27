using GAP.Medical.Appointment.Application.Boundaries.Login;
using GAP.Medical.Appointment.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases
{
    public class Login : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        public Login(IPatientRepository iPatientRepository, IOutputHandler outputHandler)
        {
            _patientRepository = iPatientRepository;
            _outputHandler = outputHandler;
        }

        public async Task Execute(Input input)
        {
            var patient = await _patientRepository.Get(input.UserName, input.Password);

            if (patient == null)
            {
                _outputHandler.Error("user doesn' exist");
                return;
            }

            Output output = new Output(patient);

            _outputHandler.Handle(output);
        }
    }
}
