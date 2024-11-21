using estacionamentoApp.Models;

namespace estacionamentoApp.Services.VeiculoService
{
    public interface IVeiculoInterface
    {
        Task<ResponseModel<List<VeiculoModel>>> BuscarVeiculos();
        Task<ResponseModel<VeiculoModel>> BuscarVeiculoPorId(long? id);
        Task<ResponseModel<VeiculoModel>> CadastrarVeiculo(VeiculoModel veiculoModel);
        Task<ResponseModel<VeiculoModel>> EditarVeiculo(VeiculoModel veiculoModel);
        Task<ResponseModel<VeiculoModel>> RemoveVeiculo(long? id);
    }
}
