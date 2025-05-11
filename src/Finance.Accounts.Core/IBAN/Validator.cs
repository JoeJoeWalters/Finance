using Finance.Accounts.Core.IBAN.Types;

namespace Finance.Accounts.Core.IBAN
{
    public class Validator
    {
        private static Dictionary<string, IBANStructure> _ibanStructures = new Dictionary<string, IBANStructure>
        {
            {
                "GB", new IBANStructure
                {
                    CountryCode = "GB",
                    County = "United Kingdom",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            },
            {
                "DE", new IBANStructure
                {
                    CountryCode = "DE",
                    County = "Germany",
                    Length = 22,
                    SEPA = true,
                    AccountCheck = true,
                    Branch = true
                }
            }
        };

        // Structure checking of the IBAN format
        public static bool IsValid(string iban)
        {
            // Remove spaces and convert to uppercase
            iban = iban.Replace(" ", "").ToUpper();

            // Check length
            if (iban.Length < 15 || iban.Length > 34)
                return false;

            // Check the country code and see the required length
            string countryCode = iban.Substring(0, 2);
            if (!_ibanStructures.ContainsKey(countryCode))
                return false;

            // Country identidier says the IBAN length should be a given size
            if (iban.Length != _ibanStructures[countryCode].Length)
                return false;

            // Check the country code and see the required length
            string checkDigits = iban.Substring(2, 2);
            if (!int.Parse(checkDigits).ToString().Equals(iban.Substring(2, 2)))
                return false;

            return Mod97(iban);
        }

        private static bool Mod97(string iban)
        {
            // Move the first four characters to the end of the string
            string rearrangedIban = iban.Substring(4) + iban.Substring(0, 4);

            // Replace letters with numbers (A=10, B=11, ..., Z=35)
            string numericIban = "";
            foreach (char c in rearrangedIban)
            {
                if (char.IsDigit(c))
                    numericIban += c;
                else
                    numericIban += (c - 'A' + 10).ToString();
            }

            // Perform MOD-97 operation
            long remainder = 0;
            for (int i = 0; i < numericIban.Length; i++)
            {
                remainder = (remainder * 10 + (numericIban[i] - '0')) % 97;
            }

            return remainder == 1;
        }
    }
}
