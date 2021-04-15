using System;
using Liblary.Functions;

namespace Main_Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Podstawowe parametry i wartosci dla funkcji liniowej f(x) = ax + b");
            Console.WriteLine("Podaj wzor funkcji: ");

            Console.Write("Parametr a: ");
            string a = Console.ReadLine();

            Console.Write("Parametr b: ");
            string b = Console.ReadLine();

            LinearF linearF = new LinearF(a, b);

            Console.Write("Wartosc funkcji dla x: ");
            string x = Console.ReadLine();

            linearF.CalculateYForSpecificX(x);
            linearF.CalculateFunctionParameters();
            Console.WriteLine("Podaj x");
            int z = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj y");
            int y = int.Parse(Console.ReadLine());


            linearF.IfBelongsToFunction(z, y);

        }
    }
}
