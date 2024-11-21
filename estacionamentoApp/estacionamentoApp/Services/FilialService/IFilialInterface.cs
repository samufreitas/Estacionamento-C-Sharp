using estacionamentoApp.Dto;
using estacionamentoApp.Models;

namespace estacionamentoApp.Services.FilialService
{
    public interface IFilialInterface
    {
        Task<ResponseModel<List<FilialListDto>>> BuscarFiliais();

        Task<ResponseModel<FilialCadastroDto>> BuscarFilialPorId(long? id);
        Task<ResponseModel<FilialModel>> CadastrarFilial(FilialCadastroDto filialDto);
        Task<ResponseModel<FilialModel>> EditarFilial(FilialCadastroDto filialDto);
        Task<ResponseModel<FilialModel>> RemoveFilial(long? id);
    }
}
