using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
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
                    DocumentId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
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
                    { new Guid("1902e3f0-ca1b-4943-b19a-46f36840bfdc"), "General medicine" },
                    { new Guid("fb347a8f-660b-4c19-8a2f-9670975846b8"), "Odontology" },
                    { new Guid("9bc51ef5-4dfe-4cb3-a6c0-abcf88059adb"), "Pediatrics" },
                    { new Guid("16fffc55-aca2-4fdb-862e-c32acb505920"), "Neurology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalSpecialityId",
                table: "Appointment",
                column: "MedicalSpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");
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
