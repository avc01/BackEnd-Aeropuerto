using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateRol
	                        @Tipo nvarchar(MAX),
	                        @UsuarioId int
                        AS
                        BEGIN
	                        INSERT INTO Roles(
			                        Tipo,
			                        UsuarioId)
			                        VALUES (
			                        @Tipo,
			                        @UsuarioId)
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
