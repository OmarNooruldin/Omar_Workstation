using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmarOnlineStore.Migrations
{
    /// <inheritdoc />
    public partial class RecentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CardItems_CardItemId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CardItemId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CardItemId",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardItemId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CardItemId",
                table: "Customers",
                column: "CardItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CardItems_CardItemId",
                table: "Customers",
                column: "CardItemId",
                principalTable: "CardItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
