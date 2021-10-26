using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newvuelosmodeltest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_EstadoVueloId",
                table: "Vuelos");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_EstadoVueloId",
                table: "Vuelos",
                column: "EstadoVueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_EstadoVueloId",
                table: "Vuelos");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_EstadoVueloId",
                table: "Vuelos",
                column: "EstadoVueloId",
                unique: true);
        }
    }
}
