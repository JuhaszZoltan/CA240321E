//Tombok001();
//Tombok002();
//Tombok004();
//Tombok005();
//Tombok006();
//Tombok007();

FeltetelesCiklusok001();

static void FeltetelesCiklusok001()
{
    Random rnd = new();

    int csillagPontszam = 0;
    int kukacPontszam = 0;

    Console.WriteLine("@ vs. *!");
    Console.Write("szerinted ki nyeri a viadalt (* || @)? ");
    var fogadas = Console.ReadLine();
    Console.WriteLine($"\n{fogadas}-ra fogadtál, mehet a menet!");
    Thread.Sleep(1000);

    Console.CursorVisible = false;

    for (int i = 0; i < 10; i++)
    {
        Console.Clear();
        Console.WriteLine($"{i+1}. futam:");

        for (int c = 0; c < 5; c++)
        {
            Console.SetCursorPosition(50, c);
            Console.Write('|');
        }

        int csillag = 0;
        int kukac = 0;
        while (csillag < 50 && kukac < 50)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(csillag, 1);
            Console.Write('*');
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(kukac, 3);
            Console.Write('@');
            Console.ResetColor();
            Thread.Sleep(100);

            if (csillag > 50 == kukac > 50)
            {
                Console.SetCursorPosition(csillag, 1);
                Console.Write('_');
                Console.SetCursorPosition(kukac, 3);
                Console.Write('_');
            }

            csillag += rnd.Next(1, 4);
            kukac += rnd.Next(1, 4);
        }
        Console.SetCursorPosition(0, 5);
        Console.Write($"{i+1}. futam eredménye: ");
        if (csillag >= 50 && kukac >= 50) Console.WriteLine("döntetlen!");
        else if (csillag >= 50)
        {
            Console.WriteLine("csillag győzőtt!");
            csillagPontszam++;
        }
        else
        {
            Console.WriteLine("kukac győzött!");
            kukacPontszam++;
        }

        if (i+1 != 10) Console.WriteLine($"\n{i+2}. futam kezdéséhez nyomjon ENTERT-t!");
        else Console.WriteLine("végeredmény megtekintéséhez nyomjon ENTER-t!");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
    }

    Console.Clear();
    Console.WriteLine($"csillag győzelmei: {csillagPontszam} db");
    Console.WriteLine($"kukac győzelmei: {kukacPontszam} db");
    char gyoztes = '_';
    if (csillagPontszam == kukacPontszam) Console.WriteLine("az eredmény döntetlen!");
    else if (csillagPontszam > kukacPontszam)
    {
        Console.WriteLine("csillag győzött!");
        gyoztes = '*';
    }
    else
    {
        Console.WriteLine("kukac győzött!");
        gyoztes = '@';
    }

    if ((fogadas[0]) == gyoztes) Console.WriteLine("megnyerted a fogadást!");
    else Console.WriteLine("elveszítetted a fogadást!");

}

static void Tombok007()
{
    bool[] borton = new bool[100];
    //nyitva => true | zárva -> false;
    for (int sz = 0; sz < 100; sz++)
    {
        for (int a = sz; a < borton.Length; a += (sz+1))
        {
            borton[a] = !borton[a];
        }

        Console.Write($"{sz+1,3}. szolga: ");
        for (int a = 0; a < borton.Length; a++)
        {            
            if (borton[a])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("O");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("C");
            }
            Console.ResetColor();
        }
        Console.Write('\n');
    }

    Console.Write("nyitva hagyott cellák sorszáma: ");
    for (int i = 0; i < borton.Length; i++) if (borton[i]) Console.Write($"{i+1}., ");
}
static void Tombok006()
{
    Random rnd = new();
    var kulombozo = new int[50];
    int lefutasokSzama = 0;

    for (int i = 0; i < kulombozo.Length; )
    {
        int szam = rnd.Next(10, 100);
        if (!kulombozo.Contains(szam))
        {
            kulombozo[i] = szam;
            i++;
        }
        lefutasokSzama++;
    }

    Array.Sort(kulombozo);
    for (int i = 0; i < kulombozo.Length; i++)
    {
        Console.Write($"{kulombozo[i]} ");
        if ((i+1) % 10 == 0) Console.Write('\n');
    }
    Console.WriteLine($"lefutások száma: {lefutasokSzama}");
}
static void Tombok005()
{
    Random rnd = new();
    var szamok = new int[50];
    for (int i = 0; i < szamok.Length; i++)
    {
        szamok[i] = rnd.Next(5, 50) * 2 + 1;
        if (szamok[i] == 13) Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(szamok[i]+ " ");
        Console.ResetColor();
        if ((i + 1) % 10 == 0) Console.Write('\n');
    }

    if (szamok.Contains(13)) Console.WriteLine("van benne 13");
    else Console.WriteLine("nincs benne 13");

    int ind = 0;
    while (ind < szamok.Length && szamok[ind] != 13) ind++;
    Console.WriteLine($"{(ind < szamok.Length ? "van" : "nincs")} benne 13");
}
static void Tombok004()
{
    var nevek = new string[10];
    string nev = ".";
    int index = 0;

    //while (index < nevek.Length && nev != string.Empty)
    //{
    //    Console.Write($"írja ba a {index+1}. nevet: ");
    //    nev = Console.ReadLine();
    //    if (nev != string.Empty)
    //    {
    //        nevek[index] = nev;
    //        index++;
    //    }
    //}
    int i;
    for (i = 0; i < nevek.Length; i++)
    {
        Console.Write($"írja ba a {i + 1}. nevet: ");
        nev = Console.ReadLine();
        if (nev != string.Empty) nevek[i] = nev;
        else break;
    }

    Array.Resize(ref nevek, i);
    Array.Sort(nevek);
    foreach (var n in nevek) Console.Write($"{n} - ");
}
static void Tombok002()
{
    Random rnd = new();

    int kerek = 0;
    var szamok = new int[20];
    for (int i = 0; i < szamok.Length; i++)
    {
        szamok[i] = rnd.Next(50, 151);
        if (szamok[i] % 10 == 0)
        {
            kerek++;
            Console.ForegroundColor = ConsoleColor.Green;
        }
        Console.Write($"{szamok[i],3} ");
        if ((i + 1) % 5 == 0) Console.Write('\n');
        Console.ResetColor();
    }
    Console.WriteLine($"szamok osszege: {szamok.Sum()}");
    Console.WriteLine($"szamok atlaga: {szamok.Average()}");
    Console.WriteLine($"nullara vegzodik: {kerek} db");
}
static void Tombok001()
{
    string[] nevek = ["Béla", "Csenge", "Erika", "Dávid", "Ádám",];
    int[] magassagok = new int[5];

    int osszmagassag = 0;
    for (int i = 0; i < nevek.Length; i++)
    {
        Console.Write($"{nevek[i]} magasságas (cm): ");
        int magassag = int.Parse(Console.ReadLine());
        magassagok[i] = magassag;
        osszmagassag += magassagok[i];
    }
    Console.WriteLine("--atlag--");
    Console.WriteLine($"átlagmagasság: {osszmagassag / magassagok.Length:0.00} cm");
    Console.WriteLine($"avg magassag (magyshogy): {magassagok.Average():0.00} cm");

    Array.Sort(magassagok, nevek);
    //Array.Reverse(magassagok);
    //Array.Reverse(nevek);

    //for (int i = 0; i < nevek.Length - 1; i++)
    //{
    //    for (int j = i + 1; j < nevek.Length; j++)
    //    {
    //        if (nevek[i][0] > nevek[j][0])
    //        {
    //            string csereNev = nevek[i];
    //            nevek[i] = nevek[j];
    //            nevek[j] = csereNev;

    //            int csereMagassag = magassagok[i];
    //            magassagok[i] = magassagok[j];
    //            magassagok[j] = csereMagassag;
    //        }
    //    }
    //}
    Console.WriteLine("--rendezve:--");
    for (int i = 0; i < nevek.Length; i++)
    {
        Console.WriteLine($"{nevek[i]}: {magassagok[i]}cm");
    }
    Console.WriteLine("--megmagasabb:--");
    Console.WriteLine($"legmagasabb: {nevek[^1]} ({magassagok[magassagok.Length - 1]})");
    int maxIndex = 0;
    for (int i = 1; i < magassagok.Length; i++)
    {
        if (magassagok[i] > magassagok[maxIndex])
        {
            maxIndex = i;
        }
    }

    Console.WriteLine($"legnagyobb érték: {magassagok[maxIndex]}");
    Console.WriteLine($"legnagyobb érték indexe: {maxIndex}");
    Console.WriteLine($"legmagasabb személy neve: {nevek[maxIndex]}");

    Console.WriteLine($"a legmagasabb személy: {nevek[Array.IndexOf(magassagok, magassagok.Max())]}");
}

Console.ReadKey();