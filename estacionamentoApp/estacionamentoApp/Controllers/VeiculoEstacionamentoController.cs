using estacionamentoApp.Models;
using estacionamentoApp.Services.VeiculoEstacionamentoService;
using estacionamentoApp.Services.VeiculoService;
using Microsoft.AspNetCore.Mvc;

namespace estacionamentoApp.Controllers
{
    public class VeiculoEstacionamentoController : Controller
    {
        private readonly IVeiculoEstacionamentoInterface _veiculoEstacionamentoInterface;
        private readonly IVeiculoInterface _veiculoInterface;

        public VeiculoEstacionamentoController(
            IVeiculoEstacionamentoInterface veiculoEstacionamentoInterface,
            IVeiculoInterface veiculoInterface)
        {
            _veiculoEstacionamentoInterface = veiculoEstacionamentoInterface;
            _veiculoInterface = veiculoInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long? id)
        {
            ViewBag.EstacionamentoId = id;

            // Carregar veículos estacionados
            var veiculosEstacionadosResponse = await _veiculoEstacionamentoInterface.BuscarVeiculosEstacionados(id);
            var veiculosEstacionados = veiculosEstacionadosResponse?.Dados ?? new List<VeiculoEstacionamentoModel>();

            // Carregar lista de veículos para o dropdown no modal
            var veiculosResponse = await _veiculoInterface.BuscarVeiculos();
            ViewBag.Veiculos = veiculosResponse.Status && veiculosResponse.Dados != null
                ? veiculosResponse.Dados
                : new List<VeiculoModel>();

            return View(veiculosEstacionados);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntrada(VeiculoEstacionamentoModel veiculoEstacionamentoModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensagemErro"] = "Dados inválidos. Preencha todos os campos obrigatórios.";

                // Recarrega a lista de veículos para o dropdown no modal
                var veiculosResponse = await _veiculoInterface.BuscarVeiculos();
                ViewBag.Veiculos = veiculosResponse.Status && veiculosResponse.Dados != null
                    ? veiculosResponse.Dados
                    : new List<VeiculoModel>();

                return View("Index", new List<VeiculoEstacionamentoModel>());
            }

            var veiculoEstacionadoResult = await _veiculoEstacionamentoInterface.AddEntrada(veiculoEstacionamentoModel);

            if (!veiculoEstacionadoResult.Status)
            {
                TempData["MensagemErro"] = veiculoEstacionadoResult.Mensagem;

                // Recarrega a lista de veículos para o dropdown no modal
                var veiculosResponse = await _veiculoInterface.BuscarVeiculos();
                ViewBag.Veiculos = veiculosResponse.Status && veiculosResponse.Dados != null
                    ? veiculosResponse.Dados
                    : new List<VeiculoModel>();

                ViewBag.EstacionamentoId = veiculoEstacionamentoModel.EstacionamentoId;
                return RedirectToAction("Index", new { id = veiculoEstacionamentoModel.EstacionamentoId });
            }

            TempData["MensagemSucesso"] = veiculoEstacionadoResult.Mensagem;

            // Redireciona para o Index com o mesmo estacionamentoId
            return RedirectToAction("Index", new { id = veiculoEstacionamentoModel.EstacionamentoId });
        }
        public async Task<IActionResult> AddSaida(long? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "Registro não localizado!";
                return RedirectToAction("Index", new { id = ViewBag.EstacionamentoId });
            }

            var veiculoEstacionadoResult = await _veiculoEstacionamentoInterface.AddSaida(id);
            if (veiculoEstacionadoResult.Status)
            {
                TempData["MensagemSucesso"] = veiculoEstacionadoResult.Mensagem;

                // Redireciona para o Index com o EstacionamentoId correto
                return RedirectToAction("Index", new { id = veiculoEstacionadoResult.Dados?.EstacionamentoId ?? ViewBag.EstacionamentoId });
            }
            else
            {
                TempData["MensagemErro"] = veiculoEstacionadoResult.Mensagem;

                // Garante que, em caso de erro, o EstacionamentoId ainda seja transmitido
                return RedirectToAction("Index", new { id = veiculoEstacionadoResult.Dados?.EstacionamentoId ?? ViewBag.EstacionamentoId });
            }
        }
    }
}
