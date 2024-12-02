using estacionamentoApp.Models;

namespace estacionamentoApp.Services.Estacionamento
{
    public interface IEstacionamentoInterface
    {
        Task<ResponseModel<List<EstacionamentoModel>>> BuscarEstacionamentos();
        Task<ResponseModel<EstacionamentoModel>> BuscarEstacionamentoPorId(long? id);
        Task<ResponseModel<EstacionamentoModel>> CadastrarEstacionamento(EstacionamentoModel estacionamentoModel);
        Task<ResponseModel<EstacionamentoModel>> EditarEstacionamento(EstacionamentoModel estacionamentoModel);
        Task<ResponseModel<EstacionamentoModel>> RemoveEstacionamento(long? id);
    }
}
