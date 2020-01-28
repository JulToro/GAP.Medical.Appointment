
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
        private readonly IOutputHandler _outputHandler;
        private readonly IAppointmentReporsitory _iAppointmentReporsitory;
        private readonly IUnitOfWork _unityOfWork;
        public CancelAppointment(
                               IAppointmentReporsitory iAppointmentReporsitory,
                               IOutputHandler outputHandler,
                               IUnitOfWork unityOfWork
                               )
        {
            _iAppointmentReporsitory = iAppointmentReporsitory;
            _outputHandler = outputHandler;
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

            if (!appointment.ToList().FirstOrDefault().ValidateCancelation())
            {
                _outputHandler.Error("The appointment cannot be canceled");
                return;
            }


            await _iAppointmentReporsitory.Delete(appointment.FirstOrDefault());
            await _unityOfWork.Save();

            Output output = new Output(true);
            _outputHandler.Handle(output);
        }
    }
}
