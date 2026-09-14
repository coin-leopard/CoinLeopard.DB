using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Ticks.Migrations
{
    /// <inheritdoc />
    public partial class KlinesIntervalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterRetentionPolicy(
                tableName: "KlineTicks",
                schema: "public",
                dropAfter: "1 day",
                scheduleInterval: "1 day",
                maxRuntime: "00:00:00",
                maxRetries: -1,
                retryPeriod: "1 day",
                oldDropAfter: "30 days",
                oldScheduleInterval: "1 day",
                oldMaxRuntime: "00:00:00",
                oldMaxRetries: -1,
                oldRetryPeriod: "1 day");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterRetentionPolicy(
                tableName: "KlineTicks",
                schema: "public",
                dropAfter: "30 days",
                scheduleInterval: "1 day",
                maxRuntime: "00:00:00",
                maxRetries: -1,
                retryPeriod: "1 day",
                oldDropAfter: "1 day",
                oldScheduleInterval: "1 day",
                oldMaxRuntime: "00:00:00",
                oldMaxRetries: -1,
                oldRetryPeriod: "1 day");
        }
    }
}
