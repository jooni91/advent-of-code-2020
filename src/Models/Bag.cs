namespace AdventOfCode2020.Models
{
    public record Bag
    {
        public Bag(string bagName) => BagName = bagName;

        public int BagId => BagName.GetHashCode();

        public string BagName { get; init; }

        public override int GetHashCode()
        {
            return BagId;
        }
    }
}
