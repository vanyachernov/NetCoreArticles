using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetCoreArticles.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoleImplemention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("241f922d-5776-4fa3-af72-ee74a39294bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6191e5e-0a5c-4bea-8e61-e10fcc3da245"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(3970),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(440),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("27488e9b-f2a2-4219-953c-221422425978"), null, "The creator role for the user", "Creator", "CREATOR" },
                    { new Guid("8fe9b3b0-ba6a-45f5-ad13-cd9c17bf252f"), null, "The admin role for the user", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("27488e9b-f2a2-4219-953c-221422425978"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fe9b3b0-ba6a-45f5-ad13-cd9c17bf252f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(6910),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(3340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 14, 19, 27, 45, 606, DateTimeKind.Utc).AddTicks(3160),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 14, 19, 29, 27, 290, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("241f922d-5776-4fa3-af72-ee74a39294bf"), null, "The creator role for the user", "Creator", "CREATOR" },
                    { new Guid("a6191e5e-0a5c-4bea-8e61-e10fcc3da245"), null, "The admin role for the user", "Admin", "ADMIN" }
                });
        }
    }
}
