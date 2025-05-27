using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Core.IBAN.Types
{
    public class IBANBankCode
    {
        public required string SWIFTorBIC { get; set; }
        public required string CountryCode { get; set; }
        public required string CheckSum { get; set; }

        // https://bank.codes/iban/bank/
        public static Dictionary<string, IBANBankCode> BankCodes = new Dictionary<string, IBANBankCode>
        {
             // GB Banks
             { "ABBY", new IBANBankCode
                {
                    SWIFTorBIC = "ABBY",
                    CountryCode = "GB",
                    CheckSum = "15"
                }
            },
            { "BARC", new IBANBankCode
                {
                    SWIFTorBIC = "BARC",
                    CountryCode = "GB",
                    CheckSum = "92"
                }
            },
            { "BKEN", new IBANBankCode
                {
                    SWIFTorBIC = "BKEN",
                    CountryCode = "GB",
                    CheckSum = "13"
                }
            },
            { "BOFI", new IBANBankCode
                {
                    SWIFTorBIC = "BOFI",
                    CountryCode = "GB",
                    CheckSum = "77"
                }
            },
            { "BOFS", new IBANBankCode
                {
                    SWIFTorBIC = "BOFS",
                    CountryCode = "GB",
                    CheckSum = "29"
                }
            },
            { "BUKB", new IBANBankCode
                {
                    SWIFTorBIC = "BUKB",
                    CountryCode = "GB",
                    CheckSum = "13"
                }
            },
            { "CITI", new IBANBankCode
                {
                    SWIFTorBIC = "CITI",
                    CountryCode = "GB",
                    CheckSum = "49"
                }
            },
            { "CLYD", new IBANBankCode
                {
                    SWIFTorBIC = "CLYD",
                    CountryCode = "GB",
                    CheckSum = "15"
                }
            },
            { "HBUK", new IBANBankCode
                {
                    SWIFTorBIC = "HBUK",
                    CountryCode = "GB",
                    CheckSum = "54"
                }
            },
            { "LOYD", new IBANBankCode
                {
                    SWIFTorBIC = "LOYD",
                    CountryCode = "GB",
                    CheckSum = "54"
                }
            },
            { "MIDL", new IBANBankCode
                {
                    SWIFTorBIC = "MIDL",
                    CountryCode = "GB",
                    CheckSum = "26"
                }
            },
            { "NWBK", new IBANBankCode
                {
                    SWIFTorBIC = "NWBK",
                    CountryCode = "GB",
                    CheckSum = "29"
                }
            },

            // DE - https://wise.com/gb/iban/germany/postbank
            { "37040044", new IBANBankCode
                {
                    SWIFTorBIC = "37040044",
                    CountryCode = "DE",
                    CheckSum = "89"
                }
            },

        };
    }
}
