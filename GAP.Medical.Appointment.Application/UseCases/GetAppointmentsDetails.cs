namespace GAP.Medical.Appointment.Application.UseCases
{
    using GAP.Medical.Appointment.Application.Boundaries.GetAppoinments;
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Application.Services;
    using GAP.Medical.Appointment.Domain;
    using System;
    using System.Threading.Tasks;
    public class GetAppointmentsDetails : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IUnitOfWork _unityOfWork;
        public GetAppointmentsDetails(IPatientRepository iPatientRepository,
                               IAppointmentReporsitory iAppointmentReporsitory,
                               IEntitiesFactory entityFactory,
                               IOutputHandler outputHandler,
                               IUnitOfWork unityOfWork
                               )
        {
            _patientRepository = iPatientRepository;
            _iAppointmentReporsitory = iAppointmentReporsitory;
            _outputHandler = outputHandler;
            _entityFactory = entityFactory;
            _unityOfWork = unityOfWork;
        }
        public async Task Execute(Input input)
        {
            var patient = await _patientRepository.Get(input.PatientId);
            if (patient == null)
            {
                _outputHandler.Error("The id Patient Id don't exist");
                return;
            }


            //Output output = new Output(patient);

            //_outputHandler.Handle(output);
        }
    }
}
