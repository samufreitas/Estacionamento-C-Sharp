using estacionamentoApp.Models.Enus;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace estacionamentoApp.Models
{
    public class ClienteModel: IValidatableObject
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Informe o nome completo do cliente!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Informe o tipo de cliente!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required ClienteEnum Tipo { get; set; }


        [Required(ErrorMessage = "Informe o CPF/CNPJ do cliente!")]
        [Column(TypeName = "VARCHAR(255)")]
        public required string Cpf_Cnpj { get; set; }

        public required bool Ativo { get; set; } = true;

        // Método para validação condicional de acordo com o tipo de cliente
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Tipo == ClienteEnum.None)
            {
                yield return new ValidationResult("Por favor, selecione o tipo de cliente.", new[] { nameof(Tipo) });
            }

            // Verifica o formato do CPF se o tipo for Pessoa Física
            if (Tipo == ClienteEnum.PF)
            {
                if (!Regex.IsMatch(Cpf_Cnpj, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
                {
                    yield return new ValidationResult("CPF inválido. Formato esperado: 000.000.000-00", new[] { nameof(Cpf_Cnpj) });
                }
            }
            // Verifica o formato do CNPJ se o tipo for Pessoa Jurídica
            else if (Tipo == ClienteEnum.PJ)
            {
                if (!Regex.IsMatch(Cpf_Cnpj, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$"))
                {
                    yield return new ValidationResult("CNPJ inválido. Formato esperado: 00.000.000/0000-00", new[] { nameof(Cpf_Cnpj) });
                }
            }
        }
    }
}
