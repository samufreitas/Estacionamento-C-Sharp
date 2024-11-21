using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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

        [Required(ErrorMessage = "Selecione um cliente")]
        [ForeignKey("Cliente")]
        public required long ClienteId { get; set; }

        [ValidateNever]
        public ClienteModel Cliente { get; set; }

        public bool Ativo { get; set; } = true;
    }

}
