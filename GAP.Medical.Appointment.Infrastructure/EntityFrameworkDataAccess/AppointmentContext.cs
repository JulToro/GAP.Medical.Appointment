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
        {}
        public DbSet<Apointmenst.Appointment> Appointment { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicalSpeciality>();
            modelBuilder.Entity<MedicalSpeciality>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<MedicalSpeciality>().HasMany(t => t.Apointments).WithOne(b => b.MedicalSpeciality);
            modelBuilder.Entity<MedicalSpeciality>().HasData(new MedicalSpeciality("General medicine"));
            modelBuilder.Entity<MedicalSpeciality>().HasData(new MedicalSpeciality("Odontology"));
            modelBuilder.Entity<MedicalSpeciality>().HasData(new MedicalSpeciality("Pediatrics"));
            modelBuilder.Entity<MedicalSpeciality>().HasData(new MedicalSpeciality("Neurology"));


            modelBuilder.Entity<Patient>().HasKey(t => t.Id);
            modelBuilder.Entity<Patient>().Property(t => t.DocumentId).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.PhoneNumber).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.Email).IsRequired();
            modelBuilder.Entity<Patient>().HasMany(t => t.Apointments).WithOne(b => b.Patient) ;

            modelBuilder.Entity<Apointmenst.Appointment>();                   
        }
    }
}
