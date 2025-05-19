using Finance.Core.IBAN;
using FluentAssertions;

namespace Finance.Tests.IBANTests
{
    public class IBANTests
    {
        // https://www.iban.com/testibans
        // https://iban.co.uk/examples.html
        [Theory]
        [InlineData("GB91BKEN10000041610008")] // Valid IBAN, length, checksum, bank code, account and structure
        public void Given_IBAN_IsValid(string iban)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = Validator.IsValid(iban);

            // ASSERT
            result.Should().BeTrue();
        }

        // https://www.iban.com/testibans
        [Theory]
        [InlineData("GB94BARC10201530093459")] // Valid IBAN, bank code not found (bank cannot be identified): Valid length, checksum, bank code, account and structure
        [InlineData("GB94BARC20201530093459")] // Invalid IBAN check digits MOD-97-10 as per ISO/IEC 7064:2003
        [InlineData("GB96BARC202015300934591")] // Invalid IBAN length must be "X" characters long!
        [InlineData("GB24BARC20201630093459")] // Bank code not found and invalid account
        [InlineData("GB02BARC20201530093A59")] // Check Digits resolve to single digit integer
        [InlineData("GB12BARC20201530093A59")] // Invalid account structure
        [InlineData("GB78BARCO0201530093459")] // Bank code not found and invalid bank code structure
        [InlineData("GB2LABBY09012857201707")] // Invalid IBAN checksum and IBAN structure
        [InlineData("GB01BARC20714583608387")] // Invalid IBAN checksum
        [InlineData("GB00HLFX11016111455365")] // Invalid IBAN checksum
        [InlineData("US64SVBKUS6S3300958879")] // Country does not seem to support IBAN!
        public void Given_IBAN_IsInvalid(string iban)
        {
            // ARRANGE
            bool result = false;

            // ACT
            result = Validator.IsValid(iban);

            // ASSERT
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("GB", "MIDL", "40051512345674", "GB26MIDL40051512345674")]
        [InlineData("GB", "BUKB", "20201555555555", "GB33BUKB20201555555555")]
        public void Given_Components_Should_GenerateIBAN(
            string countryCode, 
            string bankCode,
            string accountNumber,
            string expectedIBAN)
        {
            // ARRANGE

            // ACT
            string iban = Generator.GenerateIBAN(countryCode, bankCode, accountNumber);

            // ASSERT
            iban.Should().NotBeNullOrEmpty();
            iban.Should().Be(expectedIBAN);
        }
    }
}
