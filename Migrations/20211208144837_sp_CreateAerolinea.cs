using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateAerolinea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateAerolinea
							@Nombre nvarchar(MAX),
							@ConsecutivoId int,
							@Consecutivo nvarchar(MAX) = null
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Aerolineas(
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
