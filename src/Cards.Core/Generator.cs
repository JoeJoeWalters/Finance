using Cards.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
            string cardNumber = string.Empty;
            switch (cardType)
            {
                case CardType.Visa:
                    cardNumber = Luhn.GenerateCard(Identification.VisaMIIRanges, Identification.VisaSizeRanges, true);
                    break;
                case CardType.MasterCard:
                    cardNumber = Luhn.GenerateCard(Generator.GenerateRanges(Identification.MastercardMIIRanges), Identification.MastercardSizeRanges, true);
                    break;
                case CardType.AmericanExpress:
                    cardNumber = Luhn.GenerateCard(Identification.AmericanExpressMIIRanges, Identification.AmericanExpressSizeRanges, true);
                    break;
                case CardType.Discover:
                    cardNumber = Luhn.GenerateCard(Generator.GenerateRanges(Identification.DiscoverMIIRanges), Identification.DiscoverSizeRanges, true);
                    break;
                case CardType.DinersClub:
                    cardNumber = Luhn.GenerateCard(Identification.DinersClubMIIRanges, Identification.DinersClubSizeRanges, true);
                    break;
                case CardType.JCB:
                    cardNumber = Luhn.GenerateCard(Identification.JCBMIIRanges, Identification.JCBSizeRanges, true);
                    break;
                case CardType.Maestro:
                    cardNumber = Luhn.GenerateCard(Identification.MaestroMIIRanges, Identification.MaestroSizeRanges, true);
                    break;
                case CardType.ChinaUnionPay:
                    cardNumber = Luhn.GenerateCard(Generator.GenerateRanges(Identification.ChinaUnionPayMIIRanges), Identification.ChinaUnionPaySizeRanges, false);
                    break;
                case CardType.UATP:
                    cardNumber = Luhn.GenerateCard(Identification.UATPMIIRanges, Identification.UATPSizeRanges, true);
                    break;
                default:
                    throw new ArgumentException("Unsupported card type.");
            }
            return cardNumber;
        }
    }
}
