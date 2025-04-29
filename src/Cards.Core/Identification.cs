using Cards.Core.Types;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Cards.Core
{
    public static class Identification
    {
        /// <summary>
        /// Checks the type of card based on the PAN (Primary Account Number).
        /// </summary>
        /// <param name="pan">Primary Account Number</param>
        /// <returns></returns>
        public static CardType WhatIs(string pan)
        {
            if (string.IsNullOrEmpty(pan) || pan.Length < 13 || pan.Length > 19)
                return CardType.Unknown;

            // Some cards use 2 and 4 digit prefixes
            string cardIdentifier2 = pan.Substring(0, 2);
            string cardIdentifier4 = pan.Substring(0, 4);
            string cardIdentifier6 = pan.Substring(0, 6);

            CardType result = CardType.Unknown;
            foreach(var feature in CardIdentity.Features)
            {
                if (CardIdentity.MIIRange(feature.Key).Contains(cardIdentifier2) ||
                    CardIdentity.MIIRange(feature.Key).Contains(cardIdentifier4) ||
                    CardIdentity.MIIRange(feature.Key).Contains(cardIdentifier6))
                {
                    result = feature.Key;
                    break;
                }
            }
            if (result == CardType.Unknown) return result;

            // Identified the type of card from the prefix, now check the length it correct
            Range range = CardIdentity.Features[result].CardSizeRanges;
            if (pan.Length >= range.Start.Value && pan.Length <= range.End.Value)
                return result;

            // Otherwise tell the caller that there is an issue with the card length for this type
            throw new ArgumentException("Invalid card number length for the identified card type.", new Exception($"Length for card type '{result}' is incorrect."));
        }


        public static BINRange InRange(BINRange[] ranges, string pan)
        {
            if (string.IsNullOrEmpty(pan) || pan.Length < 13 || pan.Length > 19)
                return null;

            foreach (var range in ranges)
            {
                foreach (var r in range.Ranges)
                {
                    for (int i = r.Start.Value; i <= r.End.Value; i++)
                    {
                        string startsWith = i.ToString();
                        string cardIdentifier = pan.Substring(0, startsWith.Length);
                        if (cardIdentifier == i.ToString())
                        {
                            return range;
                        }
                    }
                }
            }

            return null;
        }
    }
}
