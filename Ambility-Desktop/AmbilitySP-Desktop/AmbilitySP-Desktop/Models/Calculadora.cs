namespace AmbilitySP_Desktop.Models
{
    public class Calculadora
    {
        public double Kilos { get; set; }

        public List<string> materiais { get; set; } = new List<string> { "Borracha", "Metal", "Plastico" };

        public double Resultado { get; set; }

        public string OpcaoSelecionada { get; set; }
    }
}
