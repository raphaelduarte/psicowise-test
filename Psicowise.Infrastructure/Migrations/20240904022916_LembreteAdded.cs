using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LembreteAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PsicologoId = table.Column<Guid>(type: "uuid", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Mensagem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataDeDisparo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDisparado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lembretes_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lembretes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lembretes_Psicologos_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "Psicologos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_ConsultaId",
                table: "Lembretes",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_PacienteId",
                table: "Lembretes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_PsicologoId",
                table: "Lembretes",
                column: "PsicologoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lembretes");
        }
    }
}
