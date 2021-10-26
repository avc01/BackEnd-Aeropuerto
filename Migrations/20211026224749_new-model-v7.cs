using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class newmodelv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ConsecutivoId",
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
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BookingId",
                table: "Reservas",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Errores",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Compras",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Bitacoras",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId",
                unique: true);

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
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas",
                column: "ConsecutivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosUsuarioId",
                table: "RolUsuario",
                column: "UsuariosUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ConsecutivoId",
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
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "BookingId",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Errores",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Compras",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHora",
                table: "Bitacoras",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ConsecutivoId",
                table: "Reservas",
                column: "ConsecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Puertas_ConsecutivoId",
                table: "Puertas",
                column: "ConsecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ConsecutivoId",
                table: "Paises",
                column: "ConsecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ConsecutivoId",
                table: "Compras",
                column: "ConsecutivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aerolineas_ConsecutivoId",
                table: "Aerolineas",
                column: "ConsecutivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
