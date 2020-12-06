using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Solutions.Day06
{
    public class Day6 : DayBase
    {
        protected override string Day => "06";

        protected override string PartOne(string input)
        {
            return PositiveAnswerSum(GetDeclarationFormGroups(input), CountAnyonePositiveAnswers).ToString();
        }

        protected override string PartTwo(string input)
        {
            return PositiveAnswerSum(GetDeclarationFormGroups(input), CountEveryonePositiveAnswers).ToString();
        }

        private int PositiveAnswerSum(IEnumerable<List<string>> groups, Func<List<string>, int> countFunc)
        {
            var sum = 0;

            foreach(var group in groups)
            {
                sum += countFunc(group);
            }

            return sum;
        }
        private int CountAnyonePositiveAnswers(List<string> group)
        {
            var hashSet = new HashSet<char>();

            foreach(var answers in group)
            {
                foreach (var answer in answers)
                {
                    if (!hashSet.Contains(answer))
                    {
                        hashSet.Add(answer);
                    }
                }
            }

            return hashSet.Count;
        }
        private int CountEveryonePositiveAnswers(List<string> group)
        {
            var answerDictionary = new Dictionary<char, int>();

            foreach (var answers in group)
            {
                foreach (var answer in answers)
                {
                    if (!answerDictionary.ContainsKey(answer))
                    {
                        answerDictionary.Add(answer, 1);
                    }
                    else
                    {
                        answerDictionary[answer]++;
                    }
                }
            }

            return answerDictionary.Count(pair => pair.Value == group.Count);
        }
        private IEnumerable<List<string>> GetDeclarationFormGroups(string input)
        {
            using var sr = new StringReader(input);

            string? line;

            while (true)
            {
                var group = new List<string>();

                // Nested loop that stops when an empty line or the end of the file was reached.
                while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                {
                    group.Add(line);
                }

                yield return group;

                if (line == null)
                {
                    break;
                }
            }
        }
    }
}
