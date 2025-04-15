using Cards.Core;
using Cards.Core.Types;
using FluentAssertions;

namespace Cards
{
    public class IdentificationTests
    {
        [Theory]
        [InlineData("5428542566720672", CardType.MasterCard)] // Mastercard (16 Digits)
        [InlineData("4698467663093870", CardType.Visa)] // Visa (16 Digits)
        [InlineData("376566029866460", CardType.AmericanExpress)] // American Express (15 Digits)
        [InlineData("6011403526507090", CardType.Discover)] // Discover (16 Digits)
        [InlineData("30569309025904", CardType.DinersClub)] // Diners Club (14 Digits)
        public void Given_Pan_IsType(string pan, CardType expectedResult)
        {
            // ARRANGE
            CardType result = CardType.Unknown;

            // ACT
            result = Identification.WhatIs(pan);

            // ASSERT
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Given_Pan_IsUnknown()
        {
            // ARRANGE
            string pan = "5000000000000000"; // Pretending to be mastercard
            CardType result = CardType.Unknown;

            // ACT
            result = Identification.WhatIs(pan);

            // ASSERT
            result.Should().Be(CardType.Unknown);
        }
    }
}