using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamentoApp.Models
{
    public class EstacionamentoModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do estacionamento!")]
        [Column(TypeName = "VARCHAR(255)")]
        public long Nome { get; set; }

        [Required(ErrorMessage = "Informe qual filial que o estacionamento pertence!")]
        public required FilialModel Filial { get; set; }

    }
}
