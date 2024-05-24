using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserKepenk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sliderViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Sliders",
                newName: "PictureFile");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 17, 0, 19, 43, 841, DateTimeKind.Local).AddTicks(7564));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Sliders");

            migrationBuilder.RenameColumn(
                name: "PictureFile",
                table: "Sliders",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "AccountUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 5, 16, 22, 1, 31, 447, DateTimeKind.Local).AddTicks(7610));
        }
    }
}
