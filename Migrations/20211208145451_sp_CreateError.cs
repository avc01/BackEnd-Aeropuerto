using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateError
							@FechaHora nvarchar(MAX),
							@Numero int,
							@Mensaje nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Errores(
									FechaHora,
									Numero,
									Mensaje)
									VALUES (
									@FechaHora,
									@Numero,
									@Mensaje)
							COMMIT TRAN
						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
