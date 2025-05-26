namespace Finance.Core.IBAN.Types
{
    public class IBANStructure
    {
        public string CountryCode { get; set; }
        public string County { get; set; }
        public int Length { get; set; }
        public bool SEPA { get; set; }
        public bool AccountCheck { get; set; }
        public bool Branch { get; set; }

        public static Dictionary<string, IBANStructure> Structures = new Dictionary<string, IBANStructure>
        {
                    { "AT", new IBANStructure
                {
                    CountryCode = "AT",
                    County = "Austria",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "BE", new IBANStructure
                {
                    CountryCode = "BE",
                    County = "Belgium",
                    Length = 16,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "CH", new IBANStructure
                {
                    CountryCode = "CH",
                    County = "Switzerland",
                    Length = 21,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "CY", new IBANStructure
                {
                    CountryCode = "CY",
                    County = "Cyprus",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "CZ", new IBANStructure
                {
                    CountryCode = "CZ",
                    County = "Czech Republic",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "DE", new IBANStructure
                {
                    CountryCode = "DE",
                    County = "Germany",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "DK", new IBANStructure
                {
                    CountryCode = "DK",
                    County = "Denmark",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "EE", new IBANStructure
                {
                    CountryCode = "EE",
                    County = "Estonia",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "ES", new IBANStructure
                {
                    CountryCode = "ES",
                    County = "Spain",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "FI", new IBANStructure
                {
                    CountryCode = "FI",
                    County = "Finland",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "FR", new IBANStructure
                {
                    CountryCode = "FR",
                    County = "France",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "GB", new IBANStructure
                {
                    CountryCode = "GB",
                    County = "United Kingdom",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "GR", new IBANStructure
                {
                    CountryCode = "GR",
                    County = "Greece",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "HU", new IBANStructure
                {
                    CountryCode = "HU",
                    County = "Hungary",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "IE", new IBANStructure
                {
                    CountryCode = "IE",
                    County = "Ireland",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "IT", new IBANStructure
                {
                    CountryCode = "IT",
                    County = "Italy",
                    Length = 27,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "LT", new IBANStructure
                {
                    CountryCode = "LT",
                    County = "Lithuania",
                    Length = 20,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "LV", new IBANStructure
                {
                    CountryCode = "LV",
                    County = "Latvia",
                    Length = 21,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "NL", new IBANStructure
                {
                    CountryCode = "NL",
                    County = "Netherlands",
                    Length = 18,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "NO", new IBANStructure
                {
                    CountryCode = "NO",
                    County = "Norway",
                    Length = 15,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "PL", new IBANStructure
                {
                    CountryCode = "PL",
                    County = "Poland",
                    Length = 28,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "PT", new IBANStructure
                {
                    CountryCode = "PT",
                    County = "Portugal",
                    Length = 25,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "SE", new IBANStructure
                {
                    CountryCode = "SE",
                    County = "Sweden",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "SI", new IBANStructure
                {
                    CountryCode = "SI",
                    County = "Slovenia",
                    Length = 19,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            { "SK", new IBANStructure
                {
                    CountryCode = "SK",
                    County = "Slovakia",
                    Length = 24,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
        };
    }
}
