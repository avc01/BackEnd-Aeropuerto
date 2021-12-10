using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetTarjetasByUsuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetTarjetasByUsuarioId
                            @Id int
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                            SELECT * FROM Tarjetas
                            WHERE UsuarioId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
