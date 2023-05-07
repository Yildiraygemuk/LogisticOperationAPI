using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticCompany.DataAccess.Migrations
{
    public partial class userUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "PsrHash",
                table: "User",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PsrSalt",
                table: "User",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PsrHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PsrSalt",
                table: "User");
        }
    }
}
