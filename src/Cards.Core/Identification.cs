using Cards.Core.Types;
using System.Data;
using System.Text.RegularExpressions;

namespace Cards.Core
{
    public static class Identification
    {
        public static string VisaRegex = "^4[0-9]{12}(?:[0-9]{3})?$";
        public static string MastercardRegex = "^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$";
        public static string AmericanExpressRegex = "^3[47][0-9]{13}$";
        public static string DinersClubRegex = "^3(?:0[0-5]|[68][0-9])[0-9]{11}$";
        public static string DiscoverRegex = "^6(?:011|5[0-9]{2})[0-9]{12}$";

        public static CardType WhatIs(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return CardType.Unknown;

            if (pan.Length < 13 || pan.Length > 19)
                return CardType.Unknown;

            if (Regex.IsMatch(pan, VisaRegex))
                return CardType.Visa;
            else if (Regex.IsMatch(pan, MastercardRegex))
                return CardType.MasterCard;
            else if (Regex.IsMatch(pan, AmericanExpressRegex))
                return CardType.AmericanExpress;
            else if (Regex.IsMatch(pan, DiscoverRegex))
                return CardType.Discover;
            else if (Regex.IsMatch(pan, DinersClubRegex))
                return CardType.DinersClub;
            else
                return CardType.Unknown;
        }

    }
}
