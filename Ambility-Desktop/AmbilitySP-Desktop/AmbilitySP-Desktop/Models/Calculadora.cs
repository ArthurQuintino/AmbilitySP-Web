namespace AmbilitySP_Desktop.Models
{
    public class Calculadora
    {
        public double Kilos { get; set; }

        public List<string> Materiais { get; set; } = new List<string> { "Borracha"};

        public double Resultado { get; set; }

        public string? OpcaoSelecionada { get; set; }

    }
}
