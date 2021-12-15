using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateCompra
							@FechaHora nvarchar(MAX),
							@Precio float,
							@Cantidad int,
							@ConsecutivoId int,
							@VueloId int,
							@UsuarioId int,
							@Consecutivo nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Compras(
									FechaHora,
									Precio,
									Cantidad,
									ConsecutivoId,
									VueloId,
									UsuarioId,
									Consecutivo)
									VALUES (
									@FechaHora,
									@Precio,
									@Cantidad,
									@ConsecutivoId,
									@VueloId,
									@UsuarioId,
									@Consecutivo)
							COMMIT TRAN
						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
