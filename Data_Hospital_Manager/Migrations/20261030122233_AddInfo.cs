using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Казанлък", 200, new DateTime(2026, 10, 30, 14, 22, 33, 678, DateTimeKind.Local).AddTicks(6183), "mbalkazanlak@mail.bg", false, "МБАЛ Казанлък", "0899823296" },
                    { 2, "Стара Загора", 150, new DateTime(2026, 10, 30, 14, 22, 33, 678, DateTimeKind.Local).AddTicks(6222), "mbalstz@mail.bg", false, "МБАЛ Стара Загора", "0899823294" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
