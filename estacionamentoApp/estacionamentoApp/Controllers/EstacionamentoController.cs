using estacionamentoApp.Dto;
using estacionamentoApp.Models;
using estacionamentoApp.Services.ClienteService;
using estacionamentoApp.Services.EmpresaService;
using estacionamentoApp.Services.Estacionamento;
using estacionamentoApp.Services.FilialService;
using estacionamentoApp.Services.VeiculoService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    public class EstacionamentoController : Controller
    {
        private readonly IEstacionamentoInterface _estacionamentoInterface;
        private readonly IFilialInterface _filialInterface;
        public EstacionamentoController(IEstacionamentoInterface estacionamentoInterface, IFilialInterface filialInterface)
        {
            _estacionamentoInterface = estacionamentoInterface;
            _filialInterface = filialInterface;
        }
        public async Task<IActionResult> Index()
        {   
            var estacionamentos = await _estacionamentoInterface.BuscarEstacionamentos();
            return View(estacionamentos.Dados);
        }
        // Métodos de cadastro de Estacionamento
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            var filiaisResponse = await _filialInterface.BuscarFiliais();

            if (!filiaisResponse.Status || filiaisResponse.Dados == null)
            {
                TempData["MensagemErro"] = "Erro ao carregar filiais: " + filiaisResponse.Mensagem;
                ViewBag.Filiais = new List<FilialListDto>();
            }
            else
            {
                ViewBag.Filiais = filiaisResponse.Dados.ToList();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EstacionamentoModel estacionamento)
        {
            var filiaisResponse = await _filialInterface.BuscarFiliais();

            if (ModelState.IsValid)
            {
                var estacionamentoResult = await _estacionamentoInterface.CadastrarEstacionamento(estacionamento);

                if (estacionamentoResult.Status)
                {
                    TempData["MensagemSucesso"] = estacionamentoResult.Mensagem;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = estacionamentoResult.Mensagem;
                }
            }

            // Recarrega as filiais para exibir novamente o formulário em caso de erro
            ViewBag.Filiais = filiaisResponse.Status ? filiaisResponse.Dados : new List<FilialListDto>();
            return View(estacionamento);
        }

        // Métodos para atualização do cadastro de um estacionamento
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            // Buscar as filiais

            var filiaisResponse = await _filialInterface.BuscarFiliais();

            if (!filiaisResponse.Status || filiaisResponse.Dados == null)
            {
                ViewBag.ErrorMessage = "Erro ao carregar filiais: " + filiaisResponse.Mensagem;
                ViewBag.Filiais = new List<FilialListDto>();
            }
            else
            {
                ViewBag.Filiais = filiaisResponse.Dados.ToList();
            }
            //Pegando o registro com o mesmo id informado no banco de dados
            var estacionamento = await _estacionamentoInterface.BuscarEstacionamentoPorId(id);

            return View(estacionamento.Dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(EstacionamentoModel estacionamento)
        {
            var filiaisResponse = await _filialInterface.BuscarFiliais();

            if (ModelState.IsValid)
            {
                var estacionamentoResult = await _estacionamentoInterface.EditarEstacionamento(estacionamento);

                if (estacionamentoResult.Status)
                {
                    TempData["MensagemSucesso"] = estacionamentoResult.Mensagem;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = estacionamentoResult.Mensagem;
                }
            }
            else
            {
                TempData["MensagemErro"] = "Não foi possível realizar essa operação!";
            }

            // Recarregar filiais para exibição no formulário
            ViewBag.Filiais = filiaisResponse.Status ? filiaisResponse.Dados : new List<FilialListDto>();

            return View(estacionamento);
        }
        //Método para excluir um veiculo
        public async Task<IActionResult> Excluir(long? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "Estacionamento não localizado!";
                return View(id);
            }
            var estacionamentoResult = await _estacionamentoInterface.RemoveEstacionamento(id);
            if (estacionamentoResult.Status)
            {
                TempData["MensagemSucesso"] = estacionamentoResult.Mensagem;
            }
            else
            {
                TempData["MensagemErro"] = estacionamentoResult.Mensagem;
            }


            return RedirectToAction("Index");
        }

    }
}
