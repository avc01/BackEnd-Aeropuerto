using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_DeleteTarjetaById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_DeleteTarjetaById
                            @Id int
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        DELETE FROM Tarjetas WHERE TarjetaId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
