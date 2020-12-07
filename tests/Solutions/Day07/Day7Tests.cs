using Xunit;

namespace AdventOfCode2020.Tests.Solutions.Day07
{
    public class Day7Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day07.Day7();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("229", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day07.Day7();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("6683", result);
        }
    }
}
