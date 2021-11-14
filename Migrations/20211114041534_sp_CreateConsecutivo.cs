using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateConsecutivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateConsecutivo
							@ConsecutivoId int,
							@Descripcion nvarchar(MAX),
							@NumeroConsecutivo int,
							@Prefijo nvarchar(MAX),
							@RangoInicial int,
							@RangoFinal int
						AS
						BEGIN
							SET NOCOUNT ON;
							INSERT INTO Consecutivos(
							ConsecutivoId, 
							Descripcion, 
							NumeroConsecutivo, 
							Prefijo, 
							RangoInicial,
							RangoFinal)
							VALUES (
							@ConsecutivoId,
							@Descripcion,
							@NumeroConsecutivo,
							@Prefijo,
							@RangoInicial,
							@RangoFinal)
						END";

			migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
