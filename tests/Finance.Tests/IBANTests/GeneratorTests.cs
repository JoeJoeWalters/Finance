using AwesomeAssertions;
using Finance.Core.IBAN;

namespace Finance.Tests.IBANTests
{
    public class GeneratorTests
    {
        // https://iban.co.uk/examples.html
        [Theory]
        [InlineData("GB", "MIDL", "40051512345674", "GB26MIDL40051512345674")]
        [InlineData("GB", "BUKB", "20201555555555", "GB33BUKB20201555555555")]
        [InlineData("GB", "BKEN", "10000041610008", "GB91BKEN10000041610008")]
        [InlineData("GB", "BOFI", "90212729823529", "GB27BOFI90212729823529")]
        [InlineData("GB", "BOFS", "80055100813796", "GB17BOFS80055100813796")]
        [InlineData("GB", "BARC", "20005275849855", "GB92BARC20005275849855")]
        [InlineData("GB", "CITI", "18500812098709", "GB66CITI18500812098709")]
        [InlineData("GB", "CLYD", "82663220400952", "GB15CLYD82663220400952")]
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

        [Theory]
        [InlineData("", "MIDL", "40051512345674")]
        [InlineData("GB", "", "40051512345674")]
        [InlineData("GB", "MIDL", "")]
        public void Given_Components_Should_FailWithArgumenException(
            string countryCode,
            string bankCode,
            string accountNumber)
        {
            // ARRANGE

            // ACT
            Action comparison = () => { string iban = Generator.GenerateIBAN(countryCode, bankCode, accountNumber); };

            // ASSERT
            comparison.Should().Throw<ArgumentException>().WithMessage("Country code, bank code, and account number must be provided.");

        }
    }
}
