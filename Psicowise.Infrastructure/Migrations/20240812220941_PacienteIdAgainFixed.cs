using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PacienteIdAgainFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Pacientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PacienteId",
                table: "Pacientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
