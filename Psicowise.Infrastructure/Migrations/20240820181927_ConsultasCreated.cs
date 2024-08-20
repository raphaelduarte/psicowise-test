using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConsultasCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Agendas_AgendaId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Pacientes_PacienteId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Psicologos_PsicologoId",
                table: "Consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consulta",
                table: "Consulta");

            migrationBuilder.RenameTable(
                name: "Consulta",
                newName: "Consultas");

            migrationBuilder.RenameColumn(
                name: "Inicio",
                table: "Consultas",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Fim",
                table: "Consultas",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_PsicologoId",
                table: "Consultas",
                newName: "IX_Consultas_PsicologoId");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consultas",
                newName: "IX_Consultas_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Consulta_AgendaId",
                table: "Consultas",
                newName: "IX_Consultas_AgendaId");

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Consultas",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Consultas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Agendas_AgendaId",
                table: "Consultas",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Agendas_AgendaId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "Consulta");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Consulta",
                newName: "Inicio");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Consulta",
                newName: "Fim");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PsicologoId",
                table: "Consulta",
                newName: "IX_Consulta_PsicologoId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consulta",
                newName: "IX_Consulta_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_AgendaId",
                table: "Consulta",
                newName: "IX_Consulta_AgendaId");

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "Consulta",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consulta",
                table: "Consulta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Agendas_AgendaId",
                table: "Consulta",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Pacientes_PacienteId",
                table: "Consulta",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Psicologos_PsicologoId",
                table: "Consulta",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
