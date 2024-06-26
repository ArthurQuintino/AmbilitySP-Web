using AmbilitySP_Desktop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmbilitySP_Desktop.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			ViewBag.Text1 = "O litoral paulistano vem sofrendo com o descarte irregular de lixo acabando com a nossa biodiversidade.";
			ViewBag.Text2 = "Para evitar isso � nescessario cuidar de seu lixo. Confira nosso menu para mais informa��es";
			ViewData["pauta1"] = "Meio Ambiente";
			ViewData["pauta2"] = "Reciclagem";
			ViewData["pauta3"] = "Inova��o Verde";
			return View();
		}

        public IActionResult Reciclagem()
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
