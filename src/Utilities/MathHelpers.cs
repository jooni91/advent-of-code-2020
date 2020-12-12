using System;
using System.Drawing;

namespace AdventOfCode2020.Utilities
{
    /// <summary>
    /// Contains math helper methods that might be useful in general.
    /// </summary>
    public static class MathHelpers
    {
        /// <summary>
        /// Calculate the Manhattan distance of two points in 2 dimensional space.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        public static int ManhattanDistance((int X, int Y) pointA, (int X, int Y) pointB)
        {
            return Math.Abs(pointA.X - pointB.X) + Math.Abs(pointA.Y - pointB.Y);
        }

        /// <summary>
        /// Calculate the Manhattan distance of two points in 2 dimensional space.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        public static int ManhattanDistance(Point pointA, Point pointB)
        {
            return ManhattanDistance((pointA.X, pointA.Y), (pointB.X, pointB.Y));
        }
    }
}
