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
            }
        };
    }
}
