using Cards.Core.Types;
using System.Data;
using System.Text.RegularExpressions;

namespace Cards.Core
{
    public static class Identification
    {
        public static string[] VisaRanges = { "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
        public static string[] MastercardRanges = { "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
        public static string[] AmericanExpressRanges = { "34", "37" };
        public static string[] DinersClubRanges = { "36", "38" };
        public static string[] DiscoverRanges = { "6011", "65" };
        public static string[] JCBRanges = { "2131", "1800", "35" };

        /// <summary>
        /// Checks the type of card based on the PAN (Primary Account Number).
        /// </summary>
        /// <param name="pan">Primary Account Number</param>
        /// <returns></returns>
        public static CardType WhatIs(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return CardType.Unknown;

            if (pan.Length < 13 || pan.Length > 19)
                return CardType.Unknown;

            string cardIdentifier2 = pan.Substring(0, 2);
            string cardIdentifier4 = pan.Substring(0, 4);

            if (VisaRanges.Contains(cardIdentifier2) || VisaRanges.Contains(cardIdentifier4))
                return CardType.Visa;
            else if (MastercardRanges.Contains(cardIdentifier2) || MastercardRanges.Contains(cardIdentifier4))
                return CardType.MasterCard;
            else if (AmericanExpressRanges.Contains(cardIdentifier2) || AmericanExpressRanges.Contains(cardIdentifier4))
                return CardType.AmericanExpress;
            else if (DiscoverRanges.Contains(cardIdentifier2) || DiscoverRanges.Contains(cardIdentifier4))
                return CardType.Discover;
            else if (DinersClubRanges.Contains(cardIdentifier2) || DinersClubRanges.Contains(cardIdentifier4))
                return CardType.DinersClub;
            else if (JCBRanges.Contains(cardIdentifier2) || JCBRanges.Contains(cardIdentifier4))
                return CardType.JCB;
            else
                return CardType.Unknown;
        }

    }
}
