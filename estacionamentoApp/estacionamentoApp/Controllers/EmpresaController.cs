using estacionamentoApp.Models;
using estacionamentoApp.Services.ClienteService;
using estacionamentoApp.Services.EmpresaService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaInterface _empresaInterface;
        public EmpresaController(IEmpresaInterface empresaInterface)
        {
            _empresaInterface = empresaInterface;
        }
        public async Task<IActionResult> Index()
        {
            var empresa = await _empresaInterface.BuscarEmpresas();
            return View(empresa.Dados);
        }
        // Esse método exibe o formulário
        [HttpGet]
        public IActionResult Cadastrar()

        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaResult = await _empresaInterface.CadastrarEmpresa(empresa);

                if (empresaResult.Status)
                {
                    TempData["MensagemSucesso"] = empresaResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = empresaResult.Mensagem;
                    return View(empresaResult);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        // Métodos para atualização do cadastro de uma empresa
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {

            //Pegando o registro com o mesmo id informado no banco de dados
            var empresa = await _empresaInterface.BuscarEmpresaPorId(id);

            return View(empresa.Dados);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaResult = await _empresaInterface.EditarEmpresa(empresa);

                if (empresaResult.Status)
                {
                    TempData["MensagemSucesso"] = empresaResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = empresaResult.Mensagem;
                    return View(empresa);
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Não foi possível realizar essa operação!";
            }

            return View(empresa);
        }
        //Método para excluir um cliente
        public async Task<IActionResult> Excluir(long? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "Cliente não localizado!";
                return View(id);
            }
            var empresaResult = await _empresaInterface.RemoveEmpresa(id);
            if (empresaResult.Status)
            {
                TempData["MensagemSucesso"] = empresaResult.Mensagem;
            }
            else
            {
                TempData["MensagemErro"] = empresaResult.Mensagem;
            }


            return RedirectToAction("Index");
        }
    }
}
