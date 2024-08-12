﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Psicowise.Infrastructure.Contexts;

#nullable disable

namespace Psicowise.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240812135919_FixForeignKey")]
    partial class FixForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Psicowise.Domain.Entities.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PsicologoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AgendaId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Cancelada")
                        .HasColumnType("boolean");

                    b.Property<bool>("Confirmada")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PacienteFaltou")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Paga")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PsicologoId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Realizada")
                        .HasColumnType("boolean");

                    b.Property<bool>("Remarcada")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AgendaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Alcoolismo")
                        .HasColumnType("text");

                    b.Property<string>("Alergias")
                        .HasColumnType("text");

                    b.Property<string>("Alimentacao")
                        .HasColumnType("text");

                    b.Property<string>("AtividadeFisica")
                        .HasColumnType("text");

                    b.Property<string>("Cirurgias")
                        .HasColumnType("text");

                    b.Property<string>("Convenio")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("text");

                    b.Property<string>("Drogas")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Encaminhamentos")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Escolaridade")
                        .HasColumnType("text");

                    b.Property<string>("Espiritualidade")
                        .HasColumnType("text");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("text");

                    b.Property<string>("Expectativas")
                        .HasColumnType("text");

                    b.Property<string>("HistoricoFamiliar")
                        .HasColumnType("text");

                    b.Property<string>("HistoricoMedico")
                        .HasColumnType("text");

                    b.Property<string>("HistoricoPessoal")
                        .HasColumnType("text");

                    b.Property<string>("HistoricoProfissional")
                        .HasColumnType("text");

                    b.Property<string>("Internacoes")
                        .HasColumnType("text");

                    b.Property<string>("Lazer")
                        .HasColumnType("text");

                    b.Property<string>("Medicamentos")
                        .HasColumnType("text");

                    b.Property<string>("MotivoConsulta")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeMae")
                        .HasColumnType("text");

                    b.Property<string>("NomePai")
                        .HasColumnType("text");

                    b.Property<string>("NumeroCarteirinha")
                        .HasColumnType("text");

                    b.Property<string>("Objetivos")
                        .HasColumnType("text");

                    b.Property<string>("Observacoes")
                        .HasColumnType("text");

                    b.Property<string>("ObservacoesConsulta")
                        .HasColumnType("text");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Plano")
                        .HasColumnType("text");

                    b.Property<string>("PlanoTerapeutico")
                        .HasColumnType("text");

                    b.Property<string>("Profissao")
                        .HasColumnType("text");

                    b.Property<string>("Prognostico")
                        .HasColumnType("text");

                    b.Property<Guid>("PsicologoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Queixas")
                        .HasColumnType("text");

                    b.Property<string>("Relacionamentos")
                        .HasColumnType("text");

                    b.Property<string>("Religiao")
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .HasColumnType("text");

                    b.Property<string>("Sexualidade")
                        .HasColumnType("text");

                    b.Property<string>("Sono")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Tabagismo")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ValidadeCarteirinha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Psicologo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Crp")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Psicologos");
                });

            modelBuilder.Entity("Psicowise.Domain.ObjetosDeValor.Horario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AgendaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FimConsulta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("InicioConsulta")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("Psicowise.Domain.Entities.Psicologo", "Psicologo")
                        .WithMany("Agendas")
                        .HasForeignKey("PsicologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("Psicowise.Domain.Entities.Agenda", "Agenda")
                        .WithMany("Consultas")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Psicowise.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Psicowise.Domain.Entities.Psicologo", "Psicologo")
                        .WithMany("Consultas")
                        .HasForeignKey("PsicologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Paciente");

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Psicowise.Domain.Entities.Agenda", null)
                        .WithMany("Pacientes")
                        .HasForeignKey("AgendaId");

                    b.HasOne("Psicowise.Domain.Entities.Psicologo", "Psicologo")
                        .WithMany("Pacientes")
                        .HasForeignKey("PsicologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("Psicowise.Domain.ObjetosDeValor.Horario", b =>
                {
                    b.HasOne("Psicowise.Domain.Entities.Agenda", null)
                        .WithMany("Horarios")
                        .HasForeignKey("AgendaId");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Agenda", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Horarios");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Psicowise.Domain.Entities.Psicologo", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Consultas");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
