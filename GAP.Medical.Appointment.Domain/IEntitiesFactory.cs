using GAP.Medical.Appointment.Domain.Appontments;
using GAP.Medical.Appointment.Domain.Patients;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain
{
    public interface IEntitiesFactory
    {
        IPatient NewPatient(string documentId, string name, string lastName, string phoneNumber, string email);
        IAppointment NewAppointment(Guid patientId, Guid medicalSpecialtyId, DateTime assignedDate);
    }
}
