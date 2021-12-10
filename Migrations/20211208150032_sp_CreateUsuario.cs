using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_CreateUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_CreateUsuario
							@NombreUsuario nvarchar(MAX),
							@Contraseña nvarchar(MAX),
							@ConfirmaContraseña nvarchar(MAX),
							@Correo nvarchar(MAX),
							@Pregunta nvarchar(MAX),
							@Respuesta nvarchar(MAX)
						AS
						BEGIN
							BEGIN TRAN
								INSERT INTO Usuarios(
									NombreUsuario,
									Contraseña,
									ConfirmaContraseña,
									Correo,
									Pregunta,
									Respuesta)
									VALUES (
									@NombreUsuario,
									@Contraseña,
									@ConfirmaContraseña,
									@Correo,
									@Pregunta,
									@Respuesta)
							COMMIT TRAN
						END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
