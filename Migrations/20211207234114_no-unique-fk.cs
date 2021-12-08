using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class nouniquefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras",
                column: "ConsecutivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras",
                column: "ConsecutivoId",
                unique: true);
        }
    }
}
