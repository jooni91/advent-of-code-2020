using Xunit;

namespace AdventOfCode2020.Tests.Solutions.Day12
{
    public class Day12Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day12.Day12();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("2228", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day12.Day12();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("42908", result);
        }
    }
}
