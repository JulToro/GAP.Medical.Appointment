using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess
{
    public class ContextFactory
    {
        public AppointmentContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();

            var builder = new DbContextOptionsBuilder<AppointmentContext>();
            builder.UseSqlServer(connectionString);
            return new AppointmentContext(builder.Options);
        }

        private string ReadDefaultConnectionStringFromAppSettings()
        {
            
            string connectionString = "Data Source = DESKTOPJTORO\\Julian; Initial Catalog = BaseDatos; Integrated Security = True";
            return connectionString;
        }
    }
}
