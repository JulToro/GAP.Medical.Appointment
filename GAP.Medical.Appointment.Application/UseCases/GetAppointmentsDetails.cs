namespace GAP.Medical.Appointment.Application.UseCases
{
    using GAP.Medical.Appointment.Application.Boundaries.GetAppoinments;
    using GAP.Medical.Appointment.Application.Repositories;
    using GAP.Medical.Appointment.Application.Services;
    using GAP.Medical.Appointment.Domain;
    using GAP.Medical.Appointment.Domain.MedicaSpecialties;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class GetAppointmentsDetails : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IMedicalSpecialitiesRepository _iMedicalSpecialitiesRepository;
        private readonly IUnitOfWork _unityOfWork;
        public GetAppointmentsDetails(IPatientRepository iPatientRepository,
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
            var patient = await _patientRepository.Get(input.PatientId);
            if (patient == null)
            {
                _outputHandler.Error("The id Patient Id doesn't exist");
                return;
            }

            var appointments = await _iAppointmentReporsitory.GetbyPatientId(input.PatientId);

            if (appointments == null)
            {
                _outputHandler.Error("The patient doesn't have appointments");
                return;
            }

            List<Appointment> appointmentsOut = new List<Appointment>();

            foreach (var item in appointments) 
            {
                var appointment = (Domain.Appointments.Appointment)item;
                IMedicalSpeciality imedicalSpeciality = await _iMedicalSpecialitiesRepository.Get(appointment.MedicalSpecialityId);

                Appointment appointmentOut = new Appointment(item, imedicalSpeciality);
                appointmentsOut.Add(appointmentOut);
            }
            

            Output output = new Output(patient, appointmentsOut);

            _outputHandler.Handle(output);
        }
    }
}
