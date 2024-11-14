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

        // Métodos para atualização do cadastro de um cliente

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            
            //Pegando o registro com o mesmo id informado no banco de dados
            var cliente = await _clienteInterface.BuscarClientePorId(id);

            return View(cliente.Dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteResult = await _clienteInterface.EditarCliente(cliente);

                if (clienteResult.Status)
                {
                    TempData["MensagemSucesso"] = clienteResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = clienteResult.Mensagem;
                    return View(cliente);
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Não foi possível realizar essa operação!";
            }

            return View(cliente);
        }
        //Método para excluir um cliente
        public async Task<IActionResult> Excluir(long? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "Cliente não localizado!";
                return View(id);
            }
            var clienteResult = await _clienteInterface.RemoveCliente(id);
            if (clienteResult.Status)
            {
                TempData["MensagemSucesso"] = clienteResult.Mensagem;
            }
            else
            {
                TempData["MensagemErro"] = clienteResult.Mensagem;
            }


            return RedirectToAction("Index");
        }
    }
}
