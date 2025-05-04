using CsvHelper;
using CsvHelper.Configuration;
using Finance.Accounts.Core.Types;
using System.Globalization;

namespace Finance.Accounts.Core
{
    // https://www.sortcodes.co.uk/eiscd-data-file-documentation
    // https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/in-memory-databases
    public class SortCodes
    {
        public SortCodes(Stream EISCDFile) 
        {
            using (StreamReader reader = new StreamReader(EISCDFile))
            {
                CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "\t",
                    HasHeaderRecord = true
                });
                
                var read = csv.GetRecords<SortCodeRecord>();
            }
        }
    }
}
