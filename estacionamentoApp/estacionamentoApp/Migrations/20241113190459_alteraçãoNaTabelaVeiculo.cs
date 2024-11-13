using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãoNaTabelaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_cliente_clienteId",
                table: "veiculo");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "veiculo",
                newName: "Id_clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculo_clienteId",
                table: "veiculo",
                newName: "IX_veiculo_Id_clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_cliente_Id_clienteId",
                table: "veiculo",
                column: "Id_clienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_cliente_Id_clienteId",
                table: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Id_clienteId",
                table: "veiculo",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculo_Id_clienteId",
                table: "veiculo",
                newName: "IX_veiculo_clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_cliente_clienteId",
                table: "veiculo",
                column: "clienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
