using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamentoApp.Models
{
    public class EstacionamentoModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do estacionamento!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Informe qual filial que o estacionamento pertence!")]
        [ForeignKey("Filial")]
        public required long FilialId { get; set; }

        [ValidateNever]
        public required FilialModel Filial { get; set; }

        public bool Ativo { get; set; } = true;

    }
}
