using System;
using Functions.Types;

namespace Liblary.Functions
{
    public class LinearF
    {
        private readonly string _a;
        private readonly string _b;
        private readonly string Form;

        public LinearF(string a, string b)
        {
            Form = $"f(x) = {a}x + {b}";
            _a = a;
            _b = b;
            Console.WriteLine(Form);
        }

        private static dynamic ReturnType(string input)
        {
            if (input.Contains("/"))
            {
                Fraction f = ReturnFraction(input);
                return f;
            }

            if (input.Contains("."))
            {
                decimal d = Convert.ToDecimal(input);
                return d;
            }

            int i = Convert.ToInt32(input);
            return i;
        }

        private static Fraction ReturnFraction(string input)
        {
            if (!input.Contains("/")) throw new ArgumentException();

            string[] x = input.Split("/");
            int num = int.Parse(x[0]);
            int den = int.Parse(x[1]);

            Fraction f = new Fraction(num, den);
            return f;
        }

        #region Function Parameters logic

        public void CalculateYForSpecificX(string input)
        {
            dynamic x = ReturnType(input);
            dynamic a = ReturnType(_a);
            dynamic b = ReturnType(_b);

            dynamic result = a * x + b;

            Console.WriteLine(result is Fraction ? result.Value : result);
        }

        public void CalculateFunctionParameters()
        {
            Console.WriteLine("---------------");

            XAxisZeroPlace();
            YAxisZeroPlace();
            Monotony();

            Console.WriteLine("---------------");
        }

        private void XAxisZeroPlace()
        {
            dynamic a = ReturnType(_a);
            if (a is Fraction)
            {
                if (a.Num == 0)
                {
                    Console.WriteLine("Nie mozna obliczyc miejsca przeciecia osi X gdy parametr A ma wartosc 0.");
                    return;
                }
            }
            else
            {
                if (a == 0)
                {
                    Console.WriteLine("Nie mozna obliczyc miejsca przeciecia osi X gdy parametr A ma wartosc 0.");
                    return;
                }
            }
            dynamic b = ReturnType(_b);

            dynamic result = -b / a;

            Console.WriteLine(result is Fraction
                ? $"Miejsce przeciecia osi X funkcji: {result.Value}"
                : $"Miejsce przeciecia osi X funkcji: {result}");
        }

        private void YAxisZeroPlace()
        {
            dynamic b = ReturnType(_b);

            Console.WriteLine(b is Fraction
                ? $"Miejsce przeciecia osi Y funkcji: {b.Value}"
                : $"Miejsce przeciecia osi Y funkcji: {b}");
        }

        private void Monotony()
        {
            var a = ReturnType(_a);

            if (a is Fraction)
            {
                if (a.Num < 0)
                {
                    Console.WriteLine("Monotonicznosc: malejaca");
                }

                if (a.Num == 0)
                {
                    Console.WriteLine("Monotonicznosc: stala");
                }

                if (a.Num > 0)
                {
                    Console.WriteLine("Monotonicznosc: rosnaca");
                }
            }
            else
            {
                if (a < 0)
                {
                    Console.WriteLine("Monotonicznosc: malejaca");
                }

                if (a == 0)
                {
                    Console.WriteLine("Monotonicznosc: stala");
                }

                if (a > 0)
                {
                    Console.WriteLine("Monotonicznosc: rosnaca");
                }
            }
        }

        #endregion

        public void IfBelongsToFunction(int x, int y)
        {
            int result = ReturnType(_a) * x + ReturnType(_b);

            Console.WriteLine(result == y ?
                $"Punkt {x},{y} nalezy do wykresu funkcji {Form}" :
                $"Punkt {x},{y} nie nalezy do wykresu funkcji {Form}");
        }
    }
}