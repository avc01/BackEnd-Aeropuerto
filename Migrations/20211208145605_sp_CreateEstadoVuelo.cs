using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateEstadoVuelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateEstadoVuelo
	                        @Estado nvarchar(MAX),
	                        @Tipo nvarchar(MAX)
                        AS
                        BEGIN
	                        BEGIN TRAN
		                        INSERT INTO EstadoVuelos(
			                        Estado,
			                        Tipo)
			                        VALUES (
			                        @Estado,
			                        @Tipo)
	                        COMMIT TRAN
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
