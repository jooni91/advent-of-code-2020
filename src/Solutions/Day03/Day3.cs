using System.Collections.Generic;
using System.Linq;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day03
{
    public class Day3 : DayBase
    {
        protected override string Day => "03";

        protected override string PartOne(string input)
        {
            return CountTreesForSlope(input.ReadInputLines().ToList(), (3, 1)).ToString();
        }

        protected override string PartTwo(string input)
        {
            var treesMultiplied = 0L;

            foreach(var slope in new List<(int, int)> { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) })
            {
                var trees = CountTreesForSlope(input.ReadInputLines().ToList(), slope);

                if (treesMultiplied == 0)
                {
                    treesMultiplied = trees;
                    continue;
                }

                treesMultiplied *= trees;
            }

            return treesMultiplied.ToString();
        }

        private int CountTreesForSlope(List<string> map, (int Right, int Down) slope)
        {
            var x = 0;
            var xMaxIndex = map.First().Length;
            var treeCount = 0;

            for (int y = slope.Down; y < map.Count; y += slope.Down)
            {
                x = (x + slope.Right) % xMaxIndex;

                if (map[y][x] == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}
