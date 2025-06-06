using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMeaningDiscordancy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageDataObjectKey",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ImageData",
                columns: table => new
                {
                    ObjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageData", x => x.ObjectKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImageDataObjectKey",
                table: "Items",
                column: "ImageDataObjectKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ImageData_ImageDataObjectKey",
                table: "Items",
                column: "ImageDataObjectKey",
                principalTable: "ImageData",
                principalColumn: "ObjectKey",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ImageData_ImageDataObjectKey",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_Items_ImageDataObjectKey",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ImageDataObjectKey",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
