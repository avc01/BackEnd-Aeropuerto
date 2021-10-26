using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newvuelosmodeltest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vuelos_PuertaId",
                table: "Vuelos");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_PuertaId",
                table: "Vuelos",
                column: "PuertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vuelos_PuertaId",
                table: "Vuelos");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_PuertaId",
                table: "Vuelos",
                column: "PuertaId",
                unique: true);
        }
    }
}
