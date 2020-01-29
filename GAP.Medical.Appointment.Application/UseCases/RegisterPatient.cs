using GAP.Medical.Appointment.Application.Boundaries.RegisterPatient;
using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using System;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases
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

            if (await _patientRepository.FindDocumentId(input.Patient.DocumentId))
            {
                _outputHandler.Error("DocumentId has already registered.");
                return;
            }
            if (await _patientRepository.FindUserName(input.Patient.Username))
            {
                _outputHandler.Error("UserName has already registered.");
                return;
            }

            try
            {
               

                var patient = _entityFactory.NewPatient(input.Patient.DocumentId
                                                            , input.Patient.Name
                                                            , input.Patient.LastName
                                                            , input.Patient.PhoneNumber
                                                            , input.Patient.Email
                                                            , input.Patient.Username
                                                            , input.Patient.Password
                                                            , new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                                            , true
                                                            );
                string validate = patient.Validate();
                if (!string.IsNullOrEmpty(validate)) 
                {
                    _outputHandler.Error(validate); return;
                }

                await _patientRepository.Add(patient);
                await _unityOfWork.Save();
                Output output = new Output(patient); 
                _outputHandler.Handle(output);
            }
            catch (Exception)
            {
                _outputHandler.Error("An rror ocurred when try to insert new register.");
                return;
            }
           

            
        }
    }
}
