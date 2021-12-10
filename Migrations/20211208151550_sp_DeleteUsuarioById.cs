using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_DeleteUsuarioById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_DeleteUsuarioById
                            @Id int
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        DELETE FROM Usuarios WHERE UsuarioId = @Id
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
