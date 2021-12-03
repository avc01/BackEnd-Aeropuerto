using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newrulesforrolesusuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_UsuarioId",
                table: "Roles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_UsuarioId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Roles");

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
                name: "IX_RolUsuario_UsuariosUsuarioId",
                table: "RolUsuario",
                column: "UsuariosUsuarioId");
        }
    }
}
