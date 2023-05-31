using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    public partial class Testmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Consumables_ConsumableId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_ConsumableId",
                table: "Procedures");

            migrationBuilder.CreateTable(
                name: "ConsumableProcedure",
                columns: table => new
                {
                    ConsumablesId = table.Column<int>(type: "int", nullable: false),
                    ProceduresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableProcedure", x => new { x.ConsumablesId, x.ProceduresId });
                    table.ForeignKey(
                        name: "FK_ConsumableProcedure_Consumables_ConsumablesId",
                        column: x => x.ConsumablesId,
                        principalTable: "Consumables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumableProcedure_Procedures_ProceduresId",
                        column: x => x.ProceduresId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableProcedure_ProceduresId",
                table: "ConsumableProcedure",
                column: "ProceduresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumableProcedure");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ConsumableId",
                table: "Procedures",
                column: "ConsumableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Consumables_ConsumableId",
                table: "Procedures",
                column: "ConsumableId",
                principalTable: "Consumables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
