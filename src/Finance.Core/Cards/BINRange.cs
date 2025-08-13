namespace Finance.Core.Cards
{
    public class BINRange
    {
        public string Id { get; set; } = string.Empty;
        public Range[] Ranges { get; set; } = new Range[] { };

        public BINRange(string id, Range[] ranges)
        {
            Id = id;
            Ranges = ranges;
        }
    }
}
