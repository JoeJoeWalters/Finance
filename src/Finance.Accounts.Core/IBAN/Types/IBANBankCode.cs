using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Core.IBAN.Types
{
    public class IBANBankCode
    {
        public string SWIFTorBIC { get; set; }
        public string Format { get; set; }
        public string CountryCode { get; set; }
        public string CheckSum { get; set; }

        // https://bank.codes/iban/bank/
        public static Dictionary<string, IBANBankCode> BankCodes = new Dictionary<string, IBANBankCode>
        {
            { "BKEN", new IBANBankCode
                {
                    SWIFTorBIC = "BKEN",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "13"
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
            { "BOFI", new IBANBankCode
                {
                    SWIFTorBIC = "BOFI",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "77"
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
            { "ABBY", new IBANBankCode
                {
                    SWIFTorBIC = "ABBY",
                    Format= "CCDDBBBBSSSSSSAAAAAAAA",
                    CountryCode = "GB",
                    CheckSum = "15"
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
