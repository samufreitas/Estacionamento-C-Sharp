using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.EmpresaService
{
    public class EmpresaService : IEmpresaInterface
    {
        private readonly ApplicationDbContext _context;
        public EmpresaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<EmpresaModel>> BuscarEmpresaPorId(long? id)
        {
            ResponseModel<EmpresaModel> response = new ResponseModel<EmpresaModel>();

            try
            {

                if (id == null)
                {
                    response.Mensagem = "Empresa não localizado!";
                    response.Status = false;
                    return response;
                }
                var empresa = await _context.Empresa.FirstOrDefaultAsync(x => x.Id == id);

                if (empresa == null)
                {
                    response.Mensagem = "Empresa não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                response.Dados = empresa;
                response.Status = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<EmpresaModel>>> BuscarEmpresas()
        {
            ResponseModel<List<EmpresaModel>> response = new ResponseModel<List<EmpresaModel>>();

            try
            {
                //Filtra as empresas para exibir apenas os clientes com ativo = TRUE
                var empresas = await _context.Empresa
            .Where(c => c.Ativo != false)
            .ToListAsync();

                response.Dados = empresas;
                response.Mensagem = "Dados coletados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmpresaModel>> CadastrarEmpresa(EmpresaModel empresaModel)
        {
            ResponseModel<EmpresaModel> response = new ResponseModel<EmpresaModel>();
            try
            {
                _context.Add(empresaModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Cadastro realizado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmpresaModel>> EditarEmpresa(EmpresaModel empresaModel)
        {
            ResponseModel<EmpresaModel> response = new ResponseModel<EmpresaModel>();
            try
            {
                var empresa = await BuscarEmpresaPorId(empresaModel.Id);

                if (empresa.Status == false || empresa.Dados == null)
                {
                    return empresa;
                }
                empresa.Dados.Nome = empresaModel.Nome;
                empresa.Dados.Cnpj = empresaModel.Cnpj;

                _context.Update(empresa.Dados);
                await _context.SaveChangesAsync();


                response.Mensagem = "Edição realizada com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmpresaModel>> RemoveEmpresa(long? id)
        {
            ResponseModel<EmpresaModel> response = new ResponseModel<EmpresaModel>();
            try
            {
                var empresa = await BuscarEmpresaPorId(id);
                if (empresa.Status == false || empresa.Dados == null)
                {
                    response.Mensagem = "Cliente não localizado para exclusão!";
                    response.Status = false;
                    return response;
                }

                empresa.Dados.Ativo = false;
                _context.Update(empresa.Dados);
                await _context.SaveChangesAsync();

                response.Mensagem = "Remoção realizada com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
