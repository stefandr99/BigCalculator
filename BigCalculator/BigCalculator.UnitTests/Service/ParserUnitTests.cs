namespace BigCalculator.UnitTests.Service
{
    using BigCalculator.Service;
    using Xunit;

    public class ParserUnitTests
    {
        [Theory]
        [InlineData("a+b*(c+d)+e", "abcd+*+e+")]
        [InlineData("a^(b-c)+d", "abc-^d+")]
        [InlineData("((a+b)/(#(c-d)))", "ab+cd-#/")]
        public void Given_Parser_When_ExpressionIsValidated_then_ExpressionIsPostfixed(string input, string expected)
        {
            //Arrange
            var parser = new Parser();

            //Act
            var actualExpression = parser.MakePostfix(input);

            //Assert
            Assert.Equal(expected, actualExpression);
        }
    }
}
