using Xunit;

namespace AdventOfCode2020.Tests.Solutions.Day02
{
    public class Day2Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day02.Day2();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("548", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day02.Day2();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("502", result);
        }
    }
}
