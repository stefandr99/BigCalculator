namespace BigCalculator.UnitTests.Adapter
{
    using BigCalculator.Adapter;
    using BigCalculator.Calculus;
    using BigCalculator.Service;
    using Moq;
    using System.Collections.Generic;
    using Xunit;

    public class ComputeUnitTests
    {
        private Compute CreateDefaultComputeIntance()
        {
            var convertor = new Mock<Convertor>();
            var comparator = new Mock<Comparator>();
            var calculation = new Mock<Calculation>();
            var calculator = new Mock<Calculator>(comparator.Object, convertor.Object, calculation.Object);

            var compute = new Compute(convertor.Object, calculator.Object);

            return compute;
        }
        [Fact]
        public void When_ComputeCalculus_Given_ValidPostfixedExpressionAndTerms_Then_ExpectedResultIsReturned()
        {
            //Arrange
            var compute = CreateDefaultComputeIntance();

            string posfixedExpression = "abcd-a^*+";
            Dictionary<string, string> terms = new Dictionary<string, string>()
            {
                {"a","2" },
                {"b","3"},
                {"c","7"},
                {"d","5"},
            };

            //Act
            var computationResult = compute.ComputeCalculus(posfixedExpression, terms);

            //Assert
            Assert.Equal("14", computationResult.Data["final result"]);
        }

        [Fact]
        public void When_ComputeCalculus_Given_ValidPostfixedExpressionAndTerms_Then_EachStepOfComputationIsReturned()
        {
            //Arrange
            var compute = CreateDefaultComputeIntance();
            string posfixedExpression = "abcd-a^*+";
            Dictionary<string, string> terms = new Dictionary<string, string>()
            {
                {"a","2" },
                {"b","3"},
                {"c","7"},
                {"d","5"},
            };
            var expected = new Dictionary<string, string>()
            {
                {"operation 1", "c - d = 2" },
                {"operation 2", "2 ^ a = 4" },
                {"operation 3", "b * 4 = 12" },
                {"operation 4", "a + 12 = 14" }
            };

            //Act
            var computationResult = compute.ComputeCalculus(posfixedExpression, terms);
            computationResult.Data.Remove("final result");

            //Assert
            Assert.Equal(expected, computationResult.Data);
        }
    }
}
