namespace Cards.Core
{
    public static class Luhn
    {
        /// <summary>
        /// Checks if the given Primary Account Number (PAN) is valid using the Luhn algorithm.
        /// </summary>
        /// <param name="pan">Primary Account Number</param>
        /// <returns></returns>
        public static bool IsValid(string pan)
        {
            if (string.IsNullOrEmpty(pan))
                return false;
            int sum = 0;
            bool alternate = false;
            for (int i = pan.Length - 1; i >= 0; i--)
            {
                char[] digits = pan.ToCharArray();
                int n = int.Parse(digits[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }
                sum += n;
                alternate = !alternate;
            }
            return sum % 10 == 0;
        }

        public static string GenerateCard(string[] prefixes, int totalLength)
        {
            // Generate a random number of the specified length - 1 (to give space for the check digit)
            Random random = new Random();
            bool alternate = false;
            string prefix = prefixes[random.Next(0, prefixes.Length)];
            string cardNumber = prefix;
            int sum = 0;
            for (int i = 0; i < totalLength - prefix.Length - 1; i++)
            {
                int value = random.Next(0, 10);
                cardNumber += value.ToString();
            }

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int value = int.Parse(cardNumber[i].ToString());
                int calculatedDigit = alternate ? value : value * 2;
                if (calculatedDigit > 9)
                    calculatedDigit -= 9;

                sum += calculatedDigit;
                alternate = !alternate;
            }
            int checkDigit = (10 - (sum % 10)) % 10;
            return cardNumber + checkDigit;
        }
    }
}
