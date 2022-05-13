using BigCalculator.Service;
using Xunit;

namespace BigCalculator.UnitTests.Service
{
    public class ComparatorUnitTests
    {
        [Theory]
        [InlineData(new int[] { 0 }, new int[] { 1 })]
        [InlineData(new int[] { 99 }, new int[] { 101 })]
        public void When_IsSmaller_Given_FirstSmallerThanSecond_Then_ReturnsTrue(int[] firstValue, int[] secondValue)
        {
            //Arrange
            var comparator = new Comparator();
            
            //Act
            var result = comparator.IsSmaller(firstValue, secondValue);
            
            //Assert
            Assert.True(result);
        }
        [Theory]
        [InlineData("0", "1")]
        [InlineData("0", "0")]
        public void When_IsSmallerOrEqual_Given_FirstSmallerOrEqualThanSecond_Then_ReturnsTrue(string firstValue, string secondValue)
        {
            //Arrange
            var comparator = new Comparator();

            //Act
            var result = comparator.IsSmallerOrEqual(firstValue, secondValue);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void When_IsEqual_Given_EqualValues_Then_ReturnsTrue()
        {
            //Arrange
            var comparator = new Comparator();
            var firstValue = "1";
            var secondValue = "1";

            //Act
            var result = comparator.IsSmallerOrEqual(firstValue, secondValue);

            //Assert
            Assert.True(result);
        }

    }
}
