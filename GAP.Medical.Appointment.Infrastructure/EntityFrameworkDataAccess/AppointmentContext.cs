using GAP.Medical.Appointment.Domain.Appointments;
using GAP.Medical.Appointment.Domain.MedicaSpecialties;
using GAP.Medical.Appointment.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Apointmenst = GAP.Medical.Appointment.Domain.Appointments;

namespace GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Apointmenst.Appointment> Appointment { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicalSpecialty>();
            modelBuilder.Entity<MedicalSpecialty>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<MedicalSpecialty>().HasMany(t => t.Appointments).WithOne(b => b.MedicalSpecialty);
            modelBuilder.Entity<MedicalSpecialty>().HasData(new MedicalSpecialty("General medicine"));
            modelBuilder.Entity<MedicalSpecialty>().HasData(new MedicalSpecialty("Odontology"));
            modelBuilder.Entity<MedicalSpecialty>().HasData(new MedicalSpecialty("Pediatrics"));
            modelBuilder.Entity<MedicalSpecialty>().HasData(new MedicalSpecialty("Neurology"));


            modelBuilder.Entity<Patient>().HasKey(t => t.Id);
            modelBuilder.Entity<Patient>().HasIndex(b => b.DocumentId).IsUnique();
            modelBuilder.Entity<Patient>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.LastName).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.PhoneNumber).IsRequired();
            modelBuilder.Entity<Patient>().Property(t => t.Email).IsRequired();
            modelBuilder.Entity<Patient>().HasIndex(b => b.Username).IsUnique();
            modelBuilder.Entity<Patient>().Property(t => t.Password).IsRequired();
            modelBuilder.Entity<Patient>().HasMany(t => t.Appointments).WithOne(b => b.Patient) ;
            modelBuilder.Entity<Patient>().HasData(new Patient("1234","Julian","Toro","310438018","juliantvi@gm.com","juliantoro","clave123",DateTime.Now,true));

            modelBuilder.Entity<Apointmenst.Appointment>();                   
        }
    }
}
