using GAP.Medical.Appointment.Domain.Appontments;
using GAP.Medical.Appointment.Domain.Patients;
using System;

namespace GAP.Medical.Appointment.Domain
{
    public class DefaultEntitiesFactory : IEntitiesFactory
    {
        public IAppointment NewAppointment(Guid patientId, Guid medicalSpecialtyId, DateTime assignedDate)
        {
            var appoinment = new Appontments.Appointment(patientId, medicalSpecialtyId, assignedDate);
            return appoinment;
        }


        public IPatient NewPatient(string documentId, string name, string lastName, string phoneNumber, string email)
        {
            var patient = new Patient(documentId,name,lastName,phoneNumber,email);
            return patient;
        }
    }
}
