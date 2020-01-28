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
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IMedicalSpecialtiesRepository _iMedicalSpecialtiesRepository;
        public GetAppointmentsDetails(IPatientRepository iPatientRepository,
                               IAppointmentReporsitory iAppointmentReporsitory,
                               IMedicalSpecialtiesRepository iMedicalSpecialtiesRepository,
                               IOutputHandler outputHandler
                               )
        {
            _patientRepository = iPatientRepository;
            _iAppointmentReporsitory = iAppointmentReporsitory;
            _iMedicalSpecialtiesRepository = iMedicalSpecialtiesRepository;
            _outputHandler = outputHandler;
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
                IMedicalSpecialty imedicalSpecialty = await _iMedicalSpecialtiesRepository.Get(appointment.MedicalSpecialtyId);

                Appointment appointmentOut = new Appointment(item, imedicalSpecialty);
                appointmentsOut.Add(appointmentOut);
            }
            

            Output output = new Output(patient, appointmentsOut);

            _outputHandler.Handle(output);
        }
    }
}
