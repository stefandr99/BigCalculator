namespace BigCalculator.UnitTests.Validator
{
    using BigCalculator.Core;
    using BigCalculator.Validator;
    using Core;
    using FluentAssertions;
    using FluentAssertions.Execution;
    using Generators;
    using Xunit;

    public class ValidatorUnitTests
    {
        private readonly Validator validator;
        private readonly IValidator operatorsValidator;
        private readonly IValidator parenthesesValidator;
        private readonly IValidator symbolsValidator;
        private readonly IValidator termsValidator;

        public ValidatorUnitTests()
        {
            validator = new Validator();
            operatorsValidator = new OperatorsValidator();
            parenthesesValidator = new ParenthesesValidator();
            symbolsValidator = new SymbolsValidator();
            termsValidator = new TermsValidator();
        }

        [Theory]
        [ClassData(typeof(SuccessGenerator))]
        public void Given_OperatorsValidate_When_ExpressionIsCorrect_Then_ValidationPasses(Data data)
        {
            // Arrange
            var expected = new SuccessResult<string>("Success!");

            // Act
            var result = operatorsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().BeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(OperatorsFailGenerator))]
        public void Given_OperatorsValidate_When_ExpressionIsIncorrect_Then_ValidationFails(Data data)
        {
            // Arrange
            var expected = new InvalidResult<string>("Wrong format!");

            // Act
            var result = operatorsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().NotBeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(SuccessGenerator))]
        public void Given_ParenthesesValidate_When_ExpressionIsCorrect_Then_ValidationPasses(Data data)
        {
            // Arrange
            var expected = new SuccessResult<string>("Success!");

            // Act
            var result = parenthesesValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().BeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(ParenthesesFailGenerator))]
        public void Given_ParenthesesValidate_When_ExpressionIsIncorrect_Then_ValidationFails(Data data)
        {
            // Arrange
            var expected = new InvalidResult<string>("Invalid parentheses!");

            // Act
            var result = parenthesesValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().NotBeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(SuccessGenerator))]
        public void Given_SymbolsValidate_When_ExpressionIsCorrect_Then_ValidationPasses(Data data)
        {
            // Arrange
            var expected = new SuccessResult<string>("Success!");

            // Act
            var result = symbolsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().BeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(SymbolsFailGenerator))]
        public void Given_SymbolsValidate_When_ExpressionIsIncorrect_Then_ValidationFails(Data data)
        {
            // Arrange
            var expected = new InvalidResult<string>("Invalid symbols!");

            // Act
            var result = symbolsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().NotBeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(SuccessGenerator))]
        public void Given_TermsValidate_When_ExpressionIsCorrect_Then_ValidationPasses(Data data)
        {
            // Arrange
            var expected = new SuccessResult<string>("Success!");

            // Act
            var result = termsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().BeEmpty();
            }
        }

        [Theory]
        [ClassData(typeof(TermsFailGenerator))]
        public void Given_TermsValidate_When_ExpressionIsIncorrect_Then_ValidationFails(Data data)
        {
            // Arrange
            var expected = new InvalidResult<string>("Invalid terms!");

            // Act
            var result = termsValidator.Validate(data);

            // Assert
            using (new AssertionScope())
            {
                Assert.Equal(expected.Data, result.Data);
                Assert.Equal(expected.ResultType, result.ResultType);
                Assert.Equal(expected.Errors, result.Errors);
                result.Errors.Should().NotBeEmpty();
            }
        }
    }
}
