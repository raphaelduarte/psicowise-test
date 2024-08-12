using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsRelationshipFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Psicologos_PsicologoId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Agendas",
                table: "Psicologos");

            migrationBuilder.DropColumn(
                name: "Consultas",
                table: "Psicologos");

            migrationBuilder.DropColumn(
                name: "Pacientes",
                table: "Psicologos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PsicologoId",
                table: "Pacientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PsicologoId",
                table: "Agendas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    PsicologoId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgendaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: false),
                    Realizada = table.Column<bool>(type: "boolean", nullable: false),
                    Cancelada = table.Column<bool>(type: "boolean", nullable: false),
                    Remarcada = table.Column<bool>(type: "boolean", nullable: false),
                    Confirmada = table.Column<bool>(type: "boolean", nullable: false),
                    Paga = table.Column<bool>(type: "boolean", nullable: false),
                    PacienteFaltou = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Psicologos_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "Psicologos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_AgendaId",
                table: "Consulta",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PsicologoId",
                table: "Consulta",
                column: "PsicologoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Psicologos_PsicologoId",
                table: "Agendas",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_Id",
                table: "Pacientes",
                column: "Id",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Psicologos_PsicologoId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psicologos_Id",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.AddColumn<string>(
                name: "Agendas",
                table: "Psicologos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consultas",
                table: "Psicologos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pacientes",
                table: "Psicologos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PsicologoId",
                table: "Pacientes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PsicologoId",
                table: "Agendas",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Psicologos_PsicologoId",
                table: "Agendas",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psicologos_PsicologoId",
                table: "Pacientes",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id");
        }
    }
}
