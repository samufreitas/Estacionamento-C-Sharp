using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoAtivoEmCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estacionamento_filial_FilialId",
                table: "estacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_filial_empresa_EmpresaId",
                table: "filial");

            migrationBuilder.DropForeignKey(
                name: "FK_filial_endereco_EnderecoId",
                table: "filial");

            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_cliente_ClienteId",
                table: "veiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_veiculoEstacionamentoModels_estacionamento_estacionamentoId",
                table: "veiculoEstacionamentoModels");

            migrationBuilder.DropForeignKey(
                name: "FK_veiculoEstacionamentoModels_veiculo_veiculoId",
                table: "veiculoEstacionamentoModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_filial",
                table: "filial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estacionamento",
                table: "estacionamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_endereco",
                table: "endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_empresa",
                table: "empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculoEstacionamentoModels",
                table: "veiculoEstacionamentoModels");

            migrationBuilder.RenameTable(
                name: "veiculo",
                newName: "Veiculo");

            migrationBuilder.RenameTable(
                name: "filial",
                newName: "Filial");

            migrationBuilder.RenameTable(
                name: "estacionamento",
                newName: "Estacionamento");

            migrationBuilder.RenameTable(
                name: "endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "empresa",
                newName: "Empresa");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "Cliente");

            migrationBuilder.RenameTable(
                name: "veiculoEstacionamentoModels",
                newName: "VeiculoEstacionamento");

            migrationBuilder.RenameIndex(
                name: "IX_veiculo_ClienteId",
                table: "Veiculo",
                newName: "IX_Veiculo_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_filial_EnderecoId",
                table: "Filial",
                newName: "IX_Filial_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_filial_EmpresaId",
                table: "Filial",
                newName: "IX_Filial_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_estacionamento_FilialId",
                table: "Estacionamento",
                newName: "IX_Estacionamento_FilialId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculoEstacionamentoModels_veiculoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_veiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculoEstacionamentoModels_estacionamentoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_estacionamentoId");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Cliente",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filial",
                table: "Filial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estacionamento",
                table: "Estacionamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VeiculoEstacionamento",
                table: "VeiculoEstacionamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estacionamento_Filial_FilialId",
                table: "Estacionamento",
                column: "FilialId",
                principalTable: "Filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filial_Empresa_EmpresaId",
                table: "Filial",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filial_Endereco_EnderecoId",
                table: "Filial",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoEstacionamento_Estacionamento_estacionamentoId",
                table: "VeiculoEstacionamento",
                column: "estacionamentoId",
                principalTable: "Estacionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoEstacionamento_Veiculo_veiculoId",
                table: "VeiculoEstacionamento",
                column: "veiculoId",
                principalTable: "Veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estacionamento_Filial_FilialId",
                table: "Estacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Filial_Empresa_EmpresaId",
                table: "Filial");

            migrationBuilder.DropForeignKey(
                name: "FK_Filial_Endereco_EnderecoId",
                table: "Filial");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Estacionamento_estacionamentoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Veiculo_veiculoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filial",
                table: "Filial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estacionamento",
                table: "Estacionamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VeiculoEstacionamento",
                table: "VeiculoEstacionamento");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "veiculo");

            migrationBuilder.RenameTable(
                name: "Filial",
                newName: "filial");

            migrationBuilder.RenameTable(
                name: "Estacionamento",
                newName: "estacionamento");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "endereco");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "empresa");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "cliente");

            migrationBuilder.RenameTable(
                name: "VeiculoEstacionamento",
                newName: "veiculoEstacionamentoModels");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_ClienteId",
                table: "veiculo",
                newName: "IX_veiculo_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Filial_EnderecoId",
                table: "filial",
                newName: "IX_filial_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Filial_EmpresaId",
                table: "filial",
                newName: "IX_filial_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Estacionamento_FilialId",
                table: "estacionamento",
                newName: "IX_estacionamento_FilialId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_veiculoId",
                table: "veiculoEstacionamentoModels",
                newName: "IX_veiculoEstacionamentoModels_veiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_estacionamentoId",
                table: "veiculoEstacionamentoModels",
                newName: "IX_veiculoEstacionamentoModels_estacionamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_filial",
                table: "filial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estacionamento",
                table: "estacionamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_endereco",
                table: "endereco",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_empresa",
                table: "empresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculoEstacionamentoModels",
                table: "veiculoEstacionamentoModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_estacionamento_filial_FilialId",
                table: "estacionamento",
                column: "FilialId",
                principalTable: "filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_filial_empresa_EmpresaId",
                table: "filial",
                column: "EmpresaId",
                principalTable: "empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_filial_endereco_EnderecoId",
                table: "filial",
                column: "EnderecoId",
                principalTable: "endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_cliente_ClienteId",
                table: "veiculo",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_veiculoEstacionamentoModels_estacionamento_estacionamentoId",
                table: "veiculoEstacionamentoModels",
                column: "estacionamentoId",
                principalTable: "estacionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_veiculoEstacionamentoModels_veiculo_veiculoId",
                table: "veiculoEstacionamentoModels",
                column: "veiculoId",
                principalTable: "veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
