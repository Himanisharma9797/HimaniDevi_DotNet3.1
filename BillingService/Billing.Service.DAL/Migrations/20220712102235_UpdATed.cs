using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.Service.DAL.Migrations
{
    public partial class UpdATed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "CompletedHours",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "EndDuration",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "StartDuration",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "TitleOfTaskToBeBilled",
                table: "Amounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Amounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Amounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "CompletedHours",
                table: "Amounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDuration",
                table: "Amounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDuration",
                table: "Amounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TitleOfTaskToBeBilled",
                table: "Amounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Amounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
