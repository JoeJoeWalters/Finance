using Cards.Core;
using Cards.Core.Types;
using FluentAssertions;

namespace Cards.Tests
{
    public class LuhnTests
    {
        [Theory]
        [InlineData("5428542566720672")] // Mastercard (16 Digits)
        [InlineData("4698467663093870")] // Visa (16 Digits)
        [InlineData("376566029866460")] // American Express (15 Digits)
        [InlineData("6011403526507090")] // Discover (16 Digits)
        [InlineData("30569309025904")] // Diners Club (14 Digits)
        public void Given_Pan_IsValid(string pan)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = Luhn.IsValid(pan);

            // ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("5428542566720671")] // Mastercard (16 Digits)
        [InlineData("4698467663093871")] // Visa (16 Digits)
        [InlineData("376566029866461")] // American Express (15 Digits)
        [InlineData("6011403526507091")] // Discover (16 Digits)
        [InlineData("30569309025903")] // Diners Club (14 Digits)
        public void Given_Pan_IsNotValid(string pan)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = Luhn.IsValid(pan);

            // ASSERT
            result.Should().BeFalse();
        }

        /// <summary>
        /// The rest of the card generation tests appear under the card object tests.
        /// </summary>
        [Fact]
        public void Given_Type_When_GeneratingTestCard_Should_BeValid()
        {
            // ARRANGE
            string cardNumber = Luhn.GenerateCard(Identification.VisaRanges, Identification.VisaLength);

            // ACT

            // ASSERT
            Identification.WhatIs(cardNumber).Should().Be(CardType.Visa);
            Luhn.IsValid(cardNumber).Should().BeTrue();
        }
    }
}