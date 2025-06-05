using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMeaningDiscordancy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Themes",
                table: "Themes");

            migrationBuilder.RenameTable(
                name: "Themes",
                newName: "ThemeEfc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThemeEfc",
                table: "ThemeEfc",
                column: "ObjectKey");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeEfc_ThemeId",
                table: "ThemeEfc",
                column: "ThemeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThemeEfc",
                table: "ThemeEfc");

            migrationBuilder.DropIndex(
                name: "IX_ThemeEfc_ThemeId",
                table: "ThemeEfc");

            migrationBuilder.RenameTable(
                name: "ThemeEfc",
                newName: "Themes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Themes",
                table: "Themes",
                column: "ObjectKey");
        }
    }
}
