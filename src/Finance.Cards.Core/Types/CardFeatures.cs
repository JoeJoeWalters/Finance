namespace Finance.Cards.Core.Types
{
    public class CardFeatures
    {
        public string[] CardMIIRanges { get; set; }

        public Range CardSizeRanges { get; set; }

        public CardFeatures(string[] cardMIIRanges, Range cardSizeRanges)
        {
            CardMIIRanges = cardMIIRanges;
            CardSizeRanges = cardSizeRanges;
        }
    }
}
