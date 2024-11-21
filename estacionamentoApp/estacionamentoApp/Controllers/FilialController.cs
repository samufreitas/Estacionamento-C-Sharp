using estacionamentoApp.Dto;
using estacionamentoApp.Models;
using estacionamentoApp.Services.ClienteService;
using estacionamentoApp.Services.EmpresaService;
using estacionamentoApp.Services.FilialService;
using estacionamentoApp.Services.VeiculoService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    
    public class FilialController : Controller
    {
        private readonly IFilialInterface _filialInterface;
        private readonly IEmpresaInterface _empresaInterface;
        public FilialController(IFilialInterface filialInterface, IEmpresaInterface empresaInterface)
        {
            _filialInterface = filialInterface;
            _empresaInterface = empresaInterface;
        }
        public async Task<IActionResult> Index()
        {
            var filiais = await _filialInterface.BuscarFiliais();
            return View(filiais.Dados);
        }

        //Métodos para cadastro de uma filial 
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            // Chama o serviço para buscar clientes
            var empresaResponse = await _empresaInterface.BuscarEmpresas();

            if (!empresaResponse.Status || empresaResponse.Dados == null)
            {
                ViewBag.ErrorMessage = "Erro ao carregar empresas: " + empresaResponse.Mensagem;
                ViewBag.Empresas = new List<EmpresaModel>(); // Inicializa uma lista vazia para evitar erros na View
            }
            else
            {
                ViewBag.Empresas = empresaResponse.Dados.ToList();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(FilialCadastroDto filial)
        {
            if (ModelState.IsValid)
            {
                var filialResult = await _filialInterface.CadastrarFilial(filial);

                if (filialResult.Status)
                {
                    TempData["MensagemSucesso"] = filialResult.Mensagem;
                }
                else
                {

                    TempData["MensagemErro"] = filialResult.Mensagem;
                    return View(filialResult);
                }
                return RedirectToAction("Index");
            }
            // Recarrega os clientes para exibir novamente o formulário
            var empresasResponse = await _empresaInterface.BuscarEmpresas();
            ViewBag.Empresas = empresasResponse.Status ? empresasResponse.Dados : new List<EmpresaModel>();
            return View();
        }

        // Métodos para atualização de uma filial
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            // Buscar o cliente
            var empresasResponse = await _empresaInterface.BuscarEmpresas();
            if (!empresasResponse.Status || empresasResponse.Dados == null)
            {
                ViewBag.ErrorMessage = "Erro ao carregar empresas: " + empresasResponse.Mensagem;
            }
            else
            {
                ViewBag.Empresas = empresasResponse.Dados.ToList();
            }
            //Pegando o registro com o mesmo id informado no banco de dados
            var filial = await _filialInterface.BuscarFilialPorId(id);

            return View(filial.Dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(FilialCadastroDto filial)
        {
            if (ModelState.IsValid)
            {
                var veiculoResult = await _filialInterface.EditarFilial(filial);

                if (veiculoResult.Status)
                {
                    TempData["MensagemSucesso"] = veiculoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = veiculoResult.Mensagem;
                    return View(filial);
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Não foi possível realizar essa operação!";
            }

            return View(filial);
        }
    }
}
