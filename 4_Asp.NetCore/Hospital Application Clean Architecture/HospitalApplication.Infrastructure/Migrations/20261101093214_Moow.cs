using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Moow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Appointments_AppointmentId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_ElectronicHealthRecords_ElectronicHealthRecordId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicHealthRecordId",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Billings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Appointments_AppointmentId",
                table: "Billings",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_ElectronicHealthRecords_ElectronicHealthRecordId",
                table: "Prescriptions",
                column: "ElectronicHealthRecordId",
                principalTable: "ElectronicHealthRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Appointments_AppointmentId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_ElectronicHealthRecords_ElectronicHealthRecordId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ElectronicHealthRecordId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Appointments_AppointmentId",
                table: "Billings",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_ElectronicHealthRecords_ElectronicHealthRecordId",
                table: "Prescriptions",
                column: "ElectronicHealthRecordId",
                principalTable: "ElectronicHealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
