using Finance.Accounts.Core;
using Finance.Accounts.Core.Types;
using FluentAssertions;

namespace Finance.Accounts.Tests
{
    public class SortCodesTests
    {
        private SortCodes _sortCodes;

        public SortCodesTests()
        {
            FileStream fileStream = new FileStream("Data/EISCD.txt", FileMode.Open, FileAccess.Read);
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
        public void Given_ValidSortCode_GetRecord(string sortCode, string shortOwningBankName)
        {
            // ARRANGE
            SortCodeRecord? record;

            // ACT
            record = _sortCodes.Get(sortCode);

            // ASSERT
            record.Should().NotBeNull();
            record.GENERALSortingCode.Should().Be(sortCode);
            record.GENERALShortNameOwningBank.Should().Be(shortOwningBankName);
        }
    }
}