namespace Finance.Core.IBAN
{
    public interface IAccountValidator
    {
        Boolean Validate(string countryCode, string bankCode, string accountSection);
    }
}
