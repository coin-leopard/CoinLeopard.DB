using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AssetValueEntityContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetValueEntry",
                table: "AssetValueEntry");

            migrationBuilder.RenameTable(
                name: "AssetValueEntry",
                newName: "AssetValueEntries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetValueEntries",
                table: "AssetValueEntries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetValueEntries",
                table: "AssetValueEntries");

            migrationBuilder.RenameTable(
                name: "AssetValueEntries",
                newName: "AssetValueEntry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetValueEntry",
                table: "AssetValueEntry",
                column: "Id");
        }
    }
}
