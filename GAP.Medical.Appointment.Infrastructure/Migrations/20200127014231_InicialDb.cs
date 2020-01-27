using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class InicialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalSpecialities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    MedicalSpecialityId = table.Column<Guid>(nullable: false),
                    AssignedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_MedicalSpecialities_MedicalSpecialityId",
                        column: x => x.MedicalSpecialityId,
                        principalTable: "MedicalSpecialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedicalSpecialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3c61c70d-c19c-4406-81d8-8ca727c42ae4"), "General medicine" },
                    { new Guid("60bdf46a-d713-429a-beb7-2854deb6a7ef"), "Odontology" },
                    { new Guid("05a3d2af-0c70-4837-91a5-e0b4e723cafd"), "Pediatrics" },
                    { new Guid("33f99666-e12f-49c0-83d2-677527225334"), "Neurology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalSpecialityId",
                table: "Appointment",
                column: "MedicalSpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DocumentId",
                table: "Patients",
                column: "DocumentId",
                unique: true,
                filter: "[DocumentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Username",
                table: "Patients",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "MedicalSpecialities");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
