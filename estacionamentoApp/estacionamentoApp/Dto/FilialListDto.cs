using estacionamentoApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Dto
{
    public class FilialListDto
    {
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string InscricaoEstadual { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Cnpj { get; set; }

        [ForeignKey("Empresa")]
        public required long EmpresaId { get; set; }

        public string EmpresaNome { get; set; }

        [ValidateNever]
        public EmpresaModel Empresa { get; set; }

        //Dados referente a tabela endereço

        [ForeignKey("Endereco")]
        public required long EnderecoId { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Cep { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Rua { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Bairro { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Cidade { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Estado { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public required string Pais { get; set; }
    }
}
