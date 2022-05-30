namespace BigCalculator.UnitTests.Core
{
    using BigCalculator.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ExtensionUnitTests
    {
        [Fact]
        public void Given_FromDataTermsToDictionary_When_TermsAreCorrect_Then_MappingIsCorrect()
        {
            // Arrange
            Data data = new()
            {
                Expression = "a+b*c+(b*c)*#(c)/(a+c)",
                Terms = new List<Term>
                {
                    new Term { Name = "a", Value = "10" },
                    new Term { Name = "b", Value = "10" },
                    new Term { Name = "c", Value = "10" },
                }
            };
            Dictionary<string, string> expected = new()
            {
                { "a", "10" },
                { "b", "10" },
                { "c", "10" },
            };

            // Act
            Dictionary<string, string> result = data.FromDataTermsToDictionary();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
