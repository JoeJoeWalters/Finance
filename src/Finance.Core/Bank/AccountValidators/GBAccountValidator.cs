using Finance.Core.Common;

namespace Finance.Core.IBAN.AccountValidators
{
    public class GBAccountValidator : IAccountValidator
    {
        public GBAccountValidator()
        {
        }

        public Boolean Validate(string countryCode, string bankCode, string accountSection)
        {
            // Sort code and account number must be 14 characters long
            if (accountSection.Length != 14)
                return false;

            // Sort code is the first 6 characters, must be numeric
            string sortCode = accountSection.Substring(0, 6);
            if (sortCode.NumericsOnly() != sortCode)
                return false;

            // Account number is the remaining characters, must be numeric
            string accountNumber = accountSection.Substring(6, accountSection.Length - 6);
            if (accountNumber.NumericsOnly() != accountNumber)
                return false;

            return true;
        }
    }
}
