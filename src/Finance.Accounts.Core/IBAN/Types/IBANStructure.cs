namespace Finance.Core.IBAN.Types
{
    public class IBANStructure
    {
        public required string CountryCode { get; set; }
        public required string County { get; set; }
        public required int Length { get; set; }
        public required bool SEPA { get; set; }
        public required bool AccountCheck { get; set; }
        public required bool Branch { get; set; }
        public required string Format { get; set; }

        public static Dictionary<string, IBANStructure> Structures = new Dictionary<string, IBANStructure>
        {
            { "AT", new IBANStructure
                {
                    CountryCode = "AT",
                    County = "Austria",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "BE", new IBANStructure
                {
                    CountryCode = "BE",
                    County = "Belgium",
                    Length = 16,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "CH", new IBANStructure
                {
                    CountryCode = "CH",
                    County = "Switzerland",
                    Length = 21,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "CY", new IBANStructure
                {
                    CountryCode = "CY",
                    County = "Cyprus",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "CZ", new IBANStructure
                {
                    CountryCode = "CZ",
                    County = "Czech Republic",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "DE", new IBANStructure
                {
                    CountryCode = "DE",
                    County = "Germany",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = "CCDDBBBBBBBBAAAAAAAAAA"
                }
            },
            { "DK", new IBANStructure
                {
                    CountryCode = "DK",
                    County = "Denmark",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "EE", new IBANStructure
                {
                    CountryCode = "EE",
                    County = "Estonia",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "ES", new IBANStructure
                {
                    CountryCode = "ES",
                    County = "Spain",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "FI", new IBANStructure
                {
                    CountryCode = "FI",
                    County = "Finland",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "FR", new IBANStructure
                {
                    CountryCode = "FR",
                    County = "France",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "GB", new IBANStructure
                {
                    CountryCode = "GB",
                    County = "United Kingdom",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = "CCDDBBBBAAAAAAAAAAAAAA"
                }
            },
            { "GR", new IBANStructure
                {
                    CountryCode = "GR",
                    County = "Greece",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "HU", new IBANStructure
                {
                    CountryCode = "HU",
                    County = "Hungary",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "IE", new IBANStructure
                {
                    CountryCode = "IE",
                    County = "Ireland",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "IT", new IBANStructure
                {
                    CountryCode = "IT",
                    County = "Italy",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "LT", new IBANStructure
                {
                    CountryCode = "LT",
                    County = "Lithuania",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "LV", new IBANStructure
                {
                    CountryCode = "LV",
                    County = "Latvia",
                    Length = 21,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "NL", new IBANStructure
                {
                    CountryCode = "NL",
                    County = "Netherlands",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "NO", new IBANStructure
                {
                    CountryCode = "NO",
                    County = "Norway",
                    Length = 15,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "PL", new IBANStructure
                {
                    CountryCode = "PL",
                    County = "Poland",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "PT", new IBANStructure
                {
                    CountryCode = "PT",
                    County = "Portugal",
                    Length = 25,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "SE", new IBANStructure
                {
                    CountryCode = "SE",
                    County = "Sweden",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "SI", new IBANStructure
                {
                    CountryCode = "SI",
                    County = "Slovenia",
                    Length = 19,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
            { "SK", new IBANStructure
                {
                    CountryCode = "SK",
                    County = "Slovakia",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true,
                    Format = ""
                }
            },
        };
    }
}
