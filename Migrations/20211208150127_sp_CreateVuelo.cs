using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateVuelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateVuelo
							@Procedencia nvarchar(MAX),
							@Destino nvarchar(MAX),
							@FechaHora nvarchar(MAX),
							@ConsecutivoId int,
							@AerolineaId int,
							@PuertaId int,
							@EstadoVueloId int,
							@Consecutivo nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Vuelos(
									Procedencia,
									Destino,
									FechaHora,
									ConsecutivoId,
									AerolineaId,
									PuertaId,
									EstadoVueloId,
									Consecutivo)
									VALUES (
									@Procedencia,
									@Destino,
									@FechaHora,
									@ConsecutivoId,
									@AerolineaId,
									@PuertaId,
									@EstadoVueloId,
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
