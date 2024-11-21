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
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido. Formato esperado: 00.000.000/0000-00")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cnpj { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
