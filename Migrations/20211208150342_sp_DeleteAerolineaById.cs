using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_DeleteAerolineaById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_DeleteAerolineaById
                            @Id int
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        DELETE FROM Aerolineas WHERE AerolineaId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
