using estacionamentoApp.Models;

namespace estacionamentoApp.Services.ClienteService
{
    public interface IClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> BuscarClientes();
        Task<ResponseModel<ClienteModel>> BuscarClientePorId(long? id);
        Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteModel clienteModel);
        Task<ResponseModel<ClienteModel>> EditarCliente(ClienteModel clienteModel);
        Task<ResponseModel<ClienteModel>> RemoveCliente(long? id);
    }
}
