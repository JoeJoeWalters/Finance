using Cards.Core.Types;

namespace Cards.Core
{
    public static class Generator
    {
        public static string[] GenerateRanges(string[] range)
        {
            string[] result = new string[] { };

            for (var i = 0; i < range.Length; i++)
            {
                if (range[i].Contains("-"))
                {
                    string[] strings = range[i].Split('-');
                    for (var r = Convert.ToInt32(strings[0]); r <= Convert.ToInt32(strings[1]); r++)
                    {
                        string value = r.ToString();
                        result = result.Append(value).ToArray();
                    }
                }
                else
                    result = result.Append(range[i]).ToArray();
            }

            return result;
        }

        /// <summary>
        /// Generates a random card number of the specified type.
        /// </summary>
        /// <param name="cardType">The type of card to generate.</param>
        /// <returns>A random card number as a string.</returns>
        public static string CardNumber(CardType cardType)
        {
            Random random = new Random();
            
            if (!CardIdentity.Features.ContainsKey(cardType))
                throw new ArgumentException($"Unsupported card type: {cardType}");

            return Luhn.GenerateCard(CardIdentity.Features[cardType].CardMIIRanges, CardIdentity.Features[cardType].CardSizeRanges, true);
        }
    }
}
