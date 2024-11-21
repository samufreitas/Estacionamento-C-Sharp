using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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

        [Required(ErrorMessage = "Selecione uma empresa!")]
        [ForeignKey("Empresa")]
        public required long EmpresaId { get; set; }

        [ValidateNever]
        public EmpresaModel Empresa { get; set; }

        [ForeignKey("Endereco")]
        public required long EnderecoId { get; set; }

        [ValidateNever]
        public EnderecoModel Endereco { get; set; }

        public bool Ativo { get; set; } = true;
    }

}
