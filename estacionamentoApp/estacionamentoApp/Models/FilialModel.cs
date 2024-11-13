using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models
{
    public class FilialModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da filial!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome fantasia da filial!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe a inscrição estadual da filial!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ da filial!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "Informe qual empresa a filial pertence!")]
        public required EmpresaModel Empresa { get; set; }

        public EnderecoModel Endereco { get; set; }

        public bool Ativo { get; set; } = true;
    }

}
