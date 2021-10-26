using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newmodelsv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Consecutivos_ConsecutivoId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_EstadoVuelos_EstadoVueloId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Puertas_PuertaId",
                table: "Vuelos");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                principalTable: "Aerolineas",
                principalColumn: "AerolineaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Consecutivos_ConsecutivoId",
                table: "Vuelos",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_EstadoVuelos_EstadoVueloId",
                table: "Vuelos",
                column: "EstadoVueloId",
                principalTable: "EstadoVuelos",
                principalColumn: "EstadoVueloId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Puertas_PuertaId",
                table: "Vuelos",
                column: "PuertaId",
                principalTable: "Puertas",
                principalColumn: "PuertaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Consecutivos_ConsecutivoId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_EstadoVuelos_EstadoVueloId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Puertas_PuertaId",
                table: "Vuelos");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aerolineas_AerolineaId",
                table: "Vuelos",
                column: "AerolineaId",
                principalTable: "Aerolineas",
                principalColumn: "AerolineaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Consecutivos_ConsecutivoId",
                table: "Vuelos",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_EstadoVuelos_EstadoVueloId",
                table: "Vuelos",
                column: "EstadoVueloId",
                principalTable: "EstadoVuelos",
                principalColumn: "EstadoVueloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Puertas_PuertaId",
                table: "Vuelos",
                column: "PuertaId",
                principalTable: "Puertas",
                principalColumn: "PuertaId");
        }
    }
}
