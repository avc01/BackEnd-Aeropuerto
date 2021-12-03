using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_GetUserByEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_GetUserByEmail
                            @Correo nvarchar(MAX)
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                            SELECT * FROM Usuarios
                            WHERE Correo = @Correo
                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
