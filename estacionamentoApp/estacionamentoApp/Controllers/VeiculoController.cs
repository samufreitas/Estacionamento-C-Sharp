using estacionamentoApp.Models;
using estacionamentoApp.Services.ClienteService;
using estacionamentoApp.Services.VeiculoService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoInterface _veiculoInterface;
        private readonly IClienteInterface _clienteInterface;
        public VeiculoController(IVeiculoInterface veiculoInterface, IClienteInterface clienteInterface)
        {
            _veiculoInterface = veiculoInterface;
            _clienteInterface = clienteInterface;
        }
        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoInterface.BuscarVeiculos();
            return View(veiculos.Dados);

        }
        // Métodos de cadastro de Veículo
        // Esse método exibe o formulário
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            // Chama o serviço para buscar clientes
            var clientesResponse = await _clienteInterface.BuscarClientes();

            if (!clientesResponse.Status || clientesResponse.Dados == null)
            {
                ViewBag.ErrorMessage = "Erro ao carregar clientes: " + clientesResponse.Mensagem;
                ViewBag.Clientes = new List<ClienteModel>(); // Inicializa uma lista vazia para evitar erros na View
            }
            else
            {
                ViewBag.Clientes = clientesResponse.Dados.ToList();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(VeiculoModel veiculo)
        {
            if (ModelState.IsValid)
            {
                var veiculoResult = await _veiculoInterface.CadastrarVeiculo(veiculo);

                if (veiculoResult.Status)
                {
                    TempData["MensagemSucesso"] = veiculoResult.Mensagem;
                }
                else
                {

                    TempData["MensagemErro"] = veiculoResult.Mensagem;
                    return View(veiculoResult);
                }
                return RedirectToAction("Index");
            }
            // Recarrega os clientes para exibir novamente o formulário
            var clientesResponse = await _clienteInterface.BuscarClientes();
            ViewBag.Clientes = clientesResponse.Status ? clientesResponse.Dados : new List<ClienteModel>();
            return View();
        }

        // Métodos para atualização do cadastro de um cliente
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            // Buscar o cliente
            var clientesResponse = await _clienteInterface.BuscarClientes();
            if (!clientesResponse.Status || clientesResponse.Dados == null)
            {
                ViewBag.ErrorMessage = "Erro ao carregar clientes: " + clientesResponse.Mensagem;
            }
            else
            {
                ViewBag.Clientes = clientesResponse.Dados.ToList();
            }
            //Pegando o registro com o mesmo id informado no banco de dados
            var veiculo = await _veiculoInterface.BuscarVeiculoPorId(id);

            return View(veiculo.Dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(VeiculoModel veiculo)
        {
            if (ModelState.IsValid)
            {
                var veiculoResult = await _veiculoInterface.EditarVeiculo(veiculo);

                if (veiculoResult.Status)
                {
                    TempData["MensagemSucesso"] = veiculoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = veiculoResult.Mensagem;
                    return View(veiculo);
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Não foi possível realizar essa operação!";
            }

            return View(veiculo);
        }

        //Método para excluir um veiculo
        public async Task<IActionResult> Excluir(long? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "Cliente não localizado!";
                return View(id);
            }
            var veiculoResult = await _veiculoInterface.RemoveVeiculo(id);
            if (veiculoResult.Status)
            {
                TempData["MensagemSucesso"] = veiculoResult.Mensagem;
            }
            else
            {
                TempData["MensagemErro"] = veiculoResult.Mensagem;
            }


            return RedirectToAction("Index");
        }

    }
}
