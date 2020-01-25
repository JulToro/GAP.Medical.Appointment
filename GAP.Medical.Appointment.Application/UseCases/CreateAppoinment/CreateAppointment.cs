
namespace GAP.Medical.Appointment.Application.UseCases.CreateAppoinment
{
    using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Application.Services;
    using GAP.Medical.Appointment.Domain;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateAppointment : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IUnitOfWork _unityOfWork;
        public CreateAppointment(IPatientRepository iPatientRepository,
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

        public Task Execute(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
