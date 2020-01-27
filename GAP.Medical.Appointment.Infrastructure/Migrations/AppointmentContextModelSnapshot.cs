﻿// <auto-generated />
using System;
using GAP.Medical.Appointment.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    [DbContext(typeof(AppointmentContext))]
    partial class AppointmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GAP.Medical.Appointment.Domain.Appointments.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MedicalSpecialityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicalSpecialityId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("GAP.Medical.Appointment.Domain.MedicaSpecialties.MedicalSpeciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalSpecialities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad43a406-1c6e-4aaa-98e0-635d50a01525"),
                            Name = "General medicine"
                        },
                        new
                        {
                            Id = new Guid("e159d627-69c9-4dd6-ba3a-00e8eb8b2320"),
                            Name = "Odontology"
                        },
                        new
                        {
                            Id = new Guid("8c1c6fc1-fdb5-4797-abdf-bbd5d7330de6"),
                            Name = "Pediatrics"
                        },
                        new
                        {
                            Id = new Guid("6c0fa8ea-a4d5-4e77-95aa-a2462296df58"),
                            Name = "Neurology"
                        });
                });

            modelBuilder.Entity("GAP.Medical.Appointment.Domain.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId")
                        .IsUnique()
                        .HasFilter("[DocumentId] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8234096d-a811-454c-9e13-abaf4617400d"),
                            CreationDate = new DateTime(2020, 1, 26, 23, 6, 42, 293, DateTimeKind.Local).AddTicks(5564),
                            DocumentId = "1234",
                            Email = "juliantvi@gm.com",
                            IsActive = true,
                            LastName = "Toro",
                            Name = "Julian",
                            Password = "clave123",
                            PhoneNumber = "310438018",
                            Username = "juliantoro"
                        });
                });

            modelBuilder.Entity("GAP.Medical.Appointment.Domain.Appointments.Appointment", b =>
                {
                    b.HasOne("GAP.Medical.Appointment.Domain.MedicaSpecialties.MedicalSpeciality", "MedicalSpeciality")
                        .WithMany("Apointments")
                        .HasForeignKey("MedicalSpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GAP.Medical.Appointment.Domain.Patients.Patient", "Patient")
                        .WithMany("Apointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
