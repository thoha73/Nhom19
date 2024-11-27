using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSellBook.Migrations
{
    /// <inheritdoc />
    public partial class uploa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RoleUser",
                newName: "rolesroleId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RoleUser",
                newName: "usersuserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser",
                newName: "IX_RoleUser_rolesroleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_rolesroleId",
                table: "RoleUser",
                column: "rolesroleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_usersuserId",
                table: "RoleUser",
                column: "usersuserId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_rolesroleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_usersuserId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "rolesroleId",
                table: "RoleUser",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "usersuserId",
                table: "RoleUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_rolesroleId",
                table: "RoleUser",
                newName: "IX_RoleUser_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RoleId",
                table: "RoleUser",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UserId",
                table: "RoleUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
