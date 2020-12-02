using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Models;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day02
{
    public class Day2 : DayBase
    {
        protected override string Day => "02";

        protected override string PartOne(string input)
        {
            return CountValidSledRentalPasswords(input.ReadInputLines().SplitInputs(false, '-', ' ', ':')
                .Select(data => new PasswordPolicy(int.Parse(data[0]), int.Parse(data[1]), char.Parse(data[2]), data[3]))).ToString();
        }

        protected override string PartTwo(string input)
        {
            return CountValidTobogganPasswords(input.ReadInputLines().SplitInputs(false, '-', ' ', ':')
                .Select(data => new PasswordPolicy(int.Parse(data[0]), int.Parse(data[1]), char.Parse(data[2]), data[3]))).ToString();
        }

        private int CountValidSledRentalPasswords(IEnumerable<PasswordPolicy> passwordPolicies)
        {
            var validPasswordCount = 0;

            foreach(var passwordPolicy in passwordPolicies)
            {
                var charCount = passwordPolicy.Password.Count(current => current == passwordPolicy.TargetChar);

                if (charCount >= passwordPolicy.CharMinimumOccasion && charCount <= passwordPolicy.CharMaximumOccasion)
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }
        private int CountValidTobogganPasswords(IEnumerable<PasswordPolicy> passwordPolicies)
        {
            var validPasswordCount = 0;

            foreach (var passwordPolicy in passwordPolicies)
            {
                var positionOneMatch = passwordPolicy.Password[passwordPolicy.CharMinimumOccasion - 1] == passwordPolicy.TargetChar;
                var positionTwoMatch = passwordPolicy.Password[passwordPolicy.CharMaximumOccasion - 1] == passwordPolicy.TargetChar;

                if ((positionOneMatch && !positionTwoMatch) || (!positionOneMatch && positionTwoMatch))
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }
    }
}
