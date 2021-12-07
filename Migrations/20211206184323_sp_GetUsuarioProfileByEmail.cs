using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetUsuarioProfileByEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetUsuarioProfileByEmail
			                @Correo nvarchar(450)
                            AS
                            BEGIN
	                            SELECT * FROM Usuarios WHERE Correo = @Correo
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
