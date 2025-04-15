using Cards.Core.Types;

namespace Cards.Core
{
    public static class Identification
    {
        public static CardType WhatIs(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return CardType.Unknown;
            if (pan.Length < 13 || pan.Length > 19)
                return CardType.Unknown;
            if (pan.StartsWith("4"))
                return CardType.Visa;
            else if (pan.StartsWith("5"))
                return CardType.MasterCard;
            else if (pan.StartsWith("34") || pan.StartsWith("37"))
                return CardType.AmericanExpress;
            else if (pan.StartsWith("6011") || pan.StartsWith("65"))
                return CardType.Discover;
            else if (pan.StartsWith("3"))
                return CardType.DinersClub;
            else
                return CardType.Unknown;
        }

    }
}
