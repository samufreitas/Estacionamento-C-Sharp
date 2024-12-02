using estacionamentoApp.Models;

namespace estacionamentoApp.Services.VeiculoEstacionamentoService
{
    public interface IVeiculoEstacionamentoInterface
    {
        Task<ResponseModel<List<VeiculoEstacionamentoModel>>> BuscarVeiculosEstacionados(long? id);

        Task<ResponseModel<VeiculoEstacionamentoModel>> AddEntrada(VeiculoEstacionamentoModel veicEstacionado);

        Task<ResponseModel<VeiculoEstacionamentoModel>> AddSaida(long? Id);
    }
}
