using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Service.DAL.Migrations
{
    public partial class thirdfMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Amounts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CompletedHours",
                table: "Amounts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Amounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "CompletedHours",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Amounts");
        }
    }
}
