using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day09
{
    public class Day9 : DayBase
    {
        protected override string Day => "09";

        protected override string PartOne(string input)
        {
            return FindInvalidNumber(input.ReadInputLines().ConvertInputsToLongs().ToArray()).ToString();
        }

        protected override string PartTwo(string input)
        {
            var numbers = input.ReadInputLines().ConvertInputsToLongs().ToArray();

            return FindEncryptionWeakness(numbers, FindInvalidNumber(numbers)).ToString();
        }

        private long FindInvalidNumber(long[] numbers)
        {
            long invalidNumber = -1;

            for (int i = 25; i < numbers.Length; i++)
            {
                var preamble = numbers[(i - 25)..i].Where(num => num < numbers[i]).ToArray();

                if (!preamble.Any(num1 => preamble.Any(num2 => num1 != num2 && (num1 + num2) == numbers[i])))
                {
                    invalidNumber = numbers[i];
                    break;
                }
            }

            return invalidNumber;
        }

        private long FindEncryptionWeakness(long[] numbers, long invalidNumber)
        {
            long encryptionWeakness = -1;

            for (int minRange = 0; minRange < numbers.Length; minRange++)
            {
                long sum = numbers[minRange];
                int maxRange;

                for (maxRange = minRange + 1; maxRange < numbers.Length; maxRange++)
                {
                    sum += numbers[maxRange];

                    if (sum >= invalidNumber)
                    {
                        break;
                    }
                }

                if (sum == invalidNumber)
                {
                    var contiguesRange = numbers[minRange..(maxRange + 1)];
                    var largestNumber = contiguesRange.Aggregate(0L, (largest, next) => next > largest ? next : largest);
                    var smallestNumber = contiguesRange.Aggregate(largestNumber, (smallest, next) => next < smallest ? next : smallest);

                    encryptionWeakness = smallestNumber + largestNumber;
                    break;
                }
            }

            return encryptionWeakness;
        }
    }
}
