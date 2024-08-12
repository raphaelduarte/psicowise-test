using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pacientes",
                table: "Psicologos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PsicologoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Psicologos_PsicologoId",
                        column: x => x.PsicologoId,
                        principalTable: "Psicologos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InicioConsulta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FimConsulta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AgendaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horario_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdPsicologo = table.Column<Guid>(type: "uuid", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Rg = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    EstadoCivil = table.Column<string>(type: "text", nullable: true),
                    Profissao = table.Column<string>(type: "text", nullable: true),
                    Escolaridade = table.Column<string>(type: "text", nullable: true),
                    Religiao = table.Column<string>(type: "text", nullable: true),
                    NomePai = table.Column<string>(type: "text", nullable: true),
                    NomeMae = table.Column<string>(type: "text", nullable: true),
                    Convenio = table.Column<string>(type: "text", nullable: true),
                    Plano = table.Column<string>(type: "text", nullable: true),
                    NumeroCarteirinha = table.Column<string>(type: "text", nullable: true),
                    ValidadeCarteirinha = table.Column<string>(type: "text", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "text", nullable: true),
                    HistoricoFamiliar = table.Column<string>(type: "text", nullable: true),
                    HistoricoPessoal = table.Column<string>(type: "text", nullable: true),
                    HistoricoProfissional = table.Column<string>(type: "text", nullable: true),
                    HistoricoMedico = table.Column<string>(type: "text", nullable: true),
                    Medicamentos = table.Column<string>(type: "text", nullable: true),
                    Alergias = table.Column<string>(type: "text", nullable: true),
                    Cirurgias = table.Column<string>(type: "text", nullable: true),
                    Internacoes = table.Column<string>(type: "text", nullable: true),
                    Tabagismo = table.Column<string>(type: "text", nullable: true),
                    Alcoolismo = table.Column<string>(type: "text", nullable: true),
                    Drogas = table.Column<string>(type: "text", nullable: true),
                    AtividadeFisica = table.Column<string>(type: "text", nullable: true),
                    Alimentacao = table.Column<string>(type: "text", nullable: true),
                    Sono = table.Column<string>(type: "text", nullable: true),
                    Relacionamentos = table.Column<string>(type: "text", nullable: true),
                    Sexualidade = table.Column<string>(type: "text", nullable: true),
                    Lazer = table.Column<string>(type: "text", nullable: true),
                    Espiritualidade = table.Column<string>(type: "text", nullable: true),
                    Queixas = table.Column<string>(type: "text", nullable: true),
                    Objetivos = table.Column<string>(type: "text", nullable: true),
                    Expectativas = table.Column<string>(type: "text", nullable: true),
                    Diagnostico = table.Column<string>(type: "text", nullable: true),
                    Prognostico = table.Column<string>(type: "text", nullable: true),
                    PlanoTerapeutico = table.Column<string>(type: "text", nullable: true),
                    Encaminhamentos = table.Column<string>(type: "text", nullable: true),
                    ObservacoesConsulta = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    AgendaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PsicologoId",
                table: "Agendas",
                column: "PsicologoId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_AgendaId",
                table: "Horario",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_AgendaId",
                table: "Pacientes",
                column: "AgendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "Pacientes",
                table: "Psicologos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
