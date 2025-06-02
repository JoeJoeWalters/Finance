using Finance.Core.Cards;

namespace Finance.Core.Types
{
    public static class CardIdentity
    {
        // Reference : https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html
        public static Dictionary<CardType, CardFeatures> Features = new Dictionary<CardType, CardFeatures>()
        {
            { CardType.UATP, new CardFeatures(new string[] { "10-19" }, new Range(15, 15)) },
            { CardType.AmericanExpress, new CardFeatures(new string[] { "34", "37" }, new Range(15, 15)) },
            { CardType.DinersClub, new CardFeatures(new string[] { "36", "38" }, new Range(14, 14)) },
            { CardType.Visa, new CardFeatures(new string[] { "40-49" }, new Range(16, 16))  },
            { CardType.MasterCard, new CardFeatures(new string[] { "50-59", "2221-2720" }, new Range(16, 16)) },
            { CardType.Discover, new CardFeatures(new string[] { "6011", "6440-6499", "65" }, new Range (16, 19)) },
            { CardType.JCB, new CardFeatures(new string[] { "3528-3589" }, new Range (16, 16)) },
            { CardType.Maestro, new CardFeatures(new string[] { "67"}, new Range(16, 16 )) },
            { CardType.ChinaUnionPay, new CardFeatures(new string[] { "622126-622925"}, new Range(16, 19 )) },
        };

        private static Dictionary<CardType, string[]> _generatedMIIRanges = new Dictionary<CardType, string[]>();

        public static string[] MIIRange(CardType cardType)
        {
            if (!_generatedMIIRanges.ContainsKey(cardType))
                _generatedMIIRanges[cardType] = CardGenerator.GenerateRanges(Features[cardType].CardMIIRanges);

            return _generatedMIIRanges[cardType];
        }
    }
}
