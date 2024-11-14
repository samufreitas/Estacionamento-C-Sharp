using estacionamentoApp.Models;
using estacionamentoApp.Services.ClienteService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }
        // Lista os clientes
        public async Task<IActionResult> Index()
        {
            var cliente = await _clienteInterface.BuscarClientes();
            return View(cliente.Dados);
        }

        // Métodos de cadastro de cliente

        // Esse método exibe o formulário
        [HttpGet]
        public IActionResult Cadastrar()

        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteResult = await _clienteInterface.CadastrarCliente(cliente);

                if (clienteResult.Status)
                {
                    TempData["MensagemSucesso"] = clienteResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = clienteResult.Mensagem;
                    return View(clienteResult);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
