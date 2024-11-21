using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoBancoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_ClientesId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_ClientesId",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "ClientesId",
                table: "Veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ClienteId",
                table: "Veiculo",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_ClienteId",
                table: "Veiculo");

            migrationBuilder.AddColumn<long>(
                name: "ClientesId",
                table: "Veiculo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ClientesId",
                table: "Veiculo",
                column: "ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_ClientesId",
                table: "Veiculo",
                column: "ClientesId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
