using Finance.Core.Cards;
using Finance.Core.Types;
using FluentAssertions;

namespace Finance.Tests.SortCodeTests
{
    public class IdentificationTests
    {
        [Theory]
        [InlineData("142854256672067", CardType.UATP)] // UATP (15 Digits)
        [InlineData("5428542566720672", CardType.MasterCard)] // Mastercard (16 Digits)
        [InlineData("4698467663093870", CardType.Visa)] // Visa (16 Digits)
        [InlineData("376566029866460", CardType.AmericanExpress)] // American Express (15 Digits)
        [InlineData("6011403526507090", CardType.Discover)] // Discover (16 Digits)
        [InlineData("36569309025904", CardType.DinersClub)] // Diners Club (14 Digits)
        [InlineData("3530111333300000", CardType.JCB)] // JCB (16 Digits)
        [InlineData("6754407117965303", CardType.Maestro)] // Maestro (16 Digits)
        public void Given_Pan_IsType(string pan, CardType expectedResult)
        {
            // ARRANGE
            CardType result = CardType.Unknown;

            // ACT
            result = Identification.WhatIs(pan);

            // ASSERT
            result.Should().Be(expectedResult);
        }

        // Note: does comparison on pattern only and no luhn check at the same time 
        // which means form and not validity
        [Theory]
        [InlineData("1428542566720", CardType.UATP)] // UATP (15 Digits)
        [InlineData("542854256672067", CardType.MasterCard)] // Mastercard (16 Digits)
        [InlineData("469846766309387", CardType.Visa)] // Visa (16 Digits)
        [InlineData("37656602986646", CardType.AmericanExpress)] // American Express (15 Digits)
        [InlineData("601140352650709", CardType.Discover)] // Discover (16 Digits)
        [InlineData("3656930902590", CardType.DinersClub)] // Diners Club (14 Digits)
        [InlineData("353011133330000", CardType.JCB)] // JCB (16 Digits)
        [InlineData("675440711796530", CardType.Maestro)] // Maestro (16 Digits)
        public void Given_PanOfWrongLength_Should_ThrowArgumentException(string pan, CardType expectedResult)
        {
            // ARRANGE
            CardType result = CardType.Unknown;

            // ACT
            Action comparison = () => { var result = Identification.WhatIs(pan); };

            // ASSERT
            comparison
                    .Should()
                        .Throw<ArgumentException>().WithMessage("Invalid card number length for the identified card type.")
                    .And
                        .InnerException.Message.Should().Be($"Length for card type '{expectedResult}' is incorrect.");
        }

        /*
        Note: Fake visa and Mastercard doesn't work as it's more simplistic range (1 digit super range)
        be combined with Luhn algorithm to be valid.
        */
        [Theory]
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

        [Theory]
        [InlineData("4005519200000004", CardType.Visa, 40054, 40056)]
        [InlineData("2223000048400011", CardType.MasterCard, 2221, 2720)]
        public void Given_BINRangeAndPan_Then_FindRange(string pan, CardType cardType, int rangeFrom, int rangeTo)
        {
            // ARRANGE
            Range testRange = new Range(rangeFrom, rangeTo);
            BINRange binRange = new BINRange(cardType.ToString(), new Range[] { testRange });

            // ACT
            BINRange result = Identification.InRange(new BINRange[] { binRange }, pan);

            // ASSERT
            result.Should().BeEquivalentTo(binRange);
        }
    }
}