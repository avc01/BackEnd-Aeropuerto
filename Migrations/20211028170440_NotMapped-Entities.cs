using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class NotMappedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aerolineas_Consecutivos_ConsecutivoId",
                table: "Aerolineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bitacoras_Usuarios_UsuarioId",
                table: "Bitacoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Consecutivos_ConsecutivoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuarios_UsuarioId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Vuelos_VueloId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Consecutivos_ConsecutivoId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Puertas_Consecutivos_ConsecutivoId",
                table: "Puertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Consecutivos_ConsecutivoId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Usuarios_UsuarioId",
                table: "Tarjetas");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Tarjetas_UsuarioId",
                table: "Tarjetas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Puertas_ConsecutivoId",
                table: "Puertas");

            migrationBuilder.DropIndex(
                name: "IX_Paises_ConsecutivoId",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_VueloId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Bitacoras_UsuarioId",
                table: "Bitacoras");

            migrationBuilder.DropIndex(
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesRolId = table.Column<int>(type: "int", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesRolId, x.UsuariosUsuarioId });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Roles_RolesRolId",
                        column: x => x.RolesRolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_UsuarioId",
                table: "Tarjetas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas",
                column: "VueloId");

            migrationBuilder.CreateIndex(
                name: "IX_Puertas_ConsecutivoId",
                table: "Puertas",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ConsecutivoId",
                table: "Paises",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_VueloId",
                table: "Compras",
                column: "VueloId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_UsuarioId",
                table: "Bitacoras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosUsuarioId",
                table: "RolUsuario",
                column: "UsuariosUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aerolineas_Consecutivos_ConsecutivoId",
                table: "Aerolineas",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacoras_Usuarios_UsuarioId",
                table: "Bitacoras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Consecutivos_ConsecutivoId",
                table: "Compras",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuarios_UsuarioId",
                table: "Compras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Vuelos_VueloId",
                table: "Compras",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "VueloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Consecutivos_ConsecutivoId",
                table: "Paises",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Puertas_Consecutivos_ConsecutivoId",
                table: "Puertas",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Consecutivos_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId",
                principalTable: "Consecutivos",
                principalColumn: "ConsecutivoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "VueloId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Usuarios_UsuarioId",
                table: "Tarjetas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
