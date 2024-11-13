using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamentoApp.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCamposAtivoEmTodasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Veiculo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Filial",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Estacionamento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Empresa",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Filial");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Estacionamento");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Empresa");
        }
    }
}
