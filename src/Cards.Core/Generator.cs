using Cards.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core
{
    public static class Generator
    {
        /// <summary>
        /// Generates a random card number of the specified type.
        /// </summary>
        /// <param name="cardType">The type of card to generate.</param>
        /// <returns>A random card number as a string.</returns>
        public static string CardNumber(CardType cardType)
        {
            Random random = new Random();
            string cardNumber = "";
            switch (cardType)
            {
                case CardType.Visa:
                    cardNumber = Luhn.GenerateCard(Identification.VisaRanges, Identification.VisaLength);
                    break;
                case CardType.MasterCard:
                    cardNumber = Luhn.GenerateCard(Identification.MastercardRanges, Identification.MastercardLength);
                    break;
                case CardType.AmericanExpress:
                    cardNumber = Luhn.GenerateCard(Identification.AmericanExpressRanges, Identification.AmericanExpressLength);
                    break;
                case CardType.Discover:
                    cardNumber = Luhn.GenerateCard(Identification.DiscoverRanges, Identification.DiscoverLength);
                    break;
                case CardType.DinersClub:
                    cardNumber = Luhn.GenerateCard(Identification.DinersClubRanges, Identification.DinersClubLength);
                    break;
                case CardType.JCB:
                    cardNumber = Luhn.GenerateCard(Identification.JCBRanges, Identification.JCBLength);
                    break;
                case CardType.Maestro:
                    cardNumber = Luhn.GenerateCard(Identification.MaestroRanges, Identification.MaestroLength);
                    break;
                default:
                    throw new ArgumentException("Unsupported card type.");
            }
            return cardNumber;
        }
    }
}
