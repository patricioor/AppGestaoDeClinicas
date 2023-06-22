using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class Testeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DentistsCellphones_Dentists_DentistId",
                table: "DentistsCellphones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DentistsCellphones",
                table: "DentistsCellphones");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "DentistsCellphones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "DentistsCellphones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DentistId",
                table: "DentistsCellphones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DentistsCellphones",
                table: "DentistsCellphones",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_DentistsCellphones_DentistId1",
                table: "DentistsCellphones",
                column: "DentistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DentistsCellphones_Dentists_DentistId1",
                table: "DentistsCellphones",
                column: "DentistId1",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DentistsCellphones_Dentists_DentistId1",
                table: "DentistsCellphones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DentistsCellphones",
                table: "DentistsCellphones");

            migrationBuilder.DropIndex(
                name: "IX_DentistsCellphones_DentistId1",
                table: "DentistsCellphones");

            migrationBuilder.DropColumn(
                name: "DentistId1",
                table: "DentistsCellphones");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "DentistsCellphones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DentistId",
                table: "DentistsCellphones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DentistsCellphones",
                table: "DentistsCellphones",
                columns: new[] { "DentistId", "Number" });

            migrationBuilder.AddForeignKey(
                name: "FK_DentistsCellphones_Dentists_DentistId",
                table: "DentistsCellphones",
                column: "DentistId",
                principalTable: "Dentists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
