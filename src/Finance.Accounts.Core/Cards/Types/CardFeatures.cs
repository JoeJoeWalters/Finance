namespace Finance.Core.Types
{
    public class CardFeatures
    {
        public string[] CardMIIRanges { get; set; }

        public Range CardSizeRanges { get; set; }

        public bool LuhnRequired { get; set; } = true;

        public CardFeatures(string[] cardMIIRanges, Range cardSizeRanges, bool luhnRequired)
        {
            CardMIIRanges = cardMIIRanges;
            CardSizeRanges = cardSizeRanges;
            LuhnRequired = luhnRequired;
        }
    }
}
