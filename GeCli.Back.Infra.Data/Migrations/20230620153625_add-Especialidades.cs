using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class AddEspecialidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentists_Employments_EmploymentId",
                table: "Dentists");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_DentistId",
                table: "MedicalRecords");

            migrationBuilder.RenameColumn(
                name: "Cro",
                table: "Dentists",
                newName: "CRO");

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentId",
                table: "Dentists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dentists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Specialtys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialtys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DentistSpecialty",
                columns: table => new
                {
                    DentistsId = table.Column<int>(type: "int", nullable: false),
                    SpecialtiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistSpecialty", x => new { x.DentistsId, x.SpecialtiesId });
                    table.ForeignKey(
                        name: "FK_DentistSpecialty_Dentists_DentistsId",
                        column: x => x.DentistsId,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DentistSpecialty_Specialtys_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalTable: "Specialtys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DentistId",
                table: "MedicalRecords",
                column: "DentistId");

            migrationBuilder.CreateIndex(
                name: "IX_DentistSpecialty_SpecialtiesId",
                table: "DentistSpecialty",
                column: "SpecialtiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dentists_Employments_EmploymentId",
                table: "Dentists",
                column: "EmploymentId",
                principalTable: "Employments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dentists_Employments_EmploymentId",
                table: "Dentists");

            migrationBuilder.DropTable(
                name: "DentistSpecialty");

            migrationBuilder.DropTable(
                name: "Specialtys");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_DentistId",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dentists");

            migrationBuilder.RenameColumn(
                name: "CRO",
                table: "Dentists",
                newName: "Cro");

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentId",
                table: "Dentists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DentistId",
                table: "MedicalRecords",
                column: "DentistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dentists_Employments_EmploymentId",
                table: "Dentists",
                column: "EmploymentId",
                principalTable: "Employments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
