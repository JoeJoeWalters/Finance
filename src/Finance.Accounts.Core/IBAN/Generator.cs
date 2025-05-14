namespace Finance.Core.IBAN
{
    public static class Generator
    {
        // https://iban.co.uk/generation.html
        public static string GenerateIBAN(string countryCode, string bankCode, string accountNumber)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(countryCode) || string.IsNullOrWhiteSpace(bankCode) || string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Country code, bank code, and account number must be provided.");
            
            // Generate the IBAN structure
            string iban = $"{countryCode}00{bankCode}{accountNumber}";
            
            // Calculate the check digits
            string checkDigits = CalculateCheckDigits(iban);
        
            // Return the complete IBAN
            return $"{countryCode}{checkDigits}{bankCode}{accountNumber}";
        }

        private static string CalculateCheckDigits(string ibanSansDigits)
        {
            // Move the first four characters to the end of the string
            string rearrangedIban = ibanSansDigits.Substring(4) + ibanSansDigits.Substring(0, 4);

            uint current = 0;
            int length = rearrangedIban.Length;

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
            for (int i = 0; i < numericIban.Length; i++)
            {
                
            }

            // Return the check digits as a two-digit string
            return 0.ToString("D2");
        }
    }
}
