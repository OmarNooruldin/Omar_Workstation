using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Migrations
{
    /// <inheritdoc />
    public partial class NowNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "symptoms",
                table: "ElectronicHealthRecords",
                newName: "Symptoms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Symptoms",
                table: "ElectronicHealthRecords",
                newName: "symptoms");
        }
    }
}
