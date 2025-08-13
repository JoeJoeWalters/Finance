using Finance.Core.Common;

namespace Finance.Core.IBAN.AccountValidators
{
    public class DEAccountValidator : IAccountValidator
    {
        public DEAccountValidator()
        {
        }

        public Boolean Validate(string countryCode, string bankCode, string accountSection)
        {
            // Sort code and account number must be 14 characters long
            if (accountSection.Length != 10)
                return false;

            // Account number must be numeric
            if (accountSection.NumericsOnly() != accountSection)
                return false;

            return true;
        }
    }
}
