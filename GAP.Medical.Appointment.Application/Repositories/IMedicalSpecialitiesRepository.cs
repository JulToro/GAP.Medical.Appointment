namespace GAP.Medical.Appointment.Application.Repositories
{
    using GAP.Medical.Appointment.Domain.MedicaSpecialties;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMedicalSpecialitiesRepository
    {
        Task<IMedicalSpeciality> Get(Guid id);
    }
}
