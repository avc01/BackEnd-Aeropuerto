using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class CorrecionVuelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelo_Aerolinea_AerolineaId",
                table: "Vuelo");

            migrationBuilder.DropIndex(
                name: "IX_Vuelo_AerolineaId",
                table: "Vuelo");

            migrationBuilder.DropColumn(
                name: "AerolineaId",
                table: "Vuelo");

            migrationBuilder.AddColumn<int>(
                name: "IdAerolinea",
                table: "Vuelo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAerolinea",
                table: "Vuelo");

            migrationBuilder.AddColumn<int>(
                name: "AerolineaId",
                table: "Vuelo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_AerolineaId",
                table: "Vuelo",
                column: "AerolineaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelo_Aerolinea_AerolineaId",
                table: "Vuelo",
                column: "AerolineaId",
                principalTable: "Aerolinea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
