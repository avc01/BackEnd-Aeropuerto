﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Aeropuerto.Migrations
{
    public partial class sp_DeleteConsecutivoById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_DeleteConsecutivoByIdd
	                       @Id int
                       AS
                       BEGIN
	                       SET NOCOUNT ON;
	                       DELETE FROM Consecutivos WHERE ConsecutivoId = @Id
                       END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
