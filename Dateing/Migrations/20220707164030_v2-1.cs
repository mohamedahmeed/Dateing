using Microsoft.EntityFrameworkCore.Migrations;

namespace Dateing.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "knownas",
                table: "Users",
                newName: "KnownAs");

            migrationBuilder.RenameColumn(
                name: "introduction",
                table: "Users",
                newName: "Introduction");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Users",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Lookingfor",
                table: "Users",
                newName: "LookingFor");

            migrationBuilder.RenameColumn(
                name: "createdAccount",
                table: "Users",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "BrithDay",
                table: "Users",
                newName: "Created");

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "LookingFor",
                table: "Users",
                newName: "Lookingfor");

            migrationBuilder.RenameColumn(
                name: "KnownAs",
                table: "Users",
                newName: "knownas");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Users",
                newName: "introduction");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "createdAccount");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Users",
                newName: "BrithDay");
        }
    }
}
