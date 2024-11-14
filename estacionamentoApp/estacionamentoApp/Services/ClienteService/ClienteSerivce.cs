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
                //Filtra os clientes para exibir apenas os clientes com ativo = TRUE
                var clientes = await _context.Cliente
            .Where(c => c.Ativo != false)
            .ToListAsync();

                response.Dados = clientes;
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

        public async Task<ResponseModel<ClienteModel>> RemoveCliente(long? id)
        {
            ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await BuscarClientePorId(id);
                if (cliente.Status == false || cliente.Dados == null)
                {
                    response.Mensagem = "Cliente não localizado para exclusão!";
                    response.Status = false;
                    return response;
                }

                cliente.Dados.Ativo = false;
                _context.Update(cliente.Dados);
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
