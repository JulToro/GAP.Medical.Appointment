using GAP.Medical.Appointment.Domain.Appontments;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using GAP.Medical.Appointment.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Apointmenst = GAP.Medical.Appointment.Domain.Appontments;

namespace GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Apointmenst.Appointment> Accounts { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicalSpeciality>();
                
            modelBuilder.Entity<Patient>();

            modelBuilder.Entity<Apointmenst.Appointment>();
                         
            

        }
    }
}
