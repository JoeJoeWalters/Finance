using Finance.Core.Common;
using Finance.Core.IBAN.Types;

namespace Finance.Core.IBAN
{
    public class Validator
    {
        // Structure checking of the IBAN format
        public static bool IsValid(string iban)
        {
            // Remove spaces and convert to uppercase
            iban = iban.Replace(" ", "").ToUpper();

            // Ensure there is a checksum, valid bank code and valid structure
            if (!StructureCheck(iban))
                return false;

            // Ensure the check digits are valid
            return Mod97(iban);
        }

        private static bool StructureCheck(string iban)
        {
            // Check length
            if (iban.Length < 15 || iban.Length > 34)
                return false;

            // Check the country code and see the required length
            string countryCode = iban.Substring(0, 2);
            if (!IBANStructure.Structures.ContainsKey(countryCode))
                return false;

            // Country identifier says the IBAN length should be a given size
            if (iban.Length != IBANStructure.Structures[countryCode].Length)
                return false;

            // Get the bank code and see if it is valid
            string bankCode = iban.Substring(4, 4);
            IBANBankCode bank = IBANBankCode.BankCodes.FirstOrDefault(x => x.Key.Equals(bankCode) && x.Value.CountryCode == countryCode).Value;
            if (bank == null)
                return false;

            // Check the check digits and see they are numeric
            string checkDigits = iban.Substring(2, 2);
            int.TryParse(checkDigits, out int checkDigitValue);
            string paddedDigits = checkDigitValue.ToString().PadLeft(2, '0');
            if (!paddedDigits.Equals(checkDigits))
                return false;

            // Make sure the remaining characters are numeric
            string checkAccount = iban.Substring(8, iban.Length - 8);
            if (checkAccount.NumericsOnly() != checkAccount)
                return false;

            return true;
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
