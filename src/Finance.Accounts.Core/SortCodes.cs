using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Finance.Accounts.Core.Types;
using System.Globalization;

namespace Finance.Accounts.Core
{
    public class SortCodes
    {
        private readonly Dictionary<string, SortCodeRecord> _sortCodes;

        public SortCodes(Stream EISCDFile) 
        {
            _sortCodes = new Dictionary<string, SortCodeRecord>(); // Fallback

            using (StreamReader reader = new StreamReader(EISCDFile))
            {
                // Set up the standard reader options to read tab delimited data
                CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "\t", // Tab delimited
                    HasHeaderRecord = true, // The first row contains the header
                    TrimOptions = TrimOptions.Trim // Clean the data before trying to convert as there are trailing spaces                    
                });

                // Force date conversion types to be in a specific format
                TypeConverterOptions options = new TypeConverterOptions
                {
                    Formats = new[] { "dd/MM/yyyy" }
                };

                // Apply the date conversion options to the DateTime and DateTime? types
                csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                csv.Context.TypeConverterOptionsCache.AddOptions<DateTime?>(options);
                csv.Context.RegisterClassMap<SortCodeRecordMap>();

                // Read the records and perform any necessary conversions
                IEnumerable<SortCodeRecord> read = csv.GetRecords<SortCodeRecord>();
                _sortCodes = read.ToList().GroupBy(x => x.SortingCode).ToDictionary(g => g.Key, g => g.FirstOrDefault());
            }
        }

        public SortCodeRecord? Get(string sortCode)
        {
            if (_sortCodes.TryGetValue(CleanSortCode(sortCode), out SortCodeRecord? record))
            {
                return record;
            }
            return null;
        }

        private string CleanSortCode(string sortCode)
        {
            // Remove any spaces or dashes from the sort code
            return GetNumbers(sortCode);
        }

        private string GetNumbers(String inputString)
        {
            String result = "";
            string numbers = "0123456789";
            int i = 0;

            for (i = 0; i < inputString.Length; i++)
            {
                if (numbers.Contains(inputString.ElementAt(i)))
                    result += inputString.ElementAt(i);
            }
            return result;
        }
    }
}
