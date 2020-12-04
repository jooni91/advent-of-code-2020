namespace AdventOfCode2020.Models
{

    public class PassportData
    {
        public int BirthYear { get; set; }

        public int IssueYear { get; set; }

        public int ExpirationYear { get; set; }

        public HeightData? HeightData { get; set; }

        public string? HairColorHex { get; set; }

        public string? EyeColor { get; set; }

        public string? PassportId { get; set; }

        public string? CountryId { get; set; }

        public bool IsValidEyeColor()
        {
            return EyeColor == "amb" ||
                EyeColor == "blu" ||
                EyeColor == "brn" ||
                EyeColor == "gry" ||
                EyeColor == "grn" ||
                EyeColor == "hzl" ||
                EyeColor == "oth";
        }
    }
}
