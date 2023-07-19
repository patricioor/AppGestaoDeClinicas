using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class corrigindoclasseuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbUsers_Functions_FunctionId",
                table: "DbUsers");

            migrationBuilder.DropIndex(
                name: "IX_DbUsers_FunctionId",
                table: "DbUsers");

            migrationBuilder.DropColumn(
                name: "FunctionId",
                table: "DbUsers");

            migrationBuilder.CreateTable(
                name: "FunctionUser",
                columns: table => new
                {
                    FunctionsId = table.Column<int>(type: "int", nullable: false),
                    UsersLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionUser", x => new { x.FunctionsId, x.UsersLogin });
                    table.ForeignKey(
                        name: "FK_FunctionUser_DbUsers_UsersLogin",
                        column: x => x.UsersLogin,
                        principalTable: "DbUsers",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionUser_Functions_FunctionsId",
                        column: x => x.FunctionsId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunctionUser_UsersLogin",
                table: "FunctionUser",
                column: "UsersLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionUser");

            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "DbUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbUsers_FunctionId",
                table: "DbUsers",
                column: "FunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbUsers_Functions_FunctionId",
                table: "DbUsers",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id");
        }
    }
}
