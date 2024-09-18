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
			ViewBag.Text2 = "Para evitar isso é nescessario cuidar de seu lixo. Confira nosso menu para mais informações";
			ViewData["pauta1"] = "Meio Ambiente";
			ViewData["pauta2"] = "Reciclagem";
			ViewData["pauta3"] = "Inovação Verde";
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
        private readonly Dictionary<string, double> valores = new Dictionary<string, double>
     {
         {"Borracha", 10.0},
         {"Metal", 20.0},
         {"Plastico", 10.0}
     };

        public IActionResult CalculadoraCarbono()
        {
            var calcCarb = new CalcCarbono();
            return View(calcCarb);
        }

        [HttpPost]

        public IActionResult Calcular(CalcCarbono calcCarb)
        {
            if (!string.IsNullOrEmpty(calcCarb.OpcaoSelecionada) && valores.ContainsKey(calcCarb.OpcaoSelecionada))
            {
                calcCarb.Resultado = valores[calcCarb.OpcaoSelecionada] * calcCarb.Kilos;
            }
            return View("CalculadoraCarbono", calcCarb);
        }
    }
}
