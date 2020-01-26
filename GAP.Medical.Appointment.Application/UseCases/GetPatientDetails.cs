namespace GAP.Medical.Appointment.Application.UseCases
{
    using GAP.Medical.Appointment.Application.Boundaries.GetPatientDetails;
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Application.Services;
    using GAP.Medical.Appointment.Domain;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class GetPatientDetails: IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        public GetPatientDetails(IPatientRepository iPatientRepository,
                               IOutputHandler outputHandler
                               )
        {
            _patientRepository = iPatientRepository;
            _outputHandler = outputHandler;
        }

        public async Task Execute(Input input)
        {
            var patient = await _patientRepository.Get(input.PatientId);
            if (patient == null) 
            {
                _outputHandler.Error("The id Patient Id don't exist");
                return;
            }
            Output output = new Output(patient);

            _outputHandler.Handle(output);
        }
    }
}
