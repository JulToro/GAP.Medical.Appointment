using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.Patients;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Apointments = GAP.Medical.Appointment.Domain.Appointments;

namespace GAP.Medical.Appointment.AcceptaceTest.EntitiesTest
{
    public class AppointmentTest
    {
        [Fact]
        public void New_Appointment()
        {
            List<IAppointment> appointments = new List<IAppointment>();

            Guid patientId1 = new Guid();
            Guid medialId1 = new Guid();
            IAppointment appointment1 = new Apointments.Appointment(patientId1, medialId1, DateTime.Now.AddDays(1));

            appointments.Add(appointment1);

            Guid patientId2 = new Guid();
            Guid medialId2 = new Guid();
            IAppointment appointment2 = new Apointments.Appointment(patientId2, medialId2, DateTime.Now.AddDays(1));
            appointments.Add(appointment2);


            Guid patientId3 = new Guid();
            Guid medialId3 = new Guid();
            IAppointment appointment3 = new Apointments.Appointment(patientId3, medialId3, DateTime.Now.AddDays(1));
            appointments.Add(appointment3);


            Guid patientId = new Guid();
            Guid medialId = new Guid();
            IAppointment appointmentTeset = new Apointments.Appointment(patientId, medialId, DateTime.Now.AddDays(-1));
            appointments.Add(appointmentTeset);

            
             Assert.False(appointmentTeset.ValidateAvailabilityDate(appointments));
             Assert.True(appointment3.ValidateAvailabilityDate(appointments));

        }
    }
}
