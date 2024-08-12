using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PacienteFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPsicologo",
                table: "Pacientes");

            migrationBuilder.AddColumn<Guid>(
                name: "PsicologoId",
                table: "Pacientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PsicologoId",
                table: "Pacientes");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPsicologo",
                table: "Pacientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
