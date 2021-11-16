using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetEstadoVueloById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetEstadoVueloById
                            @Id int
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                            SELECT * FROM EstadoVuelos
                            WHERE EstadoVueloId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
