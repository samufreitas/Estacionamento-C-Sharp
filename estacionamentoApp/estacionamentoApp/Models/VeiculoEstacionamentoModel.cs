using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models
{
    public class VeiculoEstacionamentoModel
    {
        public long Id { get; set; }


        public DateTime DataHoraEntrada { get; set; }

        public DateTime DataHoraSaida { get; set; }

        public VeiculoModel veiculo { get; set; }

        public EstacionamentoModel estacionamento { get; set; }
    }
}
