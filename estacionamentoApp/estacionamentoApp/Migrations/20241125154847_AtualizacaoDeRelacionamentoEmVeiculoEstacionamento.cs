using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDeRelacionamentoEmVeiculoEstacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Estacionamento_estacionamentoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Veiculo_veiculoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.RenameColumn(
                name: "veiculoId",
                table: "VeiculoEstacionamento",
                newName: "VeiculoId");

            migrationBuilder.RenameColumn(
                name: "estacionamentoId",
                table: "VeiculoEstacionamento",
                newName: "EstacionamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_veiculoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_VeiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_estacionamentoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_EstacionamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoEstacionamento_Estacionamento_EstacionamentoId",
                table: "VeiculoEstacionamento",
                column: "EstacionamentoId",
                principalTable: "Estacionamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VeiculoEstacionamento_Veiculo_VeiculoId",
                table: "VeiculoEstacionamento",
                column: "VeiculoId",
                principalTable: "Veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Estacionamento_EstacionamentoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_VeiculoEstacionamento_Veiculo_VeiculoId",
                table: "VeiculoEstacionamento");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "VeiculoEstacionamento",
                newName: "veiculoId");

            migrationBuilder.RenameColumn(
                name: "EstacionamentoId",
                table: "VeiculoEstacionamento",
                newName: "estacionamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_VeiculoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_veiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_VeiculoEstacionamento_EstacionamentoId",
                table: "VeiculoEstacionamento",
                newName: "IX_VeiculoEstacionamento_estacionamentoId");

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
    }
}
