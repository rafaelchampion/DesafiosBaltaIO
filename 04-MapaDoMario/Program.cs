using System.Text;

var movimento = ConsoleKey.F15;
var largura = 20;
var altura = 20;
var posxAtual = 0;
var posxPersonagem = 12;
var posyPersonagem = 16;
Console.OutputEncoding = Encoding.UTF8;

var mapa = new char[,]
{
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','C','E','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','C','C','C','C','C','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','L','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','e','M','e','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','C','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','C','C','C','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','S','F','S','S','S','S','S','S','S','S','S','S','S','S','S' },
    { 'G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G', 'G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G','G'},
    { 'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','B','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X' },
    { 'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','B','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X' }
};

var dicionario = new Dictionary<char, string>()
{
    { 'X', "🟫" },
    { 'G', "🟩" },
    { 'S', "🟦" },
    { 'C', "⚪" },
    { 'E', "👀" },
    { 'e', "👁" },
    { 'M', "👄" },
    { 'F', "🏁" },
    { 'B', "🦴" },
    { 'H', "🌿" },
    { 'L', "🦅" }
};

do
{
    Console.Clear();
    DesenharTela(mapa, dicionario, posxPersonagem, posyPersonagem);
    movimento = ReceberProximoMovimento();
} while (movimento != ConsoleKey.Escape);

string BuscarNoDicionario(char termo, Dictionary<char, string> dicionario)
{
    return dicionario.FirstOrDefault(x => x.Key == termo).Value;
}

void DesenharTela(char[,] mapa, Dictionary<char, string> dicionario, int posxPersonagem, int posyPersonagem)
{
    for (int y = 0; y < largura; y++)
    {
        for (int x = 0 + posxAtual; x < altura + posxAtual; x++)
        {

            if (Console.GetCursorPosition().Left == posxPersonagem && Console.GetCursorPosition().Top == posyPersonagem)
            {
                Console.Write("😃‍");
            }
            else
            {
                Console.Write(BuscarNoDicionario(mapa[y, x], dicionario));
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine($"Última tecla pressionada: {movimento.ToString()}");
}

ConsoleKey ReceberProximoMovimento()
{
    var teclaPressionada = Console.ReadKey().Key;
    if (movimento == ConsoleKey.RightArrow && posxAtual < 80)
    {
        posxAtual++;
    }
    if (movimento == ConsoleKey.LeftArrow && posxAtual > 0)
    {
        posxAtual--;
    }
    return teclaPressionada;
}
