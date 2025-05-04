using Finance.Accounts.Core;

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

        [Fact]
        public void SearchTest()
        {

        }
    }
}