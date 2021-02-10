using System;
using Functions.Types;

namespace Functions
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                //Fraction f1 = new Fraction(1, 3);
                //int x = 3;
                //Fraction f2 = new Fraction(1, 3);
                //Fraction result = x - f2;
                //Console.WriteLine(result.Value);

                Console.WriteLine("Podstawowe parametry i wartosci dla funkcji liniowej f(x) = ax + b");
                Console.WriteLine("Podaj wzor funkcji: ");

                Console.Write("Parametr a: ");
                string a = Console.ReadLine();

                Console.Write("Parametr b: ");
                string b = Console.ReadLine();

                LinearF linearF = new LinearF(a, b);

                //Console.Write("Wartosc funkcji dla x: ");
                //string x = Console.ReadLine();

                //linearF.CalculateYForSpecificX(x);
                //linearF.CalculateFunctionParameters();
                Console.WriteLine("Podaj x");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj y");
                int y = int.Parse(Console.ReadLine());


                linearF.IfBelongsToFunction(x,y);

            }
        }
    }
}