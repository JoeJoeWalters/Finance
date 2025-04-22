using Cards.Core.Types;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Cards.Core
{
    public static class Identification
    {
        // Reference : https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html
        public static string[] VisaMIIRanges = { "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };
        public static string[] MastercardMIIRanges = { "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "2221-2720" };
        public static string[] AmericanExpressMIIRanges = { "34", "37" };
        public static string[] DinersClubMIIRanges = { "36", "38" };
        public static string[] DiscoverMIIRanges = { "6011", "6440-6499", "65" };
        public static string[] JCBMIIRanges = { "2131", "1800", "35" };
        public static string[] MaestroMIIRanges = { "67" };
        public static string[] ChinaUnionPayMIIRanges = { "622126-622925" }; // UnionPay co-branded

        // lengths
        public static Range VisaSizeRanges = new Range(16, 16);
        public static Range MastercardSizeRanges = new Range(16, 16);
        public static Range AmericanExpressSizeRanges = new Range(15, 15);
        public static Range DinersClubSizeRanges = new Range(14, 14);
        public static Range DiscoverSizeRanges = new Range(16, 19);
        public static Range JCBSizeRanges = new Range(16, 16);
        public static Range MaestroSizeRanges = new Range(16, 16);
        public static Range ChinaUnionPaySizeRanges = new Range(16, 19);

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

            // Custom ranges for specfic card types
            string[] masterCardFullRanges = Generator.GenerateRanges(MastercardMIIRanges);
            string[] discoverCardFullRanges = Generator.GenerateRanges(DiscoverMIIRanges);
            string[] chinaUnionPayCardFullRanges = Generator.GenerateRanges(ChinaUnionPayMIIRanges);

            // NOTE: As this gets more complex, consider using a dictionary or a more structured approach
            if (VisaMIIRanges.Contains(cardIdentifier2) || VisaMIIRanges.Contains(cardIdentifier4))
                result = CardType.Visa;
            else if (masterCardFullRanges.Contains(cardIdentifier2) || masterCardFullRanges.Contains(cardIdentifier4))
                result = CardType.MasterCard;
            else if (AmericanExpressMIIRanges.Contains(cardIdentifier2))
                result = CardType.AmericanExpress;
            else if (DinersClubMIIRanges.Contains(cardIdentifier2))
                result = CardType.DinersClub;
            else if (discoverCardFullRanges.Contains(cardIdentifier2) || discoverCardFullRanges.Contains(cardIdentifier4))
                result = CardType.Discover;
            else if (JCBMIIRanges.Contains(cardIdentifier2) || JCBMIIRanges.Contains(cardIdentifier4))
                result = CardType.JCB;
            else if (MaestroMIIRanges.Contains(cardIdentifier2))
                result = CardType.Maestro;
            else if (chinaUnionPayCardFullRanges.Contains(cardIdentifier6))
                result = CardType.ChinaUnionPay;
            else
                return CardType.Unknown;

            // Identified the type of card from the prefix, now check the length it correct
            switch (result)
            {
                case CardType.Visa:
                    if (pan.Length >= VisaSizeRanges.Start.Value && pan.Length <= VisaSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.MasterCard:
                    if (pan.Length >= MastercardSizeRanges.Start.Value && pan.Length <= MastercardSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.AmericanExpress:
                    if (pan.Length >= AmericanExpressSizeRanges.Start.Value && pan.Length <= AmericanExpressSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.DinersClub:
                    if (pan.Length >= DinersClubSizeRanges.Start.Value && pan.Length <= DinersClubSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.Discover:
                    if (pan.Length >= DiscoverSizeRanges.Start.Value && pan.Length <= DiscoverSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.JCB:
                    if (pan.Length >= JCBSizeRanges.Start.Value && pan.Length <= JCBSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.Maestro:
                    if (pan.Length >= MaestroSizeRanges.Start.Value && pan.Length <= MaestroSizeRanges.End.Value)
                        return result;
                    break;
                case CardType.ChinaUnionPay:
                    if (pan.Length >= ChinaUnionPaySizeRanges.Start.Value && pan.Length <= ChinaUnionPaySizeRanges.End.Value)
                        return result;
                    break;
            }

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
