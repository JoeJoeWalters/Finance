using Finance.Core.Cards;
using Finance.Core.Types;
using FluentAssertions;

namespace Finance.Tests
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
        [InlineData("3000000000000000", CardType.Unknown, false)] // Unknown Range
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

        [Theory]
        [InlineData(CardType.UATP, true)] // UATP (15 Digits)
        [InlineData(CardType.MasterCard, true)] // Mastercard (16 Digits)
        [InlineData(CardType.Visa, true)] // Visa (16 Digits)
        [InlineData(CardType.AmericanExpress, true)] // American Express (15 Digits)
        [InlineData(CardType.Discover, true)] // Discover (16 Digits)
        [InlineData(CardType.DinersClub, true)] // Diners Club (14 Digits)
        [InlineData(CardType.JCB, true)] // JCB (16 Digits)
        [InlineData(CardType.Maestro, true)] // Maestro (16 Digits)
        [InlineData(CardType.ChinaUnionPay, false)] // China Union Pay (16 to 19 Digits)
        public void Given_Pan_IsType_When_RequestingTestCardOnConstructor(CardType cardType, bool luhnCheck)
        {
            // ARRANGE

            // ACT
            Card card = new Card(cardType);

            // ASSERT
            card.CardType.Should().Be(cardType);
            if (luhnCheck)
                card.LuhnCheck.Should().BeTrue();
        }

    }
}
