﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using estacionamentoApp.Data;

#nullable disable

namespace estacionamentoApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118195349_AtualizandoBancoDB")]
    partial class AtualizandoBancoDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("estacionamentoApp.Models.ClienteModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Cpf_Cnpj")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("estacionamentoApp.Models.EmpresaModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("estacionamentoApp.Models.EnderecoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("estacionamentoApp.Models.EstacionamentoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("FilialId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("FilialId");

                    b.ToTable("Estacionamento");
                });

            modelBuilder.Entity("estacionamentoApp.Models.FilialModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoEstacionamentoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataHoraEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHoraSaida")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("estacionamentoId")
                        .HasColumnType("bigint");

                    b.Property<long>("veiculoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("estacionamentoId");

                    b.HasIndex("veiculoId");

                    b.ToTable("VeiculoEstacionamento");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("estacionamentoApp.Models.EstacionamentoModel", b =>
                {
                    b.HasOne("estacionamentoApp.Models.FilialModel", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("estacionamentoApp.Models.FilialModel", b =>
                {
                    b.HasOne("estacionamentoApp.Models.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("estacionamentoApp.Models.EnderecoModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoEstacionamentoModel", b =>
                {
                    b.HasOne("estacionamentoApp.Models.EstacionamentoModel", "estacionamento")
                        .WithMany()
                        .HasForeignKey("estacionamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("estacionamentoApp.Models.VeiculoModel", "veiculo")
                        .WithMany()
                        .HasForeignKey("veiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estacionamento");

                    b.Navigation("veiculo");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoModel", b =>
                {
                    b.HasOne("estacionamentoApp.Models.ClienteModel", "Clientes")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("estacionamentoApp.Models.ClienteModel", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
