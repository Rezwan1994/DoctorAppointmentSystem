using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("764fd5d4-fa02-4c0e-bd6c-675b26c74a1e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc9538f5-c8ce-4938-9545-e1ae1e3ad287"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4decef3e-e855-4d9a-9d66-2a85d81a418e"), "638054938705884900", "Admin", "ADMIN" },
                    { new Guid("e2e4aa0b-3530-4126-92c7-0a3e9502d407"), "638054939305884929", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4decef3e-e855-4d9a-9d66-2a85d81a418e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2e4aa0b-3530-4126-92c7-0a3e9502d407"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("764fd5d4-fa02-4c0e-bd6c-675b26c74a1e"), "638053201646141549", "Admin", "ADMIN" },
                    { new Guid("dc9538f5-c8ce-4938-9545-e1ae1e3ad287"), "638053202246141597", "Customer", "CUSTOMER" }
                });
        }
    }
}
