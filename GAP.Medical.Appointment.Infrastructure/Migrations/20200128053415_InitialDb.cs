using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialties", x => x.Id);
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
                    MedicalSpecialtyId = table.Column<Guid>(nullable: false),
                    AssignedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
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
                table: "MedicalSpecialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b56a0a81-7d1e-4ae6-ab97-34d66807c314"), "General medicine" },
                    { new Guid("f4ab8317-d992-4bf5-81e2-2e0b24d6c8f7"), "Odontology" },
                    { new Guid("f992b696-d234-45cb-a7be-9a86129289d7"), "Pediatrics" },
                    { new Guid("5b1f17f3-0e0e-4f09-82fd-21688472aead"), "Neurology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "CreationDate", "DocumentId", "Email", "IsActive", "LastName", "Name", "Password", "PhoneNumber", "Username" },
                values: new object[] { new Guid("5d08a8eb-bc49-49b0-9a47-aadbb4ca94c1"), new DateTime(2020, 1, 28, 0, 34, 14, 773, DateTimeKind.Local).AddTicks(8369), "1234", "juliantvi@gm.com", true, "Toro", "Julian", "clave123", "310438018", "juliantoro" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalSpecialtyId",
                table: "Appointment",
                column: "MedicalSpecialtyId");

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
                name: "MedicalSpecialties");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
