using BigCalculator.Calculus;
using BigCalculator.Service;
using Moq;
using Xunit;

namespace BigCalculator.UnitTests.Calculus
{
    public class CalculatorUnitTests
    {
        private Calculator CreateNewCalculator()
        {
            var compator = new Mock<Comparator>();
            var convertor = new Mock<Convertor>();
            var calculation = new Mock<Calculation>();

            return new Calculator(compator.Object, convertor.Object, calculation.Object);
        }

        [Fact]
        public void Given_Pow_When_ExponentIsZero_Then_ResultIsOne()
        {
            //Arrange
            var calculator = CreateNewCalculator();

            int[] baseVal = new int[] { 1, 0, 0 };
            int[] exponent = new int[] { 0 };

            //Act
            var result = calculator.Pow(baseVal, exponent);

            //Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void Given_Pow_When_ExponentIsOne_Then_ResultIsEqualToBase()
        {
            //Arrange
            var calculator = CreateNewCalculator();

            int[] baseVal = new int[] { 1, 0, 0 };
            int[] exponent = new int[] { 1 };
            string expected = "100";

            //Act
            var result = calculator.Pow(baseVal, exponent);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Pow_When_BaseIsZero_Then_ResultIsZero()
        {
            //Arrange
            var calculator = CreateNewCalculator();

            int[] baseVal = new int[] { 0 };
            int[] exponent = new int[] { 1, 0, 0 };

            //Act
            var result = calculator.Pow(baseVal, exponent);

            //Assert
            Assert.Equal("0", result);
        }
    }
}
