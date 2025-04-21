using Cards.Core.Types;
using System.Data;
using System.Text.RegularExpressions;

namespace Cards.Core
{
    public static class Identification
    {
        // Reference : https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html
        public static string[] VisaRanges = { "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
        public static string[] MastercardRanges = { "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
        public static string[] AmericanExpressRanges = { "34", "37" };
        public static string[] DinersClubRanges = { "36", "38" };
        public static string[] DiscoverRanges = { "6011", "65" };
        public static string[] JCBRanges = { "2131", "1800", "35" };
        public static string[] MaestroRanges = { "67" };

        // lengths
        public static int VisaLength = 16; 
        public static int MastercardLength = 16;
        public static int AmericanExpressLength = 15;
        public static int DinersClubLength = 14;
        public static int DiscoverLength = 16;
        public static int JCBLength = 16;
        public static int MaestroLength = 16;

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

            CardType result = CardType.Unknown;

            // NOTE: As this gets more complex, consider using a dictionary or a more structured approach
            if (VisaRanges.Contains(cardIdentifier2) || VisaRanges.Contains(cardIdentifier4))
                result = CardType.Visa;
            else if (MastercardRanges.Contains(cardIdentifier2))
                result = CardType.MasterCard;
            else if (AmericanExpressRanges.Contains(cardIdentifier2))
                result = CardType.AmericanExpress;
            else if (DinersClubRanges.Contains(cardIdentifier2))
                result = CardType.DinersClub;
            else if (DiscoverRanges.Contains(cardIdentifier2) || DiscoverRanges.Contains(cardIdentifier4))
                result = CardType.Discover;
            else if (JCBRanges.Contains(cardIdentifier2) || JCBRanges.Contains(cardIdentifier4))
                result = CardType.JCB;
            else if (MaestroRanges.Contains(cardIdentifier2))
                result = CardType.Maestro;
            else
                return CardType.Unknown;

            // Identified the type of card from the prefix, now check the length it correct
            switch (result)
            {
                case CardType.Visa:
                    if (pan.Length == VisaLength)
                        return result;
                    break;
                case CardType.MasterCard:
                    if (pan.Length == MastercardLength)
                        return result;
                    break;
                case CardType.AmericanExpress:
                    if (pan.Length == AmericanExpressLength)
                        return result;
                    break;
                case CardType.DinersClub:
                    if (pan.Length == DinersClubLength)
                        return result;
                    break;
                case CardType.Discover:
                    if (pan.Length == DiscoverLength)
                        return result;
                    break;
                case CardType.JCB:
                    if (pan.Length == JCBLength)
                        return result;
                    break;
                case CardType.Maestro:
                    if (pan.Length == MaestroLength)
                        return result;
                    break;
            }

            // Otherwise tell the caller that there is an issue with the card length for this type
            throw new ArgumentException("Invalid card number length for the identified card type.", new Exception($"Length for card type '{result}' is incorrect."));
        }

    }
}
