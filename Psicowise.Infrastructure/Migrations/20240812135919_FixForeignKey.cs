using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId1",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsicologoId1",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PsicologoId1",
                table: "Pacientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PsicologoId1",
                table: "Pacientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsicologoId1",
                table: "Pacientes",
                column: "PsicologoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId1",
                table: "Pacientes",
                column: "PsicologoId1",
                principalTable: "Psicologos",
                principalColumn: "Id");
        }
    }
}
