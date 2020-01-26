
using GAP.Medical.Appointment.Application.Boundaries.CancelAppointment;
using GAP.Medical.Appointment.Application.Repositories;
using GAP.Medical.Appointment.Application.Services;
using GAP.Medical.Appointment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases
{
    public class CancelAppointment: IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IMedicalSpecialitiesRepository _iMedicalSpecialitiesRepository;
        private readonly IUnitOfWork _unityOfWork;
        public CancelAppointment(IPatientRepository iPatientRepository,
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
            var appointment = await _iAppointmentReporsitory.Get(input.AppointmentId);

            if (appointment.Count() == 0)
            {
                _outputHandler.Error("The appointment doesn't exist");
                return;
            }

            await _iAppointmentReporsitory.Delete(appointment.FirstOrDefault());
            await _unityOfWork.Save();

            Output output = new Output(true);
            _outputHandler.Handle(output);
        }
    }
}
