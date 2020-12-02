namespace AdventOfCode2020.Models
{
    public record PasswordPolicy
    {
        public int CharMinimumOccasion { get; }

        public int CharMaximumOccasion { get; }

        public char TargetChar { get; }

        public string Password { get; }

        public PasswordPolicy(int minOccasion, int maxOccasion, char target, string password)
        {
            (CharMinimumOccasion, CharMaximumOccasion, TargetChar, Password) = (minOccasion, maxOccasion, target, password);
        }
    }
}
