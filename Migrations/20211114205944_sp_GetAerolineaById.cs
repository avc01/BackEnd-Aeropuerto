using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetAerolineaById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetAerolineaById
                            @Id int
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                            SELECT * FROM Aerolineas
                            WHERE AerolineaId = @Id
                        END
                        ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
