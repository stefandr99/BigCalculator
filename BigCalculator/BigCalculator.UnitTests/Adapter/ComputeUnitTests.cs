namespace BigCalculator.UnitTests.Adapter
{
    using BigCalculator.Adapter;
    using BigCalculator.Calculus;
    using BigCalculator.Core;
    using BigCalculator.Service;
    using FluentAssertions.Execution;
    using Moq;
    using System.Collections.Generic;
    using Xunit;

    public class ComputeUnitTests
    {
        private readonly ICompute compute;

        public ComputeUnitTests()
        {
            var convertor = new Mock<Convertor>();
            var comparator = new Mock<Comparator>();
            var calculation = new Mock<Calculation>();
            var calculator = new Mock<Calculator>(comparator.Object, convertor.Object, calculation.Object);

            compute = new Compute(convertor.Object, calculator.Object);
        }

        [Fact]
        public void Given_ComputeCalculus_When_ValidPostfixedExpressionAndTerms_Then_ExpectedResultIsReturned()
        {
            //Arrange
            string posfixedExpression = "abcd-a^*+#";
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
            Assert.Equal("3", computationResult.Data["final result"]);
        }

        [Fact]
        public void Given_ComputeCalculus_When_InvalidPostfixedExpressionAndTermsAndReturnsMinusOne_Then_ExpectedResultIsReturned()
        {
            //Arrange
            string posfixedExpression = "abcd-a^*+#";
            Dictionary<string, string> terms = new Dictionary<string, string>()
            {
                {"a","2" },
                {"b","3"},
                {"c","7"},
                {"d","9"},
            };
            var error = "Negative result of subsctraction: c - d";
            var dict = new Dictionary<string, string> { { "error", error } };
            var expected = new IncorrectCalculus<Dictionary<string, string>>(dict);

            //Act
            var computationResult = compute.ComputeCalculus(posfixedExpression, terms);

            //Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, computationResult.Data);
                Assert.Equal(expected.ResultType, computationResult.ResultType);
                Assert.Equal(expected.Errors, computationResult.Errors);
            }
        }

        [Fact]
        public void Given_ComputeCalculus_When_InvalidPostfixedExpressionAndTermsAndReturnsMinusTwo_Then_ExpectedResultIsReturned()
        {
            //Arrange
            string posfixedExpression = "abcd/a^*+#";
            Dictionary<string, string> terms = new Dictionary<string, string>()
            {
                {"a","2" },
                {"b","3"},
                {"c","7"},
                {"d","0"},
            };
            var error = "Attempt of division by zero: c / d";
            var dict = new Dictionary<string, string> { { "error", error } };
            var expected = new IncorrectCalculus<Dictionary<string, string>>(dict);

            //Act
            var computationResult = compute.ComputeCalculus(posfixedExpression, terms);

            //Assert
            Assert.Equal(expected.Data, computationResult.Data);
        }

        [Fact]
        public void Given_ComputeCalculus_Then_ValidPostfixedExpressionAndTerms_Then_EachStepOfComputationIsReturned()
        {
            //Arrange
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
