using System;
using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day01
{
    public class Day1 : DayBase
    {
        protected override string Day => "01";

        protected override string PartOne(string input)
        {
            return GetMultipleOfTwo(input, 2020).ToString();
        }

        protected override string PartTwo(string input)
        {
            return GetMultipleOfThree(input, 2020).ToString();
        }

        private int GetMultipleOfTwo(string input, int sum)
        {
            var inputNumbers = input.ReadInputLines().ConvertInputsToIntegers();

            foreach (var number in inputNumbers.Where(n => n < sum))
            {
                if (inputNumbers.Contains(sum - number))
                {
                    return number * (sum - number);
                }
            }

            throw new ArgumentOutOfRangeException("Input did not contain any numbers that match the specified sum.");
        }

        private int GetMultipleOfThree(string input, int sum)
        {
            var inputNumbers = input.ReadInputLines().ConvertInputsToIntegers();

            foreach (var number1 in inputNumbers.Where(n => n < sum))
            {
                foreach (var number2 in inputNumbers.Where(n => n < sum - number1))
                {
                    var secondRequiredNumber = sum - number1 - number2;

                    if (inputNumbers.Contains(sum - number1 - number2))
                    {
                        return number1 * number2 * (sum - number1 - number2);
                    }
                }
            }

            throw new ArgumentOutOfRangeException("Input did not contain any numbers that match the specified sum.");
        }
    }
}
