using Cards.Core.Types;
using Cards.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Cards.Tests
{
    public class CardObjectTests
    {
        /// <summary>
        /// Checks the type of card based on the PAN (Primary Account Number).
        /// Only rudimentary tests are performed here as most of the logic is in the sub-class tests etc.
        /// </summary>
        /// <param name="pan">Primary Account Number</param>
        /// <param name="expectedResult">The Expected Enum result</param>
        /// <param name="luhnPass">True if the Luhn check passes</param>
        [Theory]
        [InlineData("5428542566720672", CardType.MasterCard, true)] // Mastercard
        [InlineData("5000000000000000", CardType.Unknown, false)] // Fake Mastercard
        public void Given_Pan_PassesChecks(string pan, CardType expectedResult, bool luhnPass)
        {
            // ARRANGE
            Card card;

            // ACT
            card = new Card(pan);

            // ASSERT
            card.CardType.Should().Be(expectedResult);
            card.LuhnCheck.Should().Be(luhnPass);
        }

    }
}
