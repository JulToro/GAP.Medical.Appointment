using System;
using System.Collections.Generic;
using System.Text;
using Appinments = GAP.Medical.Appointment.Domain.Appontments;

namespace GAP.Medical.Appointment.Application.UseCases.CreateAppoinment
{
    public class Input
    {
        public Appinments.Appointment Patient { get; set; }
        public Input(Appinments.Appointment patient)
        {
            Patient = patient;
        }

    }
}
