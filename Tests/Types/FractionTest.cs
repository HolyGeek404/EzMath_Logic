using Xunit;
using Functions.Types;

namespace Tests.Types
{
    
    public class FractionTest
    {
        [Theory]
        [InlineData(4, 8,"1/2")]
        [InlineData(4, -8,"1/-2")]
        [InlineData(-4, 8,"-1/2")]
        [InlineData(-8, -4,"2")]
        [InlineData(6, 9,"2/3")]
        [InlineData(5, 25,"1/5")]
        [InlineData(8, 12,"2/3")]
        [InlineData(4, 16,"1/4")]
        [InlineData(25, 30,"5/6")]
        [InlineData(-8, 4,"-2")]
        [InlineData(-12, -8,"-3/-2")]
        [InlineData(-12, 8,"-3/2")]
        public void Rounding(decimal num, decimal den, string expected)
        {
            Fraction fraction = new Fraction(num, den);  

            Assert.Equal(expected, fraction.Value);
        }

        //[Theory]
        //[InlineData(4, 8, "1/2","1")]
        //public void Addition(decimal num, decimal den, string value, string expected)
        //{
        //    Fraction fraction = new Fraction(num, den);
        //    Fraction result = fraction;

        //    Assert.Equal(expected, fraction.Value);
        //}
    }
}
