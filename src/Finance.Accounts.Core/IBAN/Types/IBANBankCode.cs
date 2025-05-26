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
        public required string Format { get; set; }
        public required string CountryCode { get; set; }
        public required string CheckSum { get; set; }

        // https://bank.codes/iban/bank/
        public static Dictionary<string, IBANBankCode> BankCodes = new Dictionary<string, IBANBankCode>
        {
             // GB Banks
             { "ABBY", new IBANBankCode
                {
                    SWIFTorBIC = "ABBY",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "15"
                }
            },
            { "BARC", new IBANBankCode
                {
                    SWIFTorBIC = "BARC",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "92"
                }
            },
            { "BKEN", new IBANBankCode
                {
                    SWIFTorBIC = "BKEN",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "13"
                }
            },
            { "BOFI", new IBANBankCode
                {
                    SWIFTorBIC = "BOFI",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "77"
                }
            },
            { "BOFS", new IBANBankCode
                {
                    SWIFTorBIC = "BOFS",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "29"
                }
            },
            { "BUKB", new IBANBankCode
                {
                    SWIFTorBIC = "BUKB",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "13"
                }
            },
            { "CITI", new IBANBankCode
                {
                    SWIFTorBIC = "CITI",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "49"
                }
            },
            { "CLYD", new IBANBankCode
                {
                    SWIFTorBIC = "CLYD",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "15"
                }
            },
            { "HBUK", new IBANBankCode
                {
                    SWIFTorBIC = "HBUK",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "54"
                }
            },
            { "LOYD", new IBANBankCode
                {
                    SWIFTorBIC = "LOYD",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "54"
                }
            },
            { "MIDL", new IBANBankCode
                {
                    SWIFTorBIC = "MIDL",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "26"
                }
            },
            { "NWBK", new IBANBankCode
                {
                    SWIFTorBIC = "NWBK",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "29"
                }
            }
        };
    }
}
