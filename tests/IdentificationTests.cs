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

        /*
        Note: Fake visa doesn't work as it's more simplistic instructure but should 
        be combined with Luhn algorithm to be valid.
        */
        [Theory]
        [InlineData("5000000000000000")] // Fake Mastercard
        [InlineData("300000000000000")] // Fake American Express
        [InlineData("6000000000000000")] // Fake Discover
        [InlineData("3000000000000")] // Fake Diners Club
        public void Given_Pan_IsUnknown(string pan)
        {
            // ARRANGE
            CardType result = CardType.Unknown;

            // ACT
            result = Identification.WhatIs(pan);

            // ASSERT
            result.Should().Be(CardType.Unknown);
        }
    }
}