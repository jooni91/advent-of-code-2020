using System;
using System.Collections.Generic;
using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day08
{
    public class Day8 : DayBase
    {
        protected override string Day => "08";

        protected override string PartOne(string input)
        {
            _ = DoesEnterInfinitLoop(input.ReadInputLines().ToArray(), out int result);

            return result.ToString();
        }

        protected override string PartTwo(string input)
        {
            return GetFixedBootCodeAccumulatorValue(input.ReadInputLines().ToArray()).ToString();
        }

        private int GetFixedBootCodeAccumulatorValue(string[] input)
        {
            int result = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("acc"))
                {
                    continue;
                }

                var originalOperation = input[i];

                input[i] = FlipJmpAndNopOperations(originalOperation);

                if (!DoesEnterInfinitLoop(input, out result))
                {
                    break;
                }

                input[i] = originalOperation;
            }

            return result;
        }
        private bool DoesEnterInfinitLoop(string[] input, out int accumulatorValue)
        {
            var seenIndexes = new HashSet<int>();
            var currentIndex = 0;
            accumulatorValue = 0;
            var didEnterInfinitLoop = false;

            while (true)
            {
                if (!seenIndexes.Add(currentIndex))
                {
                    didEnterInfinitLoop = true;
                    break;
                }

                if (currentIndex >= input.Length)
                {
                    break;
                }

                RunOperation(input[currentIndex], ref accumulatorValue, ref currentIndex);
            }

            return didEnterInfinitLoop;
        }
        private void RunOperation(string inputLine, ref int accumulatorValue, ref int currentIndex)
        {
            var instruction = inputLine.SplitInputs(' ');

            switch (instruction[0])
            {
                case "acc":
                    Accumulate(ref accumulatorValue, int.Parse(instruction[1])); break;
                case "jmp":
                    Jump(ref currentIndex, int.Parse(instruction[1])); break;
                default:
                    break;
            }

            currentIndex++;
        }
        private void Accumulate(ref int accumulatorValue, int accumulatorArgument)
        {
            accumulatorValue += accumulatorArgument;
        }
        private void Jump(ref int currentIndex, int jumpArgument)
        {
            currentIndex += (jumpArgument - 1);
        }
        private string FlipJmpAndNopOperations(string currentOperation)
        {
            var splittedOperation = currentOperation.SplitInputs(' ');

            return splittedOperation[0] switch
            {
                "jmp" => $"nop {splittedOperation[1]}",
                "nop" => $"jmp {splittedOperation[1]}",
                _ => throw new InvalidOperationException()
            };
        }
    }
}
