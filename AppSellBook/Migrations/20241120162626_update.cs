using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSellBook.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "author",
            //    table: "Books");

            //migrationBuilder.AddColumn<double>(
            //    name: "ranK",
            //    table: "Commentations",
            //    type: "double",
            //    nullable: false,
            //    defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "publisher",
                table: "Books",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "authorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    authorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Books_authorId",
                table: "Books",
                column: "authorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books",
                column: "authorId",
                principalTable: "Authors",
                principalColumn: "authorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Books_authorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ranK",
                table: "Commentations");

            migrationBuilder.DropColumn(
                name: "authorId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "publisher",
                keyValue: null,
                column: "publisher",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "publisher",
                table: "Books",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "Books",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
