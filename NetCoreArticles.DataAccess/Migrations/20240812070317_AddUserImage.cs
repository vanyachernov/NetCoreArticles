using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreArticles.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Articles_ArticleId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ArticleImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(8660),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(4290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(4070),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleImages",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateTable(
                name: "UsersImages",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersImages", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UsersImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleImages_Articles_ArticleId",
                table: "ArticleImages");

            migrationBuilder.DropTable(
                name: "UsersImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleImages",
                table: "ArticleImages");

            migrationBuilder.RenameTable(
                name: "ArticleImages",
                newName: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Likes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(7580),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(5150),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(4980),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 8, 12, 7, 3, 17, 508, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Articles_ArticleId",
                table: "Images",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
