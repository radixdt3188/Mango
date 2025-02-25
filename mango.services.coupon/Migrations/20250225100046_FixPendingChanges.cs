using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2025, 2, 25, 15, 30, 45, 744, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2025, 2, 25, 15, 30, 45, 745, DateTimeKind.Local).AddTicks(1556));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2025, 2, 25, 15, 27, 57, 698, DateTimeKind.Local).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2025, 2, 25, 15, 27, 57, 699, DateTimeKind.Local).AddTicks(8019));
        }
    }
}
