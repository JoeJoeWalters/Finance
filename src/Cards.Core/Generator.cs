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
                    cardNumber = GenerateRandomDigits(Identification.VisaRanges, 16);
                    break;
                case CardType.MasterCard:
                    cardNumber = GenerateRandomDigits(Identification.MastercardRanges, 16);
                    break;
                case CardType.AmericanExpress:
                    cardNumber = GenerateRandomDigits(Identification.AmericanExpressRanges, 15);
                    break;
                case CardType.Discover:
                    cardNumber = GenerateRandomDigits(Identification.DiscoverRanges, 16);
                    break;
                case CardType.DinersClub:
                    cardNumber = GenerateRandomDigits(Identification.DinersClubRanges, 15);
                    break;
                case CardType.JCB:
                    cardNumber = GenerateRandomDigits(Identification.JCBRanges, 16);
                    break;
                case CardType.Maestro:
                    cardNumber = GenerateRandomDigits(Identification.MaestroRanges, 16);
                    break;
                default:
                    throw new ArgumentException("Unsupported card type.");
            }
            return cardNumber;
        }

        private static string GenerateRandomDigits(string[] prefixes, int totalLength)
        {
            // Generate a random number of the specified length - 1 (to give space for the check digit)
            Random random = new Random();
            bool alternate = false;
            string prefix = prefixes[random.Next(0, prefixes.Length)];
            string cardNumber = prefix;
            int sum = 0;
            for (int i = 0; i < totalLength - prefix.Length - 1; i++)
            {
                int value = random.Next(0, 10);
                cardNumber += value.ToString();
            }

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            { 
                int value = int.Parse(cardNumber[i].ToString());
                int calculatedDigit = alternate ? value : value * 2;
                if (calculatedDigit > 9)
                    calculatedDigit -= 9;

                sum += calculatedDigit;
                alternate = !alternate;
            }
            int checkDigit = (10 - (sum % 10)) % 10;
            return cardNumber + checkDigit;
        }
    }
}
