using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheMeaningDiscordancy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedThemesAndSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    ObjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeedId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeVector_OrderAxis = table.Column<float>(type: "real", nullable: false),
                    ThemeVector_CreationAxis = table.Column<float>(type: "real", nullable: false),
                    ThemeVector_DivineAxis = table.Column<float>(type: "real", nullable: false),
                    ThemeVector_UnityAxis = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.ObjectKey);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ObjectKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ObjectKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seeds");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
