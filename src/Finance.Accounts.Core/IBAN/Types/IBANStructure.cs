using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
