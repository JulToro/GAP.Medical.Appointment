using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.Patients;
using System;

namespace GAP.Medical.Appointment.Domain
{
    public class DefaultEntitiesFactory : IEntitiesFactory
    {
        public IAppointment NewAppointment(Guid patientId, Guid medicalSpecialityId, DateTime assignedDate)
        {
            var appoinment = new Appointments.Appointment(patientId, medicalSpecialityId, assignedDate);
            return appoinment;
        }


        public IPatient NewPatient(string documentId, string name, string lastName, string phoneNumber, string email, string userName, string password, DateTime CreationDate, bool IsActive)
        {
            
            var patient = new Patient(documentId,name,lastName,phoneNumber,email, userName,password, CreationDate, IsActive);
            return patient;
        }
    }
}
