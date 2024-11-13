using estacionamentoApp.Models.Enus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamentoApp.Models
{
    public class ClienteModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome completo do cliente")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Informe o tipo de cliente")]
        [Column(TypeName = "VARCHAR(255)")]
        public required ClienteEnum Tipo { get; set; }


        [Required(ErrorMessage = "Informe o CPF/CNPJ do cliente")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cpf_Cnpj { get; set; }
    }
}
