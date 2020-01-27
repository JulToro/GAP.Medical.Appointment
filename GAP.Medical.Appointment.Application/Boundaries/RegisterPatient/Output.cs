namespace GAP.Medical.Appointment.Application.Boundaries.RegisterPatient
{
    using GAP.Medical.Appointment.Domain.Patients;
    public class Output
    {
        public Patient _patient { get; set; }
        public Output(IPatient patient)
        {            
            _patient = new Patient(patient);
        }
    }
}
