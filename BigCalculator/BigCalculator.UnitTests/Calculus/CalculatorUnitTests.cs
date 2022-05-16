using BigCalculator.Calculus;
using BigCalculator.Service;
using Moq;
using Xunit;

namespace BigCalculator.UnitTests.Calculus
{
    using System.Collections.Generic;

    public class CalculatorUnitTests
    {
        private readonly ICalculator calculator;

        public CalculatorUnitTests()
        {
            var comparator = new Mock<Comparator>();
            var convertor = new Mock<Convertor>();
            var calculation = new Mock<Calculation>();

            calculator = new Calculator(comparator.Object, convertor.Object, calculation.Object);
        }

        [Fact]
        public void Given_Pow_When_NumbersArePositive_Then_ResultShouldBeCorrect()
        {
            //Arrange
            int[] baseVal = new int[] { 9 };
            int[] exponent = new int[] { 4, 8 };
            string expected = "6362685441135942358474828762538534230890216321";

            //Act
            var result = calculator.Pow(baseVal, exponent);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Pow_When_ExponentIsZero_Then_ResultIsOne()
        {
            //Arrange
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
            int[] baseVal = new int[] { 0 };
            int[] exponent = new int[] { 1, 0, 0 };

            //Act
            var result = calculator.Pow(baseVal, exponent);

            //Assert
            Assert.Equal("0", result);
        }

        [Fact]
        public void Given_Mul_When_NumbersArePositive_Then_ResultShouldBeCorrect()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 1, 2, 3, 7, 9, 6, 1, 2 };
            int[] secondOperand = new int[] { 1, 2, 5, 9, 8, 7, 4, 5, 6, 3, 1, 4, 7, 8, 9, 9, 9, 9, 8, 5, 6, 4 };

            //Act
            var result = calculator.Mul(firstOperand, secondOperand);

            //Assert
            Assert.Equal("141584214575230500453422877168", result);
        }

        [Fact]
        public void Given_Mul_When_OperandIsZero_Then_ReturnsZero()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 1 };
            int[] secondOperand = new int[] { 0 };

            //Act
            var result = calculator.Mul(firstOperand, secondOperand);

            //Assert
            Assert.Equal("0", result);
        }

        [Fact]
        public void Given_Mul_When_OperandIsOne_Then_ReturnsValueOfTheOtherOperand()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 0 };
            int[] secondOperand = new int[] { 1 };
            string expected = "10";

            //Act
            var result = calculator.Mul(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Diff_When_NumbersArePositiveAndFirstIsGreater_Then_ResultShouldBeCorrect()
        {
            //Arrange
            int[] firstOperand = new int[]
            {
                1, 5, 6, 9, 8, 5, 4, 7, 8, 9, 6, 5, 4, 9, 9, 6, 6, 5, 6, 7, 6, 5, 4, 8, 8, 5, 2, 2, 3, 6, 9, 8, 4, 2, 5
            };
            int[] secondOperand = new int[] { 9, 9, 9, 8, 7, 8, 9, 6, 5, 4, 2, 3, 1, 5, 6, 9, 8, 7, 4, 2, 5, 7, 8, 9 };
            string expected = "15698547895550087602231728236272636";

            //Act
            var result = calculator.Diff(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Diff_When_FirstOperandNumberOfNumbersDecreases_Then_ResultIsCorrect()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 0, 0 };
            int[] secondOperand = new int[] { 5 };
            string expected = "95";

            //Act
            var result = calculator.Diff(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Diff_When_SecondOperandIsZero_Then_ResultIsEqualToFirstOperand()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 0 };
            int[] secondOperand = new int[] { 0 };
            string expected = "10";

            //Act
            var result = calculator.Diff(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Diff_When_NumbersAreEqual_Then_ResultIsZero()
        {
            //Arrange
            int[] operand = new int[] { 1, 2, 3 };
            string expected = "0";

            //Act
            var result = calculator.Diff(operand, operand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Diff_When_FirstOperandIsSmallerThanSecondOperand_Then_ReturnsStatusCodeMinusOne()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 2, 3 };
            int[] secondOperand = new int[] { 1, 2, 4 };
            string expected = "-1";

            //Act
            var result = calculator.Diff(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Sum_When_NumbersArePositive_Then_ResultShouldBeCorrect()
        {
            //Arrange
            int[] firstOperand = new int[]
            {
                1, 2, 3, 9, 8, 7, 4, 6, 9, 8, 7, 8, 9, 8, 7, 9, 6, 3, 2, 5, 4, 2, 1, 9, 8, 7, 5, 6, 3, 2, 1, 4, 8, 9, 7
            };
            int[] secondOperand = new int[]
            {
                8, 9, 8, 7, 4, 5, 6, 9, 8, 9, 6, 5, 3, 2, 3, 2, 3, 6, 5, 9, 8, 7, 4, 5, 6, 3, 2, 1, 4, 5, 6, 9, 8, 7, 4,
                5, 6, 9, 8, 7, 8, 9, 6, 5, 4, 5, 6, 9, 8, 7, 8, 9
            };
            string expected = "8987456989653232378386203309355783782409884108913686";

            //Act
            var result = calculator.Sum(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Sum_When_OneOperandIsZero_Then_ResultIsEqualToTheOtherOperand()
        {
            //Arrange
            int[] firstOperand = new int[] { 1, 2, 3 };
            int[] secondOperand = new int[] { 0 };
            string expected = "123";

            //Act
            var result = calculator.Sum(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Div_When_OneOperandIsZero_Then_ResultIsEqualToTheOtherOperand()
        {
            //Arrange
            int[] firstOperand = new int[]
            {
                8, 9, 8, 7, 4, 5, 6, 9, 8, 9, 6, 5, 3, 2, 3, 2, 3, 6, 5, 9, 8, 7, 4, 5, 6, 3, 2, 1, 4, 5, 6, 9, 8, 7, 4,
                5, 6, 9, 8, 7, 8, 9, 6, 5, 4, 5, 6, 9, 8, 7, 8, 9
            };
            int[] secondOperand = new int[]
            {
                1, 2, 3, 9, 8, 7, 4, 6, 9, 8, 7, 8, 9, 8, 7, 9, 6, 3, 2, 5, 4, 2, 1, 9, 8, 7, 5, 6, 3, 2, 1, 4, 8, 9, 7
            };
            string expected = "724868165986854129";

            //Act
            var result = calculator.Div(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Div_When_DivisorIsZero_Then_MinusTwoIsReturned()
        {
            //Arrange
            int[] firstOperand = new int[] { 8, 9, 8, 7, 4 };
            int[] secondOperand = new int[] { 0 };
            string expected = "-2";

            //Act
            var result = calculator.Div(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Div_When_DividendIsSmallerThanDivisor_Then_ResultShouldBeZero()
        {
            //Arrange
            int[] firstOperand = new int[] { 8, 9, 8, 7, 4 };
            int[] secondOperand = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            string expected = "0";

            //Act
            var result = calculator.Div(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Div_When_DividendAndDivisorAreEqual_Then_ResultShouldBeOne()
        {
            //Arrange
            int[] firstOperand = new int[] { 8, 9, 8, 7, 4 };
            int[] secondOperand = new int[] { 8, 9, 8, 7, 4 };
            string expected = "1";

            //Act
            var result = calculator.Div(firstOperand, secondOperand);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Sqrt_When_NumberIsPositive_Then_ResultShouldBeCorrect()
        {
            //Arrange
            int[] number = new int[] { 8, 9, 8, 5, 7, 1, 6, 8, 5, 4, 2 };
            string expected = "299761";

            //Act
            var result = calculator.Sqrt(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Sqrt_When_NumberIsZero_Then_ResultShouldBeZero()
        {
            //Arrange
            int[] number = new int[] { 0 };
            string expected = "0";

            //Act
            var result = calculator.Sqrt(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_Sqrt_When_NumberIsNegative_Then_ResultShouldBeMinusOne()
        {
            //Arrange
            int[] number = new int[] { -9, 8, 9, 4 };
            string expected = "-1";

            //Act
            var result = calculator.Sqrt(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromDecimalToBinary_When_NumberIsPositive_Then_ResultShouldBeCorrect()
        {
            //Arrange
            List<int> number = new() { 9, 5, 4, 7, 8, 5, 6, 3, 2, 1, 5, 4, 8, 6, 5, 2, 4, 8, 9, 7 };
            List<int> expected = new()
            {
                1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0,
                1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1
            };

            //Act
            var result = calculator.FromDecimalToBinary(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromDecimalToBinary_When_NumberIsNegative_Then_ResultShouldBeMinusOne()
        {
            //Arrange
            List<int> number = new() { -9, 5, 4, 7, 8, 5, 6, 3, 2, 1, 5, 4, 8, 6, 5, 2, 4, 8, 9, 7 };
            List<int> expected = new() { -1 };

            //Act
            var result = calculator.FromDecimalToBinary(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromBinaryToDecimal_When_BinaryIsCorrect_Then_ConversionShouldBeCalculatedCorrectly()
        {
            //Arrange
            List<int> binary = new()
            {
                1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0,
                1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1
            };
            List<int> expected = new() { 9, 5, 4, 7, 8, 5, 6, 3, 2, 1, 5, 4, 8, 6, 5, 2, 4, 8, 9, 7 };

            //Act
            var result = calculator.FromBinaryToDecimal(binary);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromBinaryToDecimal_When_BinaryIsIncorrect_Then_ConversionShouldReturnMinusOne()
        {
            //Arrange
            List<int> binary = new() { 1, 0, 1, 0, 2, 1 };
            List<int> expected = new() { -1 };

            //Act
            var result = calculator.FromBinaryToDecimal(binary);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
