using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Migrations
{
    public partial class TrxDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountName",
                table: "Bills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bills",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bills");
        }
    }
}
