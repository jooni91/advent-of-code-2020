using Xunit;

namespace AdventOfCode2020.Tests.Solutions.Day04
{
    public class Day4Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day04.Day4();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("250", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day04.Day4();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("158", result);
        }
    }
}
