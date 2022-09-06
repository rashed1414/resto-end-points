using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantEndPoints.Migrations
{
    public partial class StaffTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Staffs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Staffs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Staffs",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Staffs");
        }
    }
}
