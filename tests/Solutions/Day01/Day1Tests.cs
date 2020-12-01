using Xunit;

namespace AdventOfCode2020.Tests.Solutions.Day01
{
    public class Day1Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day01.Day1();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("381699", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2020.Solutions.Day01.Day1();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("111605670", result);
        }
    }
}
