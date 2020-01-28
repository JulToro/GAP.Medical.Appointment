using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain.Patients
{
    public class Patient : IPatient
    {
        public Guid Id { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsActive { get; set; }



        public virtual ICollection<Appointment.Domain.Appointments.Appointment> Appointments { get; set; }
        public IReadOnlyCollection<Guid> AppointmentIds
        {
            get
            {
                IReadOnlyCollection<Guid> readOnly = _appoinments.GetAppoinmentIds();
                return readOnly;
            }
        }

        private AppointmentsCollection _appoinments = new AppointmentsCollection();
        public Patient() { }
        public Patient(string documentId, string name, string lastName, string phoneNumber, string email, string userName, string password, DateTime creationDate, bool isActive)
        {
            Id = Guid.NewGuid();
            DocumentId = documentId;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Username = userName;
            Password = password;
            CreationDate = creationDate;
            IsActive = isActive;
        }

        public void RegisterAppoinment(Guid appointmentId)
        {
            //   _appoinments.Add(appointmentId);
        }

        public void LoadAppoinments(ICollection<Guid> appoinmentIds)
        {
            // _appoinments = new AppointmentsCollection();
            // foreach (var account in appoinmentIds)
            //   _appoinments.Add(account);
        }
    }
}
