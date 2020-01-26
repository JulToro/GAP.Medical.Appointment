using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Medical.Appointment.Infrastructure.Migrations
{
    public partial class Modificacion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalSpecialities_MedicalSpecialityId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "MedicalSpecialtyId",
                table: "Appointment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalSpecialityId",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalSpecialities_MedicalSpecialityId",
                table: "Appointment",
                column: "MedicalSpecialityId",
                principalTable: "MedicalSpecialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalSpecialities_MedicalSpecialityId",
                table: "Appointment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalSpecialityId",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicalSpecialtyId",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalSpecialities_MedicalSpecialityId",
                table: "Appointment",
                column: "MedicalSpecialityId",
                principalTable: "MedicalSpecialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
