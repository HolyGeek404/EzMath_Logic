using System;

namespace Functions.Types
{
    public readonly struct Fraction
    {
        private decimal Num { get; }
        private decimal Den { get; }
        public string Value { get; } 

        public Fraction(decimal num, decimal den)
        {
            if (den == 0)
            {
                throw new ArithmeticException();
            }

            Num = num;
            Den = den;
            decimal nwd = 0;

            for (int i = (int)Math.Max(Math.Abs(Num), Math.Abs(Den)); i > 2; i--)
            {
                if (Num % i != 0 || Den % i != 0) continue;
                nwd = i;
                break;
            }

            if (nwd != 0 )
            {
                Num /= nwd;
                Den /= nwd;
            }

            Value = Num % Den == 0 ? (Num / Den).ToString() : $"{Num}/{Den}";
        }

        #region Addition

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            decimal newNum = f1.Num * f2.Den + f2.Num * f1.Den;
            decimal newDen = f1.Den * f2.Den;

            return new Fraction(newNum, newDen);
        }

        public static Fraction operator +(Fraction f1, int i)
        {
            decimal newNum = i * f1.Den + f1.Num;

            return new Fraction(newNum, f1.Den);
        }
        public static Fraction operator +(int i, Fraction f1)
        {
            decimal newNum = i * f1.Den + f1.Num;

            return new Fraction(newNum, f1.Den);
        }

        #endregion Addition

        #region Multiplication

        public static Fraction operator *(Fraction f1, string s)
        {
            if (s.Contains("/"))
            {
                string[] x = s.Split("/");
                int num = int.Parse(x[0]);
                int den = int.Parse(x[1]);

                decimal newNum = f1.Num * num;
                decimal newDen = f1.Den * den;

                return new Fraction(newNum, newDen);
            }

            if (s.Contains("."))
            {
                decimal d = Convert.ToDecimal(s);
                decimal newNum = f1.Num * d;

                return new Fraction(newNum, f1.Den);
            }
            else
            {
                int i = Convert.ToInt32(s);
                decimal newNum = f1.Num * i;

                return new Fraction(newNum, f1.Den);
            }
        }

        public static Fraction operator *(string s,Fraction f1)
        {
            if (s.Contains("/"))
            {
                string[] x = s.Split("/");
                int num = int.Parse(x[0]);
                int den = int.Parse(x[1]);

                decimal newNum = f1.Num * num;
                decimal newDen = f1.Den * den;

                return new Fraction(newNum, newDen);
            }

            if (s.Contains("."))
            {
                decimal d = Convert.ToDecimal(s);
                decimal newNum = f1.Num * d;

                return new Fraction(newNum, f1.Den);
            }
            else
            {
                int i = Convert.ToInt32(s);
                decimal newNum = f1.Num * i;

                return new Fraction(newNum, f1.Den);
            }
        }

        public static Fraction operator *(Fraction f1, decimal d)
        {
            decimal newNum = f1.Num * d;

            return new Fraction(newNum, f1.Den);
        }

        public static Fraction operator *(Fraction f1, int i)
        {
            decimal newNum = f1.Num * i;

            return new Fraction(newNum, f1.Den);
        }

        public static Fraction operator *(int i, Fraction f1)
        {
             decimal newNum = f1.Num * i;

            return new Fraction(newNum, f1.Den);
        }

        #endregion Multiplication

        #region Division

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            decimal newNum = f1.Num * f2.Den;
            decimal newDen = f1.Den * f2.Num;

            return new Fraction(newNum, newDen);
        }

        public static Fraction operator /(Fraction f1, int i)
        {
            decimal newDen = f1.Den * i;

            return new Fraction(f1.Num, newDen);
        }
        public static Fraction operator /(int i, Fraction f1)
        {
            Fraction result = new Fraction(f1.Den, f1.Num);
            return i * result;
        }

        #endregion

        #region Subtraction

        public static Fraction operator -(Fraction f1)
        {
            return f1.Num < 0 ? new Fraction(Math.Abs(f1.Num), f1.Den) : f1;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            decimal newNum = f1.Num * f2.Den - f2.Num * f1.Den;
            decimal newDen = f1.Den * f2.Den;

            return new Fraction(newNum, newDen);
        }

        public static Fraction operator -(int i, Fraction f1)
        {
            decimal newNum = i * f1.Den - f1.Num;
            return new Fraction(newNum, f1.Den);
        }
        #endregion
    }
}