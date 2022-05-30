namespace BigCalculator.UnitTests.Service
{
    using BigCalculator.Service;
    using Xunit;

    public class ComparatorUnitTests
    {
        private readonly IComparator comparator;

        public ComparatorUnitTests()
        {
            this.comparator = new Comparator();
        }

        [Theory]
        [InlineData(new[] { 0 }, new[] { 1 })]
        [InlineData(new[] { 99 }, new[] { 101 })]
        public void When_IsSmaller_Given_FirstSmallerThanSecond_Then_ReturnsTrue(int[] firstValue, int[] secondValue)
        {
            //Act
            var result = comparator.IsSmaller(firstValue, secondValue);
            
            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("0", "1")]
        [InlineData("0", "0")]
        [InlineData("1010101", "1010101")]
        public void Given_IsSmallerOrEqual_When_FirstSmallerOrEqualThanSecond_Then_ReturnsTrue(string firstValue, string secondValue)
        {
            //Act
            var result = comparator.IsSmallerOrEqual(firstValue, secondValue);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("0", "0")]
        [InlineData("1010101", "1010101")]
        [InlineData("9845613215649855616549845316549879864163", "9845613215649855616549845316549879864163")]
        public void Given_AreEqual_When_EqualValues_Then_ReturnsTrue(string firstValue, string secondValue)
        {
            //Act
            var result = comparator.AreEqual(firstValue, secondValue);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("0", "1")]
        [InlineData("101011", "1010101")]
        [InlineData("98456132156498556165498453165498798641634", "9845613215649855616549845316549879864163")]
        public void Given_AreEqual_When_NotEqualValues_Then_ReturnsFalse(string firstValue, string secondValue)
        {
            //Act
            var result = comparator.AreEqual(firstValue, secondValue);

            //Assert
            Assert.False(result);
        }
    }
}
