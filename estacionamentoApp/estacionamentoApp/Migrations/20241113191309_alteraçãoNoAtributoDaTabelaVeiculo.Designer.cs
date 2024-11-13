﻿// <auto-generated />
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
    [Migration("20241113191309_alteraçãoNoAtributoDaTabelaVeiculo")]
    partial class alteraçãoNoAtributoDaTabelaVeiculo
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

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

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

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("estacionamentoApp.Models.VeiculoModel", b =>
                {
                    b.HasOne("estacionamentoApp.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
