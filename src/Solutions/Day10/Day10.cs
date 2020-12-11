using System.Collections.Generic;
using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day10
{
    public class Day10 : DayBase
    {
        protected override string Day => "10";

        protected override string PartOne(string input)
        {
            var inputNumbers = input.ReadInputLines().ConvertInputsToIntegers().OrderBy(num => num).ToList();
            var differences = GetJoltageDifferences(inputNumbers).ToList();

            return (differences.Count(diff => diff == 1) * differences.Count(diff => diff == 3)).ToString();
        }

        protected override string PartTwo(string input)
        {
            return "Incomplete!"; // CountDistinctArrangements(input.ReadInputLines().ConvertInputsToIntegers()).ToString();
        }

        private IEnumerable<int> GetJoltageDifferences(List<int> sortedInput)
        {
            var sourceOutput = 0;

            for (int i = 0; i < sortedInput.Count; i++)
            {
                yield return sortedInput[i] - sourceOutput;

                sourceOutput = sortedInput[i];
            }

            yield return 3;
        }

        //private ulong CountDistinctArrangements(IEnumerable<int> input)
        //{
        //    ulong possibleArrangements = 1;

        //    foreach(var difference in PossibleArrangementCountPerAdapter(input))
        //    {
        //        possibleArrangements += possibleArrangements * (uint)difference;
        //    }

        //    return possibleArrangements;
        //}
        //private IEnumerable<uint> PossibleArrangementCountPerAdapter(IEnumerable<int> input)
        //{
        //    var sortedInput = input.OrderBy(num => num).ToList();
        //    var sourceOutput = 0;
        //    int waysForwardCount = 0;

        //    for (int i = 0; i < sortedInput.Count; i += waysForwardCount + 1)
        //    {
        //        for(waysForwardCount = 0; waysForwardCount < 3; waysForwardCount++)
        //        {
        //            if (i + waysForwardCount >= sortedInput.Count || sortedInput[i + waysForwardCount] > sourceOutput + 3)
        //            {
        //                break;
        //            }
        //        }

        //        if (i + waysForwardCount < sortedInput.Count)
        //        {
        //            sourceOutput = sortedInput[i + waysForwardCount];
        //        }

        //        yield return waysForwardCount;
        //    }
        //}
    }
}
