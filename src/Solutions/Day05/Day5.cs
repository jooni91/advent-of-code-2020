using System;
using System.Collections.Generic;
using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day05
{
    public class Day5 : DayBase
    {
        protected override string Day => "05";

        protected override string PartOne(string input)
        {
            return GetHighestSeatId(input.ReadInputLines()).ToString();
        }

        protected override string PartTwo(string input)
        {
            return FindMissingSeatId(input.ReadInputLines()).ToString();
        }

        private int GetHighestSeatId(IEnumerable<string> seatCodes)
        {
            return GetSeatIds(seatCodes).Aggregate(0, (highest, next) => next > highest ? next : highest);
        }
        private int FindMissingSeatId(IEnumerable<string> seatCodes)
        {
            var seatIds = GetSeatIds(seatCodes).OrderBy(id => id).ToList();
            var initialSeatId = seatIds.First();

            for (int i = 0; i < seatIds.Count; i++)
            {
                if (seatIds[i] != initialSeatId + i)
                {
                    return initialSeatId + i;
                }
            }

            return -1;
        }
        private IEnumerable<int> GetSeatIds(IEnumerable<string> seatCodes)
        {
            foreach (var seatCode in seatCodes)
            {
                var row = (0, 127);
                var column = (0, 7);
                var currentRow = 0;
                var currentColumn = 0;

                foreach (var spacePartition in seatCode)
                {
                    if (spacePartition == 'F' || spacePartition == 'B')
                    {
                        var newRow = GetRangeBySpacePartition(spacePartition, row.Item1, row.Item2);
                        currentRow = row.Item1 == newRow.Item1 ? newRow.Item2 : newRow.Item1;
                        row = newRow;
                    }
                    else
                    {
                        var newColumn = GetRangeBySpacePartition(spacePartition, column.Item1, column.Item2);
                        currentColumn = column.Item1 == newColumn.Item1 ? newColumn.Item2 : newColumn.Item1;
                        column = newColumn;
                    }
                }

                yield return (currentRow * 8) + currentColumn;
            }
        }
        private (int, int) GetRangeBySpacePartition(char partition, double lowest, double highest)
        {
            return partition switch
            {
                'F' when highest - lowest == 1 => ((int)lowest, (int)lowest),
                'F' => ((int)lowest, (int)Math.Round((highest + lowest) / 2, MidpointRounding.ToZero)),
                'B' when highest - lowest == 1 => ((int)highest, (int)highest),
                'B' => ((int)Math.Round((highest + lowest) / 2, MidpointRounding.AwayFromZero), (int)highest),
                'L' when highest - lowest == 1 => ((int)lowest, (int)lowest),
                'L' => ((int)lowest, (int)Math.Round((highest + lowest) / 2, MidpointRounding.ToZero)),
                'R' when highest - lowest == 1 => ((int)highest, (int)highest),
                'R' => ((int)Math.Round((highest + lowest) / 2, MidpointRounding.AwayFromZero), (int)highest),
                _ => throw new InvalidOperationException("The provided partition was not a valid value.")
            };
        }
    }
}
