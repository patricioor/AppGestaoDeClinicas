using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class NovaComposiçãoValidadorCustomerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Responsibles_ResponsibleId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responsibles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responsibles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Birth",
                table: "Customers",
                newName: "BirthDay");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Responsibles_ResponsibleId",
                table: "Customers",
                column: "ResponsibleId",
                principalTable: "Responsibles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Responsibles_ResponsibleId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "Customers",
                newName: "Birth");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Limpeza" },
                    { 2, "Descartáveis" }
                });

            migrationBuilder.InsertData(
                table: "Employments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sócio" },
                    { 2, "Prestador de Serviço" }
                });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Patricio Osterno Rios" },
                    { 2, "Teste Testerson da Silva" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Responsibles_ResponsibleId",
                table: "Customers",
                column: "ResponsibleId",
                principalTable: "Responsibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
