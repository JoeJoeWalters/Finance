using Cards.Core;
using Cards.Core.Types;
using FluentAssertions;

namespace Cards.Tests
{
    public class GeneratorTests
    {
        [Theory]
        [InlineData(CardType.MasterCard)] // Mastercard (16 Digits)
        [InlineData(CardType.Visa)] // Visa (16 Digits)
        [InlineData(CardType.AmericanExpress)] // American Express (15 Digits)
        [InlineData(CardType.Discover)] // Discover (16 Digits)
        [InlineData(CardType.DinersClub)] // Diners Club (14 Digits)
        [InlineData(CardType.JCB)] // JCB (16 Digits)
        public void Given_Pan_IsType(CardType cardType)
        {
            // ARRANGE
            Card card = new Card(cardType);

            // ACT

            // ASSERT
            card.CardType.Should().Be(cardType);
            card.LuhnCheck.Should().BeTrue();
        }
    }
}
