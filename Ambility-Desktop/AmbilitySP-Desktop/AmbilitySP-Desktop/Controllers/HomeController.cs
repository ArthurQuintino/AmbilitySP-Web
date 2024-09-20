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
            ViewBag.Text2 = "Para evitar isso é nescessario cuidar de seu lixo. Confira nosso menu para mais informações";
            ViewData["pauta1"] = "Meio Ambiente";
            ViewData["pauta2"] = "Reciclagem";
            ViewData["pauta3"] = "Inovação Verde";
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
                ViewBag.Disponivel = coleta.Disponivel = "Está disponivel";
            }
            else
            {
                ViewBag.Disponivel = coleta.Disponivel = "Não está disponivel";
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
            new CalcCarbono {Materiais = "Borracha", emissaoMaterial = 2.5},
            new CalcCarbono {Materiais = "Plástico", emissaoMaterial = 6.0},
            new CalcCarbono {Materiais = "Aluminio", emissaoMaterial = 4},
            new CalcCarbono {Materiais = "Cobre", emissaoMaterial = 15.0},
            new CalcCarbono {Materiais = "Ferro", emissaoMaterial = 2.0},
            new CalcCarbono {Materiais = "Vidro", emissaoMaterial = 0.7},
            new CalcCarbono {Materiais = "Papelão", emissaoMaterial = 0.4},
            new CalcCarbono {Materiais = "Chumbo", emissaoMaterial = 9.0},
            new CalcCarbono {Materiais = "Aço", emissaoMaterial = 1.0},
            new CalcCarbono {Materiais = "Latão", emissaoMaterial = 3.5},
            new CalcCarbono {Materiais = "Ouro", emissaoMaterial = 100},
            new CalcCarbono {Materiais = "Prata", emissaoMaterial = 7},
        };

        private List<CalcGanhos> valoresGanho = new List<CalcGanhos>
        {
            new CalcGanhos {Materiais = "Borracha", cotacao = 2.5},
            new CalcGanhos {Materiais = "Plástico", cotacao = 1.2},
            new CalcGanhos {Materiais = "Aluminio", cotacao = 5},
            new CalcGanhos {Materiais = "Cobre", cotacao = 25.0},
            new CalcGanhos {Materiais = "Ferro", cotacao = 2.5},
            new CalcGanhos {Materiais = "Vidro", cotacao = 1.6},
            new CalcGanhos {Materiais = "Papelão", cotacao = 0.75},
            new CalcGanhos {Materiais = "Chumbo", cotacao = 10},
            new CalcGanhos {Materiais = "Aço", cotacao = 8.0},
            new CalcGanhos {Materiais = "Latão", cotacao = 7.5},
            new CalcGanhos {Materiais = "Ouro", cotacao = 280.0},
            new CalcGanhos {Materiais = "Prata", cotacao = 15.0},
        };



        public IActionResult CalculadoraCarbono()
        {
            ViewBag.Valores = valoresCarb;

            return View(new CalcCarbono());
        }

        public IActionResult CalculadoraGanhos()
        {
            ViewBag.Valores = valoresGanho;

            return View(new CalcGanhos());
        }

        

        [HttpPost]
        public IActionResult Calcular(CalcCarbono calcCarb)
        {
            calcCarb.emissao = calcCarb.emissaoMaterial * calcCarb.Kilos;
            ViewBag.Valores = valoresCarb;
            return View("CalculadoraCarbono", calcCarb);
        }

        [HttpPost]
        public IActionResult CalcularGanho(CalcGanhos calcGanho)
        {
            calcGanho.preco = calcGanho.cotacao * calcGanho.Kilos;
            ViewBag.Valores = valoresGanho;
            return View("CalculadoraGanhos", calcGanho);
        }
    }
}
