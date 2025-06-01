namespace Finance.Core.IBAN.AccountValidators
{
    public static class AccountValidatorFactory
    {
        private static readonly Dictionary<string, IAccountValidator> _validators = new Dictionary<string, IAccountValidator>
        {
            { "GB", new GBAccountValidator() },
            { "DE", new DEAccountValidator() },
            // Add other country validators here
        };

        public static IAccountValidator GetValidator(string countryCode)
        {
            if (_validators.TryGetValue(countryCode.ToUpper(), out var validator))
            {
                return validator;
            }
            throw new NotSupportedException($"No account validator found for country code: {countryCode}");
        }
    }
}
