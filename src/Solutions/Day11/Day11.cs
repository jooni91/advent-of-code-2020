using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Enums;
using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day11
{
    public class Day11 : DayBase
    {
        protected override string Day => "11";

        protected override string PartOne(string input)
        {
            var grid = ParseInput(input.ReadInputLines().ToArray());

            while (true)
            {
                if (!SimulateNextStates(grid, 4, CountAdjacentOccupidSeats))
                {
                    return CountOccupiedSeats(grid).ToString();
                }
            }
        }

        protected override string PartTwo(string input)
        {
            var grid = ParseInput(input.ReadInputLines().ToArray());

            while (true)
            {
                if (!SimulateNextStates(grid, 5, CountFirstVisibleOccupidSeats))
                {
                    return CountOccupiedSeats(grid).ToString();
                }
            }
        }

        private bool SimulateNextStates(SeatingSystemGridState[,] grid, int staySeatedTolerance, Func<(int, int), SeatingSystemGridState[,], int> countSeats)
        {
            var changesToApply = new Dictionary<(int, int), SeatingSystemGridState>(grid.Length);

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (grid[row, column] == SeatingSystemGridState.Seat && countSeats((row, column), grid) == 0)
                    {
                        changesToApply.Add((row, column), SeatingSystemGridState.Occupied);
                    }
                    else if (grid[row, column] == SeatingSystemGridState.Occupied && countSeats((row, column), grid) >= staySeatedTolerance)
                    {
                        changesToApply.Add((row, column), SeatingSystemGridState.Seat);
                    }
                }
            }

            foreach(var change in changesToApply)
            {
                grid[change.Key.Item1, change.Key.Item2] = change.Value;
            }

            return changesToApply.Count > 0;
        }
        private int CountAdjacentOccupidSeats((int Row, int Column) position, SeatingSystemGridState[,] grid)
        {
            int adjacentOccupiedSeatCount = 0;

            for (int rowOffset = -1; rowOffset < 2; rowOffset++)
            {
                for (int columnOffset = -1; columnOffset < 2; columnOffset++)
                {
                    if ((rowOffset == 0 && columnOffset == 0) || 
                        !IsValidPosition(position.Row + rowOffset, grid.GetLength(0) - 1) ||
                        !IsValidPosition(position.Column + columnOffset, grid.GetLength(1) - 1))
                    {
                        continue;
                    }

                    if (grid[position.Row + rowOffset, position.Column + columnOffset] == SeatingSystemGridState.Occupied)
                    {
                        adjacentOccupiedSeatCount++;
                    }
                }
            }

            return adjacentOccupiedSeatCount;
        }
        private int CountFirstVisibleOccupidSeats((int Row, int Column) position, SeatingSystemGridState[,] grid)
        {
            int visibleOccupiedSeatCount = 0;

            for (int direction = 0; direction < 8; direction++)
            {
                var positionLookingAt = position;

                while (true)
                {
                    positionLookingAt = GetNextPositionToCheck(direction, positionLookingAt);

                    if (!IsValidPosition(positionLookingAt.Row, grid.GetLength(0) - 1) ||
                        !IsValidPosition(positionLookingAt.Column, grid.GetLength(1) - 1) ||
                        grid[positionLookingAt.Row, positionLookingAt.Column] == SeatingSystemGridState.Seat)
                    {
                        break;
                    }
                    else if (grid[positionLookingAt.Row, positionLookingAt.Column] == SeatingSystemGridState.Occupied)
                    {
                        visibleOccupiedSeatCount++;
                        break;
                    }
                }
            }

            return visibleOccupiedSeatCount;
        }
        private bool IsValidPosition(int position, int maxValue) => position >= 0 && position <= maxValue;
        private int CountOccupiedSeats(SeatingSystemGridState[,] grid)
        {
            var count = 0;

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (grid[row, column] == SeatingSystemGridState.Occupied)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        private (int Y, int X) GetNextPositionToCheck(int direction, (int Y, int X) currentPosition)
        {
            return direction switch
            {
                0 => (currentPosition.Y - 1, currentPosition.X),
                1 => (currentPosition.Y - 1, currentPosition.X + 1),
                2 => (currentPosition.Y, currentPosition.X + 1),
                3 => (currentPosition.Y + 1, currentPosition.X + 1),
                4 => (currentPosition.Y + 1, currentPosition.X),
                5 => (currentPosition.Y + 1, currentPosition.X - 1),
                6 => (currentPosition.Y, currentPosition.X - 1),
                7 => (currentPosition.Y - 1, currentPosition.X - 1),
                _ => throw new InvalidOperationException()
            };
        }

        private SeatingSystemGridState[,] ParseInput(string[] inputLines)
        {
            var grid = new SeatingSystemGridState[inputLines.Length, inputLines.First().Length];

            for (int row = 0; row < inputLines.Length; row++)
            {
                for (int column = 0; column < inputLines[row].Length; column++)
                {
                    grid[row, column] = inputLines[row][column] switch
                    {
                        '.' => SeatingSystemGridState.Floor,
                        'L' => SeatingSystemGridState.Seat,
                        _ => throw new InvalidOperationException()
                    };
                }
            }

            return grid;
        }
    }
}
