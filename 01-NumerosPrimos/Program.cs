var numeroMaximoaValidar = 1000;
var numeros = Enumerable.Range(0, numeroMaximoaValidar);
ValidadarEscreverNumerosPrimos(numeros);

void ValidadarEscreverNumerosPrimos(IEnumerable<int> numerosValidar){
    var quantidadeZerosPadding = numerosValidar.Max().ToString().Length;

    Console.Write("|");
    foreach (var numero in numerosValidar)
    {
        EscreverNumero(numero, quantidadeZerosPadding);
    }
    Console.Write("|");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadKey();
    Console.ReadKey();
    Console.ReadKey();
}

void EscreverNumero(int numero, int quantidadePadding)
{
    var isPrime = ValidaNumeroPrimo(numero);
    Console.Write("|");
    Console.BackgroundColor = isPrime ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
    Console.ForegroundColor = isPrime ? ConsoleColor.Black : ConsoleColor.Black;
    Console.Write($"{numero.ToString().PadLeft(quantidadePadding, '0')} {(isPrime ? "SIM" : "NÃO")}");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("|");
}

bool ValidaNumeroPrimo(long number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var sqrtNumber = (long)Math.Sqrt(number);
    for (long i = 3; i <= sqrtNumber; i+=2)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}