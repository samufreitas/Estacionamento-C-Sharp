using estacionamentoApp.Models;
using estacionamentoApp.Services.Estacionamento;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace estacionamentoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEstacionamentoInterface _estacionamentoInterface;

        public HomeController(ILogger<HomeController> logger, IEstacionamentoInterface estacionamentoInterface)
        {
            _logger = logger;
            _estacionamentoInterface = estacionamentoInterface;
        }

        public async Task<IActionResult> Index()
        {
            var estacionamentos = await _estacionamentoInterface.BuscarEstacionamentos();
            return View(estacionamentos.Dados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
