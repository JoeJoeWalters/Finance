using AwesomeAssertions;
using Finance.Core.Cards;
using Finance.Core.IBAN;
using Finance.Core.IBAN.AccountValidators;
using Finance.Core.Types;
using System;

namespace Finance.Tests.IBANTests
{
    public class ValidatorTests
    {
        // https://www.iban.com/testibans
        // https://iban.co.uk/examples.html
        [Theory]
        [InlineData("GB91BKEN10000041610008")]
        [InlineData("GB26MIDL40051512345674")]
        [InlineData("GB33BUKB20201555555555")]
        [InlineData("GB27BOFI90212729823529")]
        [InlineData("GB17BOFS80055100813796")]
        [InlineData("GB92BARC20005275849855")]
        [InlineData("GB66CITI18500812098709")]
        [InlineData("GB15CLYD82663220400952")]
        [InlineData("DE89370400440532013000")]
        [InlineData("AL47212110090000000235698741")] // No Account validation for this country (Used for default checks)
        public void Given_IBAN_IsValid(string iban)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = IBANValidator.IsValid(iban);

            // ASSERT
            result.Should().BeTrue();
        }

        // https://www.iban.com/testibans
        [Theory]
        [InlineData("GB94BARC20201530093459")] // Invalid IBAN check digits MOD-97-10 as per ISO/IEC 7064:2003
        [InlineData("GB96BARC202015300934591")] // Invalid IBAN length must be "X" characters long!
        [InlineData("GB02BARC20201530093A59")] // Check Digits resolve to single digit integer
        [InlineData("GB12BARC20201530093A59")] // Invalid account structure
        [InlineData("GB78BARCO0201530093459")] // Invalid bank code structure
        [InlineData("GB2LABBY09012857201707")] // Invalid IBAN checksum and IBAN structure
        [InlineData("GB00HLFX11016111455365")] // Invalid IBAN checksum
        [InlineData("US64SVBKUS6S3300958879")] // Country does not seem to support IBAN!
        [InlineData("XX111")] // Too Short
        [InlineData("XX111111111111111111111111111111111")] // Too Long
        [InlineData("AL472121100900000002356987XX")] // No Account validation for this country so will fail on numerics only
        public void Given_IBAN_IsInvalid(string iban)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = IBANValidator.IsValid(iban);

            // ASSERT
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("GB")]
        [InlineData("DE")]
        public void Given_CountryCode_Should_Return_Validator(string countryCode)
        {
            // ARRANGE
            IAccountValidator validator;

            // ACT
            validator = AccountValidatorFactory.GetValidator(countryCode);

            // ASSERT
            validator.Should().NotBeNull();
        }

        [Theory]
        [InlineData("US")]
        [InlineData("XX")]
        public void Given_CountryCode_ShouldNot_Return_Validator(string countryCode)
        {
            // ACT
            Action comparison = () => { IAccountValidator result = AccountValidatorFactory.GetValidator(countryCode); };

            // ASSERT
            comparison.Should().Throw<NotSupportedException>().WithMessage($"No account validator found for country code: {countryCode}");

        }

        [Theory]
        [InlineData("GB", "BARC", "20201530093459")]
        [InlineData("DE", "8937040044", "0532013000")]
        public void Given_Validator_Should_ValidateLength(string countryCode, string bankCode, string accountSection)
        {
            // ARRANGE
            IAccountValidator validator;

            // ACT
            validator = AccountValidatorFactory.GetValidator(countryCode);
            bool result = validator.Validate(accountSection, bankCode, accountSection);

            // ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("GB", "BARC", "2020530093459")]
        [InlineData("DE", "8937040044", "053013000")]
        public void Given_Validator_Should_ThowInvalidateLength(string countryCode, string bankCode, string accountSection)
        {
            // ARRANGE
            IAccountValidator validator;

            // ACT
            validator = AccountValidatorFactory.GetValidator(countryCode);
            bool result = validator.Validate(accountSection, bankCode, accountSection);

            // ASSERT
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("GB", "BARC", "202015300934XX")]
        [InlineData("DE", "8937040044", "05320130XX")]
        public void Given_Validator_Should_ThrowNotNumeric(string countryCode, string bankCode, string accountSection)
        {
            // ARRANGE
            IAccountValidator validator;

            // ACT
            validator = AccountValidatorFactory.GetValidator(countryCode);
            bool result = validator.Validate(accountSection, bankCode, accountSection);

            // ASSERT
            result.Should().BeFalse();
        }
    }
}
