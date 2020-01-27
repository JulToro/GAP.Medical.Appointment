using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("05a3d2af-0c70-4837-91a5-e0b4e723cafd"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("33f99666-e12f-49c0-83d2-677527225334"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("3c61c70d-c19c-4406-81d8-8ca727c42ae4"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("60bdf46a-d713-429a-beb7-2854deb6a7ef"));

            migrationBuilder.InsertData(
                table: "MedicalSpecialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ad43a406-1c6e-4aaa-98e0-635d50a01525"), "General medicine" },
                    { new Guid("e159d627-69c9-4dd6-ba3a-00e8eb8b2320"), "Odontology" },
                    { new Guid("8c1c6fc1-fdb5-4797-abdf-bbd5d7330de6"), "Pediatrics" },
                    { new Guid("6c0fa8ea-a4d5-4e77-95aa-a2462296df58"), "Neurology" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "CreationDate", "DocumentId", "Email", "IsActive", "LastName", "Name", "Password", "PhoneNumber", "Username" },
                values: new object[] { new Guid("8234096d-a811-454c-9e13-abaf4617400d"), new DateTime(2020, 1, 26, 23, 6, 42, 293, DateTimeKind.Local).AddTicks(5564), "1234", "juliantvi@gm.com", true, "Toro", "Julian", "clave123", "310438018", "juliantoro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("6c0fa8ea-a4d5-4e77-95aa-a2462296df58"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("8c1c6fc1-fdb5-4797-abdf-bbd5d7330de6"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("ad43a406-1c6e-4aaa-98e0-635d50a01525"));

            migrationBuilder.DeleteData(
                table: "MedicalSpecialities",
                keyColumn: "Id",
                keyValue: new Guid("e159d627-69c9-4dd6-ba3a-00e8eb8b2320"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("8234096d-a811-454c-9e13-abaf4617400d"));

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
        }
    }
}
