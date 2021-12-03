using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetRolesDeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetRolesDeUsuario
                            @UsuarioId int
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                            SELECT * FROM Roles
                            WHERE UsuarioId = @UsuarioId
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
