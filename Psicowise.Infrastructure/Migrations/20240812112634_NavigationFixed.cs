using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NavigationFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_Id",
                table: "Pacientes");

            migrationBuilder.AddColumn<Guid>(
                name: "PacienteId",
                table: "Pacientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PsicologoId1",
                table: "Pacientes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsicologoId1",
                table: "Pacientes",
                column: "PsicologoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId1",
                table: "Pacientes",
                column: "PsicologoId1",
                principalTable: "Psicologos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId1",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsicologoId1",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PsicologoId1",
                table: "Pacientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_Id",
                table: "Pacientes",
                column: "Id",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
