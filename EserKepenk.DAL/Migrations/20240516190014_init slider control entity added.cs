using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserKepenk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initslidercontrolentityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 16, 22, 0, 13, 573, DateTimeKind.Local).AddTicks(4146));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 16, 21, 24, 29, 916, DateTimeKind.Local).AddTicks(2238));
        }
    }
}
