using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newcolumnsconsecutivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Vuelos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Puertas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consecutivo",
                table: "Aerolineas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consecutivos_NumeroConsecutivo",
                table: "Consecutivos",
                column: "NumeroConsecutivo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Consecutivos_NumeroConsecutivo",
                table: "Consecutivos");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Puertas");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Consecutivo",
                table: "Aerolineas");
        }
    }
}
