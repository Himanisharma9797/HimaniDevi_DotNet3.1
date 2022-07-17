using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Service.DAL.Migrations
{
    public partial class Last132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Amounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Amounts");
        }
    }
}
