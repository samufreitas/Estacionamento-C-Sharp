using DocumentFormat.OpenXml.Office2010.Excel;
using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.VeiculoEstacionamentoService
{
    public class VeiculoEstacionamentoService : IVeiculoEstacionamentoInterface
    {
        private readonly ApplicationDbContext _context;
        public VeiculoEstacionamentoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<VeiculoEstacionamentoModel>> AddEntrada(VeiculoEstacionamentoModel veicEstacionado)
        {
            ResponseModel<VeiculoEstacionamentoModel> response = new ResponseModel<VeiculoEstacionamentoModel>();
            try
            {
                if (veicEstacionado == null || veicEstacionado.EstacionamentoId == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Dados inválidos para o cadastro de entrada.";
                    return response;
                }
                // Verifica se já existe um horário de saída
                if (VerificarSeVeiculoExisteSemDataHoraSaída(veicEstacionado))
                {
                    response.Mensagem = "Já existe um registro de estacionamento para esse mesmo veículo sem Data/Hora de saída!";
                    response.Status = false;
                    return response;
                }
                _context.Add(veicEstacionado);
                await _context.SaveChangesAsync();

                response.Dados = veicEstacionado;
                response.Status = true;
                response.Mensagem = "Registro de entrada realizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<VeiculoEstacionamentoModel>> AddSaida(long? Id)
        {
            ResponseModel<VeiculoEstacionamentoModel> response = new ResponseModel<VeiculoEstacionamentoModel>();
            try
            {
                // Validação inicial
                if (Id == null)
                {
                    response.Mensagem = "ID inválido. Veículo não encontrado!";
                    response.Status = false;
                    return response;
                }
                

                var veiculoEstacionado = await _context.VeiculoEstacionamento.FirstOrDefaultAsync(x => x.Id == Id); ;
                if (veiculoEstacionado == null)
                {
                    response.Mensagem = "Não foi possível registrar a saída deste veículo";
                    response.Status = false;
                    return response;
                }
                // Verifica se já existe um horário de saída
                if (VerificarSeVeiculoExisteDataHoraSaída(Id))
                {
                    response.Mensagem = "Já existe uma data e hora de saída para esse veículo!";
                    response.Status = false;
                    response.Dados = veiculoEstacionado;
                    return response;
                }

                veiculoEstacionado.DataHoraSaida = DateTime.Now;
                _context.Update(veiculoEstacionado);
                await _context.SaveChangesAsync();

                response.Mensagem = $"Saída registrada com sucesso! Horário de saída: {veiculoEstacionado.DataHoraSaida}.";
                response.Dados = veiculoEstacionado;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<VeiculoEstacionamentoModel>>> BuscarVeiculosEstacionados(long? id)
        {
            ResponseModel<List<VeiculoEstacionamentoModel>> response = new ResponseModel<List<VeiculoEstacionamentoModel>>();

            try
            {

                if (id == null)
                {
                    response.Mensagem = "registros não localizado!";
                    response.Status = false;
                    return response;
                }
                var veiculosEstacionados = await _context.VeiculoEstacionamento
                                                         .Where(x => x.EstacionamentoId == id)
                                                         .ToListAsync();


                if (veiculosEstacionados == null)
                {
                    response.Mensagem = "Nenhum registro de veiculo estacionado aqui!";
                    response.Status = false;
                    return response;
                }
                response.Dados = veiculosEstacionados;
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

        // Método que verifica se o registro de veículo já tem hora de saída

        private bool VerificarSeVeiculoExisteDataHoraSaída(long? Id)
        {
            var veiculoEstacionamento = _context.VeiculoEstacionamento.FirstOrDefault(x => x.Id == Id && x.DataHoraSaida != null);

            if (veiculoEstacionamento == null)
            {
                return false;
            }
            return true;
        }
        private bool VerificarSeVeiculoExisteSemDataHoraSaída(VeiculoEstacionamentoModel veicEstacionado)
        {
            var veiculoEstacionamento = _context.VeiculoEstacionamento.FirstOrDefault(x => x.VeiculoId == veicEstacionado.VeiculoId && x.DataHoraSaida == null);

            if (veiculoEstacionamento == null)
            {
                return false;
            }
            return true;
        }
    }
}
