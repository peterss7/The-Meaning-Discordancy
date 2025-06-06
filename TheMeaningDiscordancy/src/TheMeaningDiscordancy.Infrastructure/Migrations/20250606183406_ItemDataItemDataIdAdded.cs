using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMeaningDiscordancy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemDataItemDataIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Seeds");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageDataObjectKey",
                table: "Seeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ImageDataId",
                table: "ImageData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seeds_ImageDataObjectKey",
                table: "Seeds",
                column: "ImageDataObjectKey");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_ImageDataId",
                table: "ImageData",
                column: "ImageDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seeds_ImageData_ImageDataObjectKey",
                table: "Seeds",
                column: "ImageDataObjectKey",
                principalTable: "ImageData",
                principalColumn: "ObjectKey",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seeds_ImageData_ImageDataObjectKey",
                table: "Seeds");

            migrationBuilder.DropIndex(
                name: "IX_Seeds_ImageDataObjectKey",
                table: "Seeds");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_ImageDataId",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "ImageDataObjectKey",
                table: "Seeds");

            migrationBuilder.DropColumn(
                name: "ImageDataId",
                table: "ImageData");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Seeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
