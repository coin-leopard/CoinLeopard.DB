using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "CryptoCurrencies",
				columns: table =>
					new
					{
						Code = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
						Name = table.Column<string>(type: "text", nullable: false)
					},
				constraints: table =>
				{
					table.PrimaryKey("PK_CryptoCurrencies", x => x.Code);
				}
			);

			migrationBuilder.CreateTable(
				name: "CryptoPairs",
				columns: table =>
					new
					{
						Id = table.Column<Guid>(type: "uuid", nullable: false),
						Left = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
						Right = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
						Value = table.Column<decimal>(type: "numeric", nullable: false)
					},
				constraints: table =>
				{
					table.PrimaryKey("PK_CryptoPairs", x => x.Id);
					table.ForeignKey(
						name: "FK_CryptoPairs_CryptoCurrencies_Left",
						column: x => x.Left,
						principalTable: "CryptoCurrencies",
						principalColumn: "Code",
						onDelete: ReferentialAction.Cascade
					);
					table.ForeignKey(
						name: "FK_CryptoPairs_CryptoCurrencies_Right",
						column: x => x.Right,
						principalTable: "CryptoCurrencies",
						principalColumn: "Code",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable(
				name: "CryptoPairTrends",
				columns: table =>
					new
					{
						Id = table.Column<Guid>(type: "uuid", nullable: false),
						UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
						TrendValue = table.Column<decimal>(type: "numeric", nullable: false),
						CryptoPairId = table.Column<Guid>(type: "uuid", nullable: false)
					},
				constraints: table =>
				{
					table.PrimaryKey("PK_CryptoPairTrends", x => x.Id);
					table.ForeignKey(
						name: "FK_CryptoPairTrends_CryptoPairs_CryptoPairId",
						column: x => x.CryptoPairId,
						principalTable: "CryptoPairs",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateTable(
				name: "FuturesPositions",
				columns: table =>
					new
					{
						Id = table.Column<Guid>(type: "uuid", nullable: false),
						Capital = table.Column<decimal>(type: "numeric", nullable: false),
						Type = table.Column<int>(type: "integer", nullable: false),
						CryptoPairId = table.Column<Guid>(type: "uuid", nullable: false)
					},
				constraints: table =>
				{
					table.PrimaryKey("PK_FuturesPositions", x => x.Id);
					table.ForeignKey(
						name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
						column: x => x.CryptoPairId,
						principalTable: "CryptoPairs",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade
					);
				}
			);

			migrationBuilder.CreateIndex(name: "IX_CryptoPairs_Left", table: "CryptoPairs", column: "Left");

			migrationBuilder.CreateIndex(name: "IX_CryptoPairs_Right", table: "CryptoPairs", column: "Right");

			migrationBuilder.CreateIndex(name: "IX_CryptoPairTrends_CryptoPairId", table: "CryptoPairTrends", column: "CryptoPairId");

			migrationBuilder.CreateIndex(name: "IX_FuturesPositions_CryptoPairId", table: "FuturesPositions", column: "CryptoPairId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(name: "CryptoPairTrends");

			migrationBuilder.DropTable(name: "FuturesPositions");

			migrationBuilder.DropTable(name: "CryptoPairs");

			migrationBuilder.DropTable(name: "CryptoCurrencies");
		}
	}
}
