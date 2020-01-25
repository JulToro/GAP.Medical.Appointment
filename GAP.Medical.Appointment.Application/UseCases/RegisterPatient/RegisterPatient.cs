using GAP.Medical.Appointment.Application.RegisterPatient.UseCases;
using GAP.Medical.Appointment.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Medical.Appointment.Application.UseCases.RegisterPatient
{
    public class RegisterPatient : IUseCase
    {
        private readonly IPatientRepository _patientRepository;
        public RegisterPatient(IPatientRepository iPatientRepository)
        {
            _patientRepository = iPatientRepository;
        }

        public Task Execute(Input input)
        {

            throw new NotImplementedException();
        }
    }
}
