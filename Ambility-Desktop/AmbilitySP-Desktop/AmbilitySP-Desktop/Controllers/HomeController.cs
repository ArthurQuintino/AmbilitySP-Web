using AmbilitySP_Desktop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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

            var coleta = new Coleta();
            var contato = new Contato();

            contato.telefone.Add(0800618080);
            contato.telefone.Add(1333449400);

            var dataAgora = DateTime.Now;
            var horaAgora = dataAgora.Hour;

            if (horaAgora > 7 && horaAgora < 13)
            {
                ViewBag.Disponivel = coleta.Disponivel = "Est� disponivel";
            }
            else
            {
                ViewBag.Disponivel = coleta.Disponivel = "N�o est� disponivel";
            }


            return View(contato);
        }

        public IActionResult Ligar(int telefone)
        {
            return Redirect($"tel:{telefone}");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<CalcCarbono> valoresCarb = new List<CalcCarbono>
        {
            new CalcCarbono {Materiais = "Borracha", emissaoMaterial = 5.0},
            new CalcCarbono {Materiais = "Pl�stico", emissaoMaterial = 3.0},
            new CalcCarbono {Materiais = "Vidro", emissaoMaterial = 1.5}
        };
        


        public IActionResult CalculadoraCarbono()
        {
            ViewBag.Valores = valoresCarb;

            return View(new CalcCarbono());
        }

        [HttpPost]
        public IActionResult Calcular(CalcCarbono calcCarb)
        {
            calcCarb.Resultado = calcCarb.emissaoMaterial * calcCarb.Kilos;
            ViewBag.Valores = valoresCarb;
            return View("CalculadoraCarbono", calcCarb);
        }
    }
}
