using estacionamentoApp.Data;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.VeiculoService
{
    public class VeiculoService : IVeiculoInterface
    {
        private readonly ApplicationDbContext _context;

        public VeiculoService(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<ResponseModel<VeiculoModel>> BuscarVeiculoPorId(long? id)
        {
            ResponseModel<VeiculoModel> response = new ResponseModel<VeiculoModel>();

            try
            {

                if (id == null)
                {
                    response.Mensagem = "Veículo não localizado!";
                    response.Status = false;
                    return response;
                }
                var veiculo = await _context.Veiculo.FirstOrDefaultAsync(x => x.Id == id);

                if (veiculo == null)
                {
                    response.Mensagem = "Veículo não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                response.Dados = veiculo;
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

        public async Task<ResponseModel<List<VeiculoModel>>> BuscarVeiculos()
        {
            ResponseModel<List<VeiculoModel>> response = new ResponseModel<List<VeiculoModel>>();

            try
            {
                //Filtra os clientes para exibir apenas os clientes com ativo = TRUE
                var veiculos = await _context.Veiculo
                .Include(c => c.Cliente)
                .Where(c => c.Ativo != false)
                .ToListAsync();

                response.Dados = veiculos;
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

        public async Task<ResponseModel<VeiculoModel>> CadastrarVeiculo(VeiculoModel veiculoModel)
        {
            ResponseModel<VeiculoModel> response = new ResponseModel<VeiculoModel>();
            try
            {
                if (veiculoModel == null || veiculoModel.ClienteId == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Dados inválidos para cadastro do veículo.";
                    return response;
                }

                _context.Add(veiculoModel);
                await _context.SaveChangesAsync();
                Console.WriteLine("Veículo cadastrado com sucesso.");

                response.Dados = veiculoModel;
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


        public async Task<ResponseModel<VeiculoModel>> EditarVeiculo(VeiculoModel veiculoModel)
        {
            ResponseModel<VeiculoModel> response = new ResponseModel<VeiculoModel>();
            try
            {
                var veiculo = await BuscarVeiculoPorId(veiculoModel.Id);

                if (veiculo.Status == false || veiculo.Dados == null)
                {
                    return veiculo;
                }
                veiculo.Dados.Marca = veiculoModel.Marca;
                veiculo.Dados.Modelo = veiculoModel.Modelo;
                veiculo.Dados.Placa = veiculoModel.Placa;
                veiculo.Dados.ClienteId = veiculoModel.ClienteId;

                _context.Update(veiculo.Dados);
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

        public async Task<ResponseModel<VeiculoModel>> RemoveVeiculo(long? id)
        {
            ResponseModel<VeiculoModel> response = new ResponseModel<VeiculoModel>();
            try
            {
                var veiculo = await BuscarVeiculoPorId(id);
                if (veiculo.Status == false || veiculo.Dados == null)
                {
                    response.Mensagem = "Cliente não localizado para exclusão!";
                    response.Status = false;
                    return response;
                }

                veiculo.Dados.Ativo = false;
                _context.Update(veiculo.Dados);
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
