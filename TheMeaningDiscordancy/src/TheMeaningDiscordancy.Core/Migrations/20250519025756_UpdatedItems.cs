using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMeaningDiscordancy.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Items");
        }
    }
}
