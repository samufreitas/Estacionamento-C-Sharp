using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class CriaçãoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf_Cnpj = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pais = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Placa = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    ClientesId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Cliente_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InscricaoEstadual = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filial_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estacionamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilialId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamento_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VeiculoEstacionamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    veiculoId = table.Column<long>(type: "bigint", nullable: false),
                    estacionamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoEstacionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoEstacionamento_Estacionamento_estacionamentoId",
                        column: x => x.estacionamentoId,
                        principalTable: "Estacionamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoEstacionamento_Veiculo_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamento_FilialId",
                table: "Estacionamento",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EmpresaId",
                table: "Filial",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EnderecoId",
                table: "Filial",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ClientesId",
                table: "Veiculo",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoEstacionamento_estacionamentoId",
                table: "VeiculoEstacionamento",
                column: "estacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoEstacionamento_veiculoId",
                table: "VeiculoEstacionamento",
                column: "veiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculoEstacionamento");

            migrationBuilder.DropTable(
                name: "Estacionamento");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
