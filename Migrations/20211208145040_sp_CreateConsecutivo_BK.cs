using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateConsecutivo_BK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateConsecutivo
							@Descripcion nvarchar(MAX),
							@NumeroConsecutivo int,
							@Prefijo nvarchar(MAX) = null,
							@RangoInicial int = null,
							@RangoFinal int = null
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Consecutivos(
								Descripcion, 
								NumeroConsecutivo, 
								Prefijo, 
								RangoInicial,
								RangoFinal)
								VALUES (
								@Descripcion,
								@NumeroConsecutivo,
								@Prefijo,
								@RangoInicial,
								@RangoFinal)
							COMMIT TRAN
						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
