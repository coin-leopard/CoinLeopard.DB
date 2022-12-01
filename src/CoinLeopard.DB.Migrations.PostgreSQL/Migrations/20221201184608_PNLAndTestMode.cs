using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    public partial class PNLAndTestMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientOrderId",
                table: "FuturesPositions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PNL",
                table: "FuturesPositions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "TestMode",
                table: "FuturesPositions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientOrderId",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "PNL",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "TestMode",
                table: "FuturesPositions");
        }
    }
}
