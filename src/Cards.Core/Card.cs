using Finance.Cards.Core.Types;

namespace Finance.Cards.Core
{
    public class Card
    {
        /// <summary>
        /// The Primary Account Number (PAN) of the card.
        /// </summary>
        internal readonly string _pan;
        public string Pan => _pan;

        /// <summary>
        /// Gets the card type based on the PAN (Primary Account Number).
        /// </summary>
        public CardType CardType => Identification.WhatIs(_pan);

        /// <summary>
        /// Checks if the PAN is valid using the Luhn algorithm.
        /// </summary>
        public bool LuhnCheck => Luhn.IsValid(_pan);

        /// <summary>
        /// Creates a new instance of the Card class with the specified PAN.
        /// </summary>
        /// <param name="pan"></param>
        public Card(string pan)
        {
            _pan = pan;
        }

        public Card(CardType cardType)
        {
            _pan = Generator.CardNumber(cardType);
        }
    }
}
