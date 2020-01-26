namespace GAP.Medical.Appointment.Application.Boundaries.RegisterPatient
{
    using Patients = GAP.Medical.Appointment.Domain.Patients;
    public class Input
    {
        public Patients.Patient Patient { get; set; }
        public Input(Patients.Patient patient ) 
        {
            Patient = patient;
        }

    }
}
