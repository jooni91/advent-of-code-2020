using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventOfCode2020;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            args = AskForArguments().ToArray() ?? Array.Empty<string>();
        }

        if (args == null || args.Length != 2)
        {
            throw new ArgumentException();
        }

        Console.WriteLine($"Starting part {args[1]} of day {args[0]}.");


        if (Assembly.GetCallingAssembly().CreateInstance($"AdventOfCode2020.Solutions.Day{(args[0].Length == 1 ? "0" : "")}{args[0]}.Day{args[0]}") is not DayBase solutionForDay)
        {
            throw new NullReferenceException("Couldn't find solution for specified day.");
        }

        Console.WriteLine($"The result for day {args[0]} part {args[1]} is {solutionForDay.GetResult((Part)Enum.Parse(typeof(Part), args[1]))}.");

        Console.WriteLine($"");

        Console.WriteLine($"If you want to continue running another solution type y and press enter.");

        if (Console.ReadLine() == "y")
        {
            Main(Array.Empty<string>());
        }
    }

    static IEnumerable<string> AskForArguments()
    {
        Console.WriteLine("You didn't pass the day and puzzle arguments to the program. What day do you want to run?");
        yield return Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Which part of the day, 1 or 2?");
        yield return Console.ReadLine() ?? string.Empty;
    }
}
