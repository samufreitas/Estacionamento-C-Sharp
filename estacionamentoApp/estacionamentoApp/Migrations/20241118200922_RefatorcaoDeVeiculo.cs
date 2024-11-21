using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class RefatorcaoDeVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_ClienteId",
                table: "Veiculo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
