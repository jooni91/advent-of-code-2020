using System;
using System.IO;
using AdventOfCode2020.Utilities;

namespace AdventOfCode2020
{
    public abstract class DayBase
    {
        protected abstract string Day { get; }
        protected virtual bool PartOneInputAsStream { get; } = false;
        protected virtual bool PartTwoInputAsStream { get; } = false;

        public bool UnitTestMode { get; set; } = false;

        public string GetResult(Part part)
        {
            return part == Part.One
                ? PartOneInputAsStream ? PartOne(GetInputStream()) : PartOne(GetInput())
                : PartTwoInputAsStream ? PartTwo(GetInputStream()) : PartTwo(GetInput());
        }

#pragma warning disable IDE0022 // Use block body for methods
        protected virtual string PartOne(string input) => throw new NotImplementedException();
        protected virtual string PartOne(FileStream inputStream) => throw new NotImplementedException();
        protected virtual string PartTwo(string input) => throw new NotImplementedException();
        protected virtual string PartTwo(FileStream inputStream) => throw new NotImplementedException();
#pragma warning restore IDE0022 // Use block body for methods

        protected string GetInput()
        {
            return InputLoader.LoadInputsFromFileAsString($"InputFiles/Day{Day}.txt");
        }
        protected FileStream GetInputStream()
        {
            return InputLoader.LoadInputsAsFileStream($"InputFiles/Day{Day}.txt");
        }
    }

    public enum Part
    {
        One = 1,
        Two = 2
    }
}
