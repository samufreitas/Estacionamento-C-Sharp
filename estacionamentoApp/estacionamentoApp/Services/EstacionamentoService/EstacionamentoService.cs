using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.Estacionamento
{
    public class EstacionamentoService : IEstacionamentoInterface
    {
        private readonly ApplicationDbContext _context;
        public EstacionamentoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<EstacionamentoModel>> BuscarEstacionamentoPorId(long? id)
        {
            ResponseModel<EstacionamentoModel> response = new ResponseModel<EstacionamentoModel>();
            try
            {

                if (id == null)
                {
                    response.Mensagem = "Estacionamento não localizado!";
                    response.Status = false;
                    return response;
                }
                var estacionamento = await _context.Estacionamento.FirstOrDefaultAsync(x => x.Id == id);

                if (estacionamento == null)
                {
                    response.Mensagem = "Estacionamento não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                response.Dados = estacionamento;
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

        public async Task<ResponseModel<List<EstacionamentoModel>>> BuscarEstacionamentos()
        {
            ResponseModel<List<EstacionamentoModel>> response = new ResponseModel<List<EstacionamentoModel>>();

            try
            {
                //Filtra os estaciomentos para exibir apenas com ativo = TRUE
                var estacionamentos = await _context.Estacionamento
                .Include(c => c.Filial)
                .Where(c => c.Ativo != false)
                .ToListAsync();

                response.Dados = estacionamentos;
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

        public async Task<ResponseModel<EstacionamentoModel>> CadastrarEstacionamento(EstacionamentoModel estacionamentoModel)
        {
            ResponseModel<EstacionamentoModel> response = new ResponseModel<EstacionamentoModel>();
            try
            {
                if (estacionamentoModel == null || estacionamentoModel.FilialId == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Dados inválidos para cadastro do estacionamento.";
                    return response;
                }
                if (VerificarSeEstacionamentoExiste(estacionamentoModel))
                {
                    response.Mensagem = "Já existe um estacionamento cadastrado com esse nome!";
                    response.Status = false;
                    return response;
                }

                _context.Add(estacionamentoModel);
                await _context.SaveChangesAsync();

                response.Dados = estacionamentoModel;
                response.Status = true;
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

        public async Task<ResponseModel<EstacionamentoModel>> EditarEstacionamento(EstacionamentoModel estacionamentoModel)
        {
            ResponseModel<EstacionamentoModel> response = new ResponseModel<EstacionamentoModel>();
            try
            {
                var estacionamento = await BuscarEstacionamentoPorId(estacionamentoModel.Id);

                if (estacionamento.Status == false || estacionamento.Dados == null)
                {
                    return estacionamento;
                }
                // Verifica se já existe outro estacionamento com o mesmo nome
                if (VerificarSeEstacionamentoExisteUpdate(estacionamentoModel))
                {
                    response.Mensagem = "Já existe outro estacionamento com este nome!";
                    response.Status = false;
                    return response;
                }

                // Verifica se algo foi alterado
                if (!VerificarSeEstacionamentoFoiAlterado(estacionamento.Dados, estacionamentoModel))
                {
                    response.Mensagem = "Nenhuma alteração foi realizada.";
                    response.Status = false;
                    return response;
                }

                estacionamento.Dados.Nome = estacionamentoModel.Nome;
                estacionamento.Dados.FilialId = estacionamentoModel.FilialId;
           
                _context.Update(estacionamento.Dados);
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

        public async Task<ResponseModel<EstacionamentoModel>> RemoveEstacionamento(long? id)
        {
            ResponseModel<EstacionamentoModel> response = new ResponseModel<EstacionamentoModel>();
            try
            {
                var estacionamento = await BuscarEstacionamentoPorId(id);
                if (estacionamento.Status == false || estacionamento.Dados == null)
                {
                    response.Mensagem = "Estacionamento não localizado para exclusão!";
                    response.Status = false;
                    return response;
                }

                estacionamento.Dados.Ativo = false;
                _context.Update(estacionamento.Dados);
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

        // Método auxiliar de verificação se já existe um estacionamento cadastrado com o mesmo NOME
        private bool VerificarSeEstacionamentoExiste(EstacionamentoModel estacionamentoModel)
        {
            var estacionamento = _context.Estacionamento.FirstOrDefault(x => x.Nome == estacionamentoModel.Nome);

            if (estacionamento == null)
            {
                return false;
            }
            return true;
        }
        // Método auxiliar para força o usuário a editar os dados do estacionamento
        private bool VerificarSeEstacionamentoExisteUpdate(EstacionamentoModel estacionamentoModel)
        {
            // Verifica se existe outro estacionamento com o mesmo nome e um ID diferente
            var estacionamentoComMesmoNome = _context.Estacionamento.AsNoTracking()
                .FirstOrDefault(x => x.Nome == estacionamentoModel.Nome && x.Id != estacionamentoModel.Id);

            // Se encontrar um registro com o mesmo nome, mas ID diferente, retorna que já existe
            if (estacionamentoComMesmoNome != null)
            {
                return true; // Já existe um outro estacionamento com esse nome
            }

            return false; // Pode editar porque não há conflito
        }

        private bool VerificarSeEstacionamentoFoiAlterado(EstacionamentoModel estacionamentoAtual, EstacionamentoModel estacionamentoNovo)
        {
            // Verifica se os campos importantes foram alterados
            return estacionamentoAtual.Nome != estacionamentoNovo.Nome ||
                   estacionamentoAtual.FilialId != estacionamentoNovo.FilialId;
        }


    }
}
