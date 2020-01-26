
namespace GAP.Medical.Appointment.Application.UseCases
{
    using GAP.Medical.Appointment.Application.Boundaries.AsignAppoinments;
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Application.Services;
    using GAP.Medical.Appointment.Domain;
    using GAP.Medical.Appointment.Domain.Appointments;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AsignAppointment : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IMedicalSpecialitiesRepository _iMedicalSpecialitiesRepository;
        private readonly IUnitOfWork _unityOfWork;
        public AsignAppointment(IPatientRepository iPatientRepository,
                               IAppointmentReporsitory iAppointmentReporsitory,
                               IMedicalSpecialitiesRepository iMedicalSpecialitiesRepository,
                               IEntitiesFactory entityFactory,
                               IOutputHandler outputHandler,
                               IUnitOfWork unityOfWork
                               )
        {
            _patientRepository = iPatientRepository;
            _iAppointmentReporsitory = iAppointmentReporsitory;
            _iMedicalSpecialitiesRepository = iMedicalSpecialitiesRepository;
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

            var patient = await _patientRepository.Get(input._Appointment.PatientId);
            if (patient == null) 
            {
                _outputHandler.Error("The id Patient Id doesn't exist");
                return;
            }

            var medicalSpeciallity = await _iMedicalSpecialitiesRepository.Get(input._Appointment.MedicalSpecialityId);

            if (medicalSpeciallity == null) 
            {
                _outputHandler.Error("The id Medical Speciallity Id doesn't exist");
                return;
            }

            IEnumerable<IAppointment> assignedAppoinments = await _iAppointmentReporsitory.Get(input._Appointment.PatientId);

            if (!input._Appointment.ValidateAvailabilityDate(assignedAppoinments)) 
            {
                _outputHandler.Error("The date can't assign.");
                return;
            }

            var appoinment =  _entityFactory.NewAppointment(input._Appointment.PatientId
                                        , input._Appointment.MedicalSpecialityId
                                        , input._Appointment.AssignedDate
                                        );




            await _iAppointmentReporsitory.Add(appoinment);
            await _unityOfWork.Save();
            Output output = new Output(appoinment, medicalSpeciallity);

            _outputHandler.Handle(output);

        }
    }
}
