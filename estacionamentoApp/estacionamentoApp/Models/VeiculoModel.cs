using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models
{
    public class VeiculoModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe a marca do veículo")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Marca { get; set; }

        [Required(ErrorMessage = "Informe o modelo do veículo")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Modelo { get; set; }

        [Required(ErrorMessage = "Informe a placa do veículo")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Placa { get; set; } 

        [Required(ErrorMessage = "Informe o nome do cliente")]
        public required ClienteModel Cliente { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
