using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models
{
    public class EnderecoModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o CEP da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cep { get; set; }

        [Required(ErrorMessage = "Informe a rua da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Rua { get; set; }

        [Required(ErrorMessage = "Informe o bairro da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "Informe o pais da filial")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Pais { get; set; }

    }
}
