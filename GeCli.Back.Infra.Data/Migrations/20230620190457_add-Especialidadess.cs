using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class addEspecialidadess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Cellphones");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Dentists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Dentists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Dentists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Dentists",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Dentists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "CustomersAdresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersAdresses", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomersAdresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersCellphones",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersCellphones", x => new { x.CustomerId, x.Number });
                    table.ForeignKey(
                        name: "FK_CustomersCellphones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DentistsAdresses",
                columns: table => new
                {
                    DentistId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistsAdresses", x => x.DentistId);
                    table.ForeignKey(
                        name: "FK_DentistsAdresses_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DentistsCellphones",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DentistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistsCellphones", x => new { x.DentistId, x.Number });
                    table.ForeignKey(
                        name: "FK_DentistsCellphones_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersAdresses");

            migrationBuilder.DropTable(
                name: "CustomersCellphones");

            migrationBuilder.DropTable(
                name: "DentistsAdresses");

            migrationBuilder.DropTable(
                name: "DentistsCellphones");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Dentists");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Adresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cellphones",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellphones", x => new { x.CustomerId, x.Number });
                    table.ForeignKey(
                        name: "FK_Cellphones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
