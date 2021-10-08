using System.Drawing;
using System.Runtime.InteropServices;
using Console = Colorful.Console;

decimal valorProduto = 0;
decimal valorPago = 0;
List<decimal> listaTroco = new List<decimal>();

do
{
    Console.WriteLine("Digite o valor do produto:");
    var valorDigitado = Console.ReadLine();
    if (!decimal.TryParse(valorDigitado.Trim(), out valorProduto) || valorProduto <= 0)
    {
        Console.ForegroundColor = Color.DarkRed;
        Console.WriteLine("Valor digitado inválido. Digite novamente");
        Console.ForegroundColor = Color.White;
        Console.WriteLine();
    }
} while (valorProduto <= 0);

Console.ForegroundColor = Color.DarkGreen;
Console.WriteLine($"Valor do produto confirmado: {valorProduto.ToString("C")}");
Console.ForegroundColor = Color.White;
Console.WriteLine();

do
{
    Console.WriteLine("Digite o valor pago:");
    var valorDigitado = Console.ReadLine();
    if (!decimal.TryParse(valorDigitado.Trim(), out valorPago) || valorPago <= 0)
    {
        Console.ForegroundColor = Color.DarkRed;
        Console.WriteLine("Valor digitado inválido. Digite novamente");
        Console.ForegroundColor = Color.White;
        Console.WriteLine();
    }
    else if (valorPago < valorProduto)
    {
        valorPago = 0;
        Console.ForegroundColor = Color.DarkRed;
        Console.WriteLine("Valor pago não pode ser menor que o valor do produto. Digite novamente");
        Console.ForegroundColor = Color.White;
        Console.WriteLine();
    }
} while (valorPago <= 0);

Console.ForegroundColor = Color.DarkGreen;
Console.WriteLine($"Valor pago confirmado: {valorPago.ToString("C")}");
Console.ForegroundColor = Color.White;
Console.WriteLine();

if (valorPago == valorProduto)
{
    Console.WriteLine("Troco: R$0,00");
}
else
{
    CalcularTroco(valorPago - valorProduto);

    var agrupaTroco = from t in listaTroco
                      orderby t
                      group t by t into ot
                      select new Troco { Valor = ot.Key, Quantidade = ot.Count() };
    ImprimirTroco(agrupaTroco.ToList());
}

Console.ReadLine();

void CalcularTroco(decimal diferenca)
{
    if (diferenca > 0)
    {
        List<decimal> notas = new List<decimal> { 200, 100, 50, 20, 10, 5, 2, 1, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m };
        var primeiroValorPossivelTroco = notas.OrderByDescending(x => x).FirstOrDefault(x => (diferenca - x) >= 0);
        listaTroco.Add(primeiroValorPossivelTroco);
        if (diferenca - primeiroValorPossivelTroco > 0)
        {
            CalcularTroco(diferenca - primeiroValorPossivelTroco);
        }
    }
}

void ImprimirTroco(List<Troco> listaTroco)
{
    var dicionarioCores = new Dictionary<decimal, Color>()
    {
        { 200, Color.FromArgb(200,180,85) },
        { 100, Color.FromArgb(25,175,215) },
        { 50, Color.FromArgb(215,160,55)},
        { 20, Color.FromArgb(230,220,85) },
        { 10, Color.FromArgb(190,110,110) },
        { 5, Color.FromArgb(165,55,175) },
        { 2, Color.FromArgb(75,125,200) },
        { 1, Color.FromArgb(150,150,70) },
        { 0.5m, Color.FromArgb(125,125,125) },
        { 0.25m, Color.FromArgb(125,125,125) },
        { 0.1m, Color.FromArgb(125,125,125) },
        { 0.05m, Color.FromArgb(145,70,35) },
        { 0.01m, Color.FromArgb(145,70,35) }
    };

    foreach (var troco in listaTroco.OrderByDescending(x=>x.Valor))
    {
        var cor = dicionarioCores.FirstOrDefault(x => x.Key == troco.Valor).Value;
        Console.WriteLine($"{troco.Quantidade} {(troco.Valor > 1 ? "nota" : "moeda")}{(troco.Quantidade > 1 ? "s" : "")} de {troco.Valor.ToString("C")}", Color.FromArgb(cor.R, cor.G, cor.B));
    }
}

class Troco
{
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
}