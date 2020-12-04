using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using AdventOfCode2020.Enums;
using AdventOfCode2020.Extensions;
using AdventOfCode2020.Models;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day04
{
    public class Day4 : DayBase
    {
        protected override string Day => "04";

        protected override string PartOne(string input)
        {
            return CountValidPassportsSimplisticly(ParsePassportData(input)).ToString();
        }

        protected override string PartTwo(string input)
        {
            return CountValidPassports(ParsePassportData(input)).ToString();
        }

        private int CountValidPassportsSimplisticly(IEnumerable<PassportData> passports)
        {
            var count = 0;

            foreach (var passport in passports)
            {
                var isValid = passport.BirthYear > 0 &&
                    passport.IssueYear > 0 &&
                    passport.ExpirationYear > 0 &&
                    passport.HeightData != null &&
                    !string.IsNullOrEmpty(passport.HairColorHex) &&
                    !string.IsNullOrEmpty(passport.EyeColor) &&
                    !string.IsNullOrEmpty(passport.PassportId);

                if (isValid)
                {
                    count++;
                }
            }

            return count;
        }
        private int CountValidPassports(IEnumerable<PassportData> passports)
        {
            var count = 0;

            foreach (var passport in passports)
            {
                var isValid = passport.BirthYear >= 1920 && passport.BirthYear <= 2002 &&
                    passport.IssueYear >= 2010 && passport.IssueYear <= 2020 &&
                    passport.ExpirationYear >= 2020 && passport.ExpirationYear <= 2030 &&
                    passport.HeightData != null && passport.HeightData.IsValidHeightData() &&
                    !string.IsNullOrEmpty(passport.HairColorHex) && Regex.IsMatch(passport.HairColorHex, @"^#[0-9a-f]{6}$") &&
                    !string.IsNullOrEmpty(passport.EyeColor) && passport.IsValidEyeColor() &&
                    !string.IsNullOrEmpty(passport.PassportId) && Regex.IsMatch(passport.PassportId, @"^[0-9]{9}$");

                if (isValid)
                {
                    count++;
                }
            }

            return count;
        }


        private IEnumerable<PassportData> ParsePassportData(string input)
        {
            using var sr = new StringReader(input);

            string? line;

            while (true)
            {
                var data = new PassportData();

                // Nested loop that stops when an empty line or the end of the file was reached.
                while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                {
                    MapData(line, ref data);
                }

                yield return data;

                if (line == null)
                {
                    break;
                }
            }
        }
        private void MapData(string data, ref PassportData passportData)
        {
            foreach (var keyValuePair in data.SplitInputs(' '))
            {
                var splittedKVPair = keyValuePair.SplitInputs(':');

                _ = splittedKVPair[0] switch
                {
                    "byr" => (passportData.BirthYear = int.Parse(splittedKVPair[1])).ToString(),
                    "iyr" => (passportData.IssueYear = int.Parse(splittedKVPair[1])).ToString(),
                    "eyr" => (passportData.ExpirationYear = int.Parse(splittedKVPair[1])).ToString(),
                    "hgt" => (passportData.HeightData = new HeightData(ExtractHeight(splittedKVPair[1]), splittedKVPair[1].ParseFromHeightString())).ToString(),
                    "hcl" => passportData.HairColorHex = splittedKVPair[1],
                    "ecl" => passportData.EyeColor = splittedKVPair[1],
                    "pid" => passportData.PassportId = splittedKVPair[1],
                    "cid" => passportData.CountryId = splittedKVPair[1],
                    _ => throw new InvalidDataException()
                };
            }
        }
        private double ExtractHeight(string heightString)
        {
            var unit = heightString.ParseFromHeightString();

            return double.Parse(unit == MeasurementUnit.Unspecified
                ? heightString
                : (unit == MeasurementUnit.Centimeter
                    ? heightString.Remove(heightString.IndexOf("c"))
                    : heightString.Remove(heightString.IndexOf("i"))));
        }
    }
}
