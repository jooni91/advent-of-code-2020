using System;
using System.Collections.Generic;
using System.Drawing;
using AdventOfCode2020.Enums;
using AdventOfCode2020.Utilities;
using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day12
{
    public class Day12 : DayBase
    {
        protected override string Day => "12";

        protected override string PartOne(string input)
        {
            return GetManhattenDinstanceForRoute(input.ReadInputLines()).ToString();
        }

        protected override string PartTwo(string input)
        {
            return GetManhattenDistanceForRouteWithWaypoint(input.ReadInputLines()).ToString();
        }

        private int GetManhattenDinstanceForRoute(IEnumerable<string> navigationInstructions)
        {
            var currentPosition = new Point(0, 0);
            var currentDirection = CompassDirection.East;

            foreach(var instruction in navigationInstructions)
            {
                var instructionSpan = instruction.AsSpan();

                currentDirection = CheckForDirectionChanges(instructionSpan, currentDirection);
                currentPosition.Offset(GetMovementInstructions(instructionSpan, currentDirection));
            }

            return MathHelpers.ManhattanDistance((0, 0), (currentPosition.X, currentPosition.Y));
        }
        private int GetManhattenDistanceForRouteWithWaypoint(IEnumerable<string> navigationInstructions)
        {
            var currentShipPosition = new Point(0, 0);
            var currentWaypointPosition = new Point(10, -1);

            foreach (var instruction in navigationInstructions)
            {
                var instructionSpan = instruction.AsSpan();

                if (instructionSpan[0] == 'F')
                {
                    var steps = int.Parse(instructionSpan[1..]);

                    currentShipPosition.Offset(currentWaypointPosition.X * steps, currentWaypointPosition.Y * steps);
                    continue;
                }

                currentWaypointPosition = RotateWaypointRelativeToShip(instructionSpan, currentWaypointPosition);
                currentWaypointPosition.Offset(GetMovementInstructions(instructionSpan, CompassDirection.North));
            }

            return MathHelpers.ManhattanDistance((0, 0), (currentShipPosition.X, currentShipPosition.Y));
        }

        private CompassDirection CheckForDirectionChanges(ReadOnlySpan<char> instruction, CompassDirection currentDirection)
        {
            return instruction[0] switch
            {
                'L' when int.Parse(instruction[1..]) == 90 => (CompassDirection)(((int)currentDirection + 270) % 360),
                'L' when int.Parse(instruction[1..]) == 180 => (CompassDirection)(((int)currentDirection + 180) % 360),
                'L' when int.Parse(instruction[1..]) == 270 => (CompassDirection)(((int)currentDirection + 90) % 360),
                'R'  => (CompassDirection)(((int)currentDirection + int.Parse(instruction[1..])) % 360),
                _ => currentDirection
            };
        }
        private Point RotateWaypointRelativeToShip(ReadOnlySpan<char> instruction, Point waypointPosition)
        {
            if (instruction[0] != 'L' && instruction[0] != 'R')
            {
                return waypointPosition;
            }

            var angleInRadiants = (int)CheckForDirectionChanges(instruction, CompassDirection.North) * (Math.PI / 180);
            var cosTheta = Math.Cos(angleInRadiants);
            var sinTheta = Math.Sin(angleInRadiants);

            return new Point((int)(cosTheta * waypointPosition.X) - (int)(sinTheta * waypointPosition.Y),
                (int)(sinTheta * waypointPosition.X) + (int)(cosTheta * waypointPosition.Y));
        }
        private Point GetMovementInstructions(ReadOnlySpan<char> instruction, CompassDirection currentDirection)
        {
            return instruction[0] switch
            {
                'F' when currentDirection == CompassDirection.North => new Point(0, -int.Parse(instruction[1..])),
                'F' when currentDirection == CompassDirection.East => new Point(int.Parse(instruction[1..]), 0),
                'F' when currentDirection == CompassDirection.South => new Point(0, int.Parse(instruction[1..])),
                'F' when currentDirection == CompassDirection.West => new Point(-int.Parse(instruction[1..]), 0),
                'N'  => new Point(0, -int.Parse(instruction[1..])),
                'E'  => new Point(int.Parse(instruction[1..]), 0),
                'S'  => new Point(0, int.Parse(instruction[1..])),
                'W'  => new Point(-int.Parse(instruction[1..]), 0),
                _ => Point.Empty
            };
        }
    }
}
