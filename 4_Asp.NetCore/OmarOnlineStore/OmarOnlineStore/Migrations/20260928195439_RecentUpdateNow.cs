using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmarOnlineStore.Migrations
{
    /// <inheritdoc />
    public partial class RecentUpdateNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CardItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "CardItems",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CardItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CardItems");
        }
    }
}
