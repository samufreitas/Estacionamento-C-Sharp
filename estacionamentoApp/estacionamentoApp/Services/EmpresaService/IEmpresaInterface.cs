using estacionamentoApp.Models;

namespace estacionamentoApp.Services.EmpresaService
{
    public interface IEmpresaInterface
    {
        Task<ResponseModel<List<EmpresaModel>>> BuscarEmpresas();
        Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorId(long? id);
        Task<ResponseModel<EmpresaModel>> CadastrarEmpresa(EmpresaModel empresaModel);
        Task<ResponseModel<EmpresaModel>> EditarEmpresa(EmpresaModel empresaModel);
        Task<ResponseModel<EmpresaModel>> RemoveEmpresa(long? id);
    }
}
