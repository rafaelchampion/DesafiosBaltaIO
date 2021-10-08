using System.Drawing;
using Console = Colorful.Console;

var quantidadeTermos = 20;
var sequencia = RetornarSequenciaFibonacci(quantidadeTermos);
ImprimirSequencia(sequencia);

void ImprimirSequencia(IEnumerable<int> sequencia)
{
    Console.WriteLine($"Primeiros {quantidadeTermos} termos da sequência de Fibonacci: ");

    for (int i = 0; i < quantidadeTermos; i++)
    {
        var progressao = (int)((float)i).Remapear(0, quantidadeTermos, 50, 255);
        var cor = Color.FromArgb(progressao, progressao, progressao);
        Console.WriteLine($"{sequencia.ToList()[i]}", cor);
    }
    Console.BackgroundColor = Color.Black;
    Console.ReadLine();
}

List<int> RetornarSequenciaFibonacci(int numeroTermos)
{
    var sequenciaFibonacci = new List<int>() { 0, 1 };

    if (numeroTermos <= sequenciaFibonacci.Count)
    {
        return sequenciaFibonacci;
    }

    while (sequenciaFibonacci.Count < numeroTermos)
    {
        sequenciaFibonacci.Add(sequenciaFibonacci[sequenciaFibonacci.Count - 1] + sequenciaFibonacci[sequenciaFibonacci.Count - 2]);
    }
    return sequenciaFibonacci;
}

public static class Extensions
{
    public static float Remapear(this float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }
}