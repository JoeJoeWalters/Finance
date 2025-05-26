using Finance.Core.SortCodes;
using Finance.Core.SortCodes.Types;
using AwesomeAssertions;

namespace Finance.Tests.SortCodeTests
{
    public class SortCodesTests
    {
        private SortCodes _sortCodes;

        public SortCodesTests()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "EISCD.txt");
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            _sortCodes = new SortCodes(fileStream);
        }

        [Theory]
        [InlineData("123456")]
        public void Given_InvalidSortCode_GetRecord(string sortCode)
        {
            // ARRANGE
            SortCodeRecord? record;

            // ACT
            record = _sortCodes.Get(sortCode);

            // ASSERT
            record.Should().BeNull();
        }

        [Theory]
        [InlineData("090025", "ABBEY NAT TY INT LTD")]
        [InlineData("609230", "BANK OF MONTREAL")]
        [InlineData("200052", "BARCLAYS BANK PLC")]
        public void Given_ValidSortCode_GetRecord(string sortCode, string shortOwningBankName)
        {
            // ARRANGE
            SortCodeRecord? record;

            // ACT
            record = _sortCodes.Get(sortCode);

            // ASSERT
            record.Should().NotBeNull();
            record.SortingCode.Should().Be(sortCode);
            record.ShortNameOwningBank.Should().Be(shortOwningBankName);
        }

        [Theory]
        [InlineData("09-00-25", "090025", "ABBEY NAT TY INT LTD")]
        [InlineData("09 00 25", "090025", "ABBEY NAT TY INT LTD")]
        public void Given_SortCodeWithAlphas_GetRecord(string sortCode, string cleanSortCode, string shortOwningBankName)
        {
            // ARRANGE
            SortCodeRecord? record;

            // ACT
            record = _sortCodes.Get(sortCode);

            // ASSERT
            record.Should().NotBeNull();
            record.SortingCode.Should().Be(cleanSortCode);
            record.ShortNameOwningBank.Should().Be(shortOwningBankName);
        }
    }
}