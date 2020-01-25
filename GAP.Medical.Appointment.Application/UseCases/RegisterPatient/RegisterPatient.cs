using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
using GAP.Medical.Appointment.Application.RegisterPatient.UseCases;
using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases.RegisterPatient
{
    public class RegisterPatient : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IUnitOfWork _unityOfWork;
        public RegisterPatient(IPatientRepository iPatientRepository,
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
            if (input == null)
            {
                _outputHandler.Error("Input is null.");
                return;
            }

            var patient = _entityFactory.NewPatient(input.Patient.DocumentId
                                                    , input.Patient.Name
                                                    , input.Patient.LastName
                                                    , input.Patient.PhoneNumber
                                                    , input.Patient.Email
                                                    );

            await _patientRepository.Add(patient);

            Output output = new Output(patient);

            _outputHandler.Handle(output);
        }
    }
}
