using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class changepassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_ChangePasswordd
	                        @Id int,
	                        @Password nvarchar(MAX)
                        AS
                        BEGIN
	                        UPDATE Usuarios SET Contraseña = @Password, ConfirmaContraseña = @Password WHERE UsuarioId = @Id;
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
