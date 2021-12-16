using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateReservaa
							@FechaHora nvarchar(MAX),
							@NumeroReservacion int,
							@BookingId nvarchar(7),
							@Cantidad int,
							@Total float,
							@ConsecutivoId int,
							@VueloId int,
							@UsuarioId int,
							@Consecutivo nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Reservas(
									FechaHora,
									NumeroReservacion,
									BookingId,
									Cantidad,
									Total,
									ConsecutivoId,
									VueloId,
									UsuarioId,
									Consecutivo)
									VALUES (
									@FechaHora,
									@NumeroReservacion,
									@BookingId,
									@Cantidad,
									@Total,
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
