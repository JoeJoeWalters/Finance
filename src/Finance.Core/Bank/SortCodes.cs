﻿using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Finance.Core.Bank.Types;
using Finance.Core.Common;
using System.Globalization;

namespace Finance.Core.Bank
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
                _sortCodes = read.ToList().GroupBy(x => x.SortingCode).ToDictionary(g => g.Key, g => g.First());
            }
        }

        public SortCodeRecord? Get(string sortCode)
        {
            if (_sortCodes.TryGetValue(sortCode.NumericsOnly(), out SortCodeRecord? record))
            {
                return record;
            }
            return null;
        }
    }
}
