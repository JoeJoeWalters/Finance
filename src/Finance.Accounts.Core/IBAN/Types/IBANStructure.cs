namespace Finance.Accounts.Core.IBAN.Types
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
            { "CH", new IBANStructure
                {
                    CountryCode = "CH",
                    County = "Switzerland",
                    Length = 21,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            }
        };
    }
}
