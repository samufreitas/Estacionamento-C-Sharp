using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.ClienteService
{
    public class ClienteSerivce : IClienteInterface
    {
        private readonly ApplicationDbContext _context;

        public ClienteSerivce(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<ResponseModel<ClienteModel>> BuscarClientePorId(long? id)
        {
            ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();

            try
            {

                if (id == null)
                {
                    response.Mensagem = "Cliente não localizado!";
                    response.Status = false;
                    return response;
                }
                var emprestimo = await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);

                if (emprestimo == null)
                {
                    response.Mensagem = "Cliente não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                response.Dados = emprestimo;
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

        public async Task<ResponseModel<List<ClienteModel>>> BuscarClientes()
        {
            ResponseModel<List<ClienteModel>> response = new ResponseModel<List<ClienteModel>>();

            try
            {
                var emprestimos = await _context.Cliente.ToListAsync();

                response.Dados = emprestimos;
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

        public async Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteModel clienteModel)
        {
            ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
            try
            {
                _context.Add(clienteModel);
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

        public async Task<ResponseModel<ClienteModel>> EditarCliente(ClienteModel clienteModel)
        {
            ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await BuscarClientePorId(clienteModel.Id);

                if (cliente.Status == false)
                {
                    return cliente;
                }
                cliente.Dados.Nome = clienteModel.Nome;
                cliente.Dados.Tipo = clienteModel.Tipo;
                cliente.Dados.Cpf_Cnpj = clienteModel.Cpf_Cnpj;

                _context.Update(cliente.Dados);
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

        public async Task<ResponseModel<ClienteModel>> RemoveCliente(ClienteModel clienteModel)
        {
            ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
            try
            {
                _context.Remove(clienteModel);
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
