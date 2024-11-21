using estacionamentoApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Dto
{
    public class FilialCadastroDto
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

        //Dados referente a tabela endereço

        [Required(ErrorMessage = "Selecione uma empresa!")]
        [ForeignKey("Endereco")]
        public required long EnderecoId { get; set; }

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
