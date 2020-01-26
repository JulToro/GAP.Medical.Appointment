using System;
using System.Collections.Generic;
using System.Text;
using Appointments = GAP.Medical.Appointment.Domain.Appontments;

namespace GAP.Medical.Appointment.Application.UseCases.CreateAppoinment
{
    public class Input
    {
        public Appointments.Appointment Patient { get; set; }
        public Input(Appointments.Appointment patient)
        {
            Patient = patient;
        }

    }
}
