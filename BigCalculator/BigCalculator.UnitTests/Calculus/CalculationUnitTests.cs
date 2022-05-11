namespace BigCalculator.UnitTests.Calculus
{
    using System.Collections.Generic;
    using BigCalculator.Calculus;
    using FluentAssertions;
    using Xunit;

    public class CalculationUnitTests
    {
        private readonly ICalculation calculation;

        public CalculationUnitTests()
        {
            calculation = new Calculation();
        }

        [Fact]
        public void Given_BinaryOr_When_CorrectBinaryNumbersAreSent_Then_OrIsCalculatedCorrectly()
        {
            // Arrange
            var a = new List<int>() { 0, 0, 0, 0, 1, 1, 0, 1, 1, 0 };
            var b = new List<int>() { 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 };
            var expected = new List<int>() { 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1 };

            // Act
            var result = calculation.BinaryOr(a, b);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_BinaryOr_When_ListsAreEmpty_Then_EmptyListIsReturned()
        {
            // Arrange
            var a = new List<int>();
            var b = new List<int>();
            var expected = new List<int>();

            // Act
            var result = calculation.BinaryOr(a, b);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_BinaryOr_When_OneListIsEmpty_Then_NonEmptyListIsReturned()
        {
            // Arrange
            var a = new List<int>() { 0, 0, 0, 0, 1, 1, 0, 1, 1, 0 };
            var b = new List<int>();
            var expected = a;

            // Act
            var result = calculation.BinaryOr(a, b);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_DivideBy10_When_StringNumberIsCorrect_Then_DivisionShouldBeCalculated()
        {
            // Arrange
            var a = "1234";
            var expected = "123";

            // Act
            var result = calculation.DivideBy10(a);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_DivideBy10_When_StringNumberIsEmpty_Then_ResultShouldBeEmptyString()
        {
            // Arrange
            var a = "";
            var expected = "";

            // Act
            var result = calculation.DivideBy10(a);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_Modulo10_When_StringNumberIsCorrect_Then_ModuloShouldBeCalculated()
        {
            // Arrange
            var a = "1234";
            var expected = "4";

            // Act
            var result = calculation.Modulo10(a);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Given_Modulo10_When_StringNumberIsEmpty_Then_ResultShouldBeEmptyString()
        {
            // Arrange
            var a = "";
            var expected = "";

            // Act
            var result = calculation.Modulo10(a);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
