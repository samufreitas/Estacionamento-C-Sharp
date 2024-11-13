using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models
{
    public class EmpresaModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da empresa!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ da empresa!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cnpj { get; set; }
    }
}
