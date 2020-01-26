using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class SeedMedicalSpecialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MedicalSpecialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a41769f7-7cb0-471d-90d5-54cc2a634694"), "General medicine" },
                    { new Guid("73468716-dba2-48e1-8712-9b90eeb10198"), "Odontology" },
                    { new Guid("fa2b3abc-064b-41db-ad04-9251ae15b5bc"), "Pediatrics" },
                    { new Guid("ed9b53c5-52b7-4fdf-bed5-3efc7593a8d0"), "Neurology" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("73468716-dba2-48e1-8712-9b90eeb10198"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("a41769f7-7cb0-471d-90d5-54cc2a634694"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("ed9b53c5-52b7-4fdf-bed5-3efc7593a8d0"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("fa2b3abc-064b-41db-ad04-9251ae15b5bc"));
        }
    }
}
