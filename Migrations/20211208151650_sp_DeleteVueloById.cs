using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_DeleteVueloById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_DeleteVueloById
                            @Id int
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        DELETE FROM Vuelos WHERE VueloId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
