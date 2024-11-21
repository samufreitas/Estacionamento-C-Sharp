using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.EnderecoService
{
    public class EnderecoService : IEnderecoInterface
    {
        private readonly ApplicationDbContext _context;
        public EnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<EnderecoModel>> BuscarEnderecoPorId(long? id)
        {
            ResponseModel<EnderecoModel> response = new ResponseModel<EnderecoModel>();

            try
            {

                if (id == null)
                {
                    response.Mensagem = "Endereço não localizado!";
                    response.Status = false;
                    return response;
                }
                var endereco = await _context.Endereco.FirstOrDefaultAsync(x => x.Id == id);

                if (endereco == null)
                {
                    response.Mensagem = "Endereço não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                response.Dados = endereco;
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

        public async Task<ResponseModel<EnderecoModel>> EditarEndereco(EnderecoModel enderecoModel)
        {
            ResponseModel<EnderecoModel> response = new ResponseModel<EnderecoModel>();
            try
            {

                _context.Update(enderecoModel);
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
    }
}
