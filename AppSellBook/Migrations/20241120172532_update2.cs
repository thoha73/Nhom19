using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSellBook.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "cardDetailId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "cardId",
                table: "CartDetails",
                newName: "cartDetailId");

            migrationBuilder.AlterColumn<int>(
                name: "cartDetailId",
                table: "CartDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails",
                column: "cartDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "cartDetailId",
                table: "CartDetails",
                newName: "cardId");

            migrationBuilder.AlterColumn<int>(
                name: "cardId",
                table: "CartDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "cardDetailId",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails",
                column: "cardDetailId");
        }
    }
}
