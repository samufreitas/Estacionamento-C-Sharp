using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamentoApp.Models
{
    public class VeiculoEstacionamentoModel
    {
        public long Id { get; set; }

        public DateTime DataHoraEntrada { get; set; } = DateTime.Now;

        public DateTime? DataHoraSaida { get; set; }

        [Required(ErrorMessage = "Informe o veículo")]
        [ForeignKey("Veiculo")]
        public long VeiculoId { get; set; }

        [ValidateNever]
        public VeiculoModel Veiculo { get; set; }

        [ForeignKey("Estacionamento")]
        public long EstacionamentoId { get; set; }

        [ValidateNever]
        public EstacionamentoModel Estacionamento { get; set; }
    }
}
