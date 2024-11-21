using estacionamentoApp.Dto;
using estacionamentoApp.Models;

namespace estacionamentoApp.Services.EnderecoService
{
    public interface IEnderecoInterface
    {
        Task<ResponseModel<EnderecoModel>> BuscarEnderecoPorId(long? id);

        Task<ResponseModel<EnderecoModel>> EditarEndereco(EnderecoModel enderecoModel);
    }
}
