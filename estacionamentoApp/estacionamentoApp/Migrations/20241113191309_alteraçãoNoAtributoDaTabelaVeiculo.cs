using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãoNoAtributoDaTabelaVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_cliente_Id_clienteId",
                table: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Id_clienteId",
                table: "veiculo",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculo_Id_clienteId",
                table: "veiculo",
                newName: "IX_veiculo_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_veiculo_cliente_ClienteId",
                table: "veiculo",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_veiculo_cliente_ClienteId",
                table: "veiculo");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "veiculo",
                newName: "Id_clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_veiculo_ClienteId",
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
    }
}
