using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreatePais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreatePais
							@Nombre nvarchar(MAX),
							@ConsecutivoId int,
							@Consecutivo nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Paises(
									Nombre,
									ConsecutivoId,
									Consecutivo)
									VALUES (
									@Nombre,
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
