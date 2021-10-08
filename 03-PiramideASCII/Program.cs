var alturaPiramide = 9;
DesenharPiramideAlinhadaEsquerda(alturaPiramide);
Console.WriteLine();
Console.WriteLine();
DesenharPiramideAlinhadaDireita(alturaPiramide);
Console.WriteLine();
Console.WriteLine();
DesenharPiramideAlinhadaCentro(alturaPiramide);
Console.ReadLine();


void DesenharPiramideAlinhadaEsquerda(int alturaPiramide)
{
    if (!AlturaPiramideIsValid(alturaPiramide))
    {
        return;
    }
    var largura = 1;
    for (int i = 0; i < alturaPiramide; i++)
    {
        for (int j = 0; j < largura; j++)
        {
            Console.Write("██");
        }
        Console.WriteLine();
        largura++;
    }
}

void DesenharPiramideAlinhadaDireita(int alturaPiramide)
{
    if (!AlturaPiramideIsValid(alturaPiramide))
    {
        return;
    }
    var largura = 1;
    for (int i = 0; i < alturaPiramide; i++)
    {
        for (int j = 0; j < alturaPiramide - largura; j++)
        {
            Console.Write("  ");
        }

        for (int j = largura; j > 0; j--)
        {
            Console.Write("██");
        }
        Console.WriteLine();
        largura++;
    }
}

void DesenharPiramideAlinhadaCentro(int alturaPiramide)
{
    if (!AlturaPiramideIsValid(alturaPiramide))
    {
        return;
    }
    var largura = 1;
    for (int i = 0; i < alturaPiramide; i++)
    {
        for (int j = 0; j < alturaPiramide - largura; j++)
        {
            Console.Write(" ");
        }

        for (int j = largura; j > 0; j--)
        {
            Console.Write("██");
        }
        Console.WriteLine();
        largura++;
    }
}

bool AlturaPiramideIsValid(int alturaPiramide)
{
    if (alturaPiramide < 3)
    {
        return false;
    }
    return true;
}