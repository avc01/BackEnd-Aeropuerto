using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreatePuerta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreatePuerta
							@NumeroPuerta int,
							@Detalle nvarchar(MAX),
							@ConsecutivoId int,
							@Consecutivo nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Puertas(
									NumeroPuerta,
									Detalle,
									ConsecutivoId,
									Consecutivo)
									VALUES (
									@NumeroPuerta,
									@Detalle,
									@ConsecutivoId,
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
