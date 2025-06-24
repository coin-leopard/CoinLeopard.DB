using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
	/// <inheritdoc />
	public partial class FuturesPosition_OrderId_NotNull : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<long>(
				name: "OrderId",
				table: "FuturesPositions",
				type: "bigint",
				nullable: false,
				defaultValue: 0L,
				oldClrType: typeof(long),
				oldType: "bigint",
				oldNullable: true
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<long>(
				name: "OrderId",
				table: "FuturesPositions",
				type: "bigint",
				nullable: true,
				oldClrType: typeof(long),
				oldType: "bigint"
			);
		}
	}
}
