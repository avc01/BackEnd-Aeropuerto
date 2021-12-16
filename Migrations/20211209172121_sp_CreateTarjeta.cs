using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateTarjeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateTarjetaa
							@NumeroTarjeta int,
							@Marca nvarchar(MAX),
							@Tipo nvarchar(MAX),
							@CodigoTarjeta int,
							@UsuarioId int,
							@AnoExp nvarchar(MAX),
							@MesExp nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Tarjetas(
									NumeroTarjeta,
									Marca,
									Tipo,
									CodigoTarjeta,
									UsuarioId,
									AnoExp,
									MesExp)
									VALUES (
									@NumeroTarjeta,
									@Marca,
									@Tipo,
									@CodigoTarjeta,
									@UsuarioId,
									@AnoExp,
									@MesExp)
							COMMIT TRAN
						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
