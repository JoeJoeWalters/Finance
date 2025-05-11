namespace Finance.Cards.Core
{
    public static class Luhn
    {
        // NOTE: Not ready to implement this yet without a restructure of the identification class
        //public static string[][] ExcludedMIIRanges = { Identification.ChinaUnionPayMIIRanges };

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

        /// <summary>
        /// Generates a random card number of the specified length and prefix.
        /// </summary>
        /// <param name="prefixes">The range of the card MII and subcategory</param>
        /// <param name="totalLength">The total length of the card size</param>
        /// <param name="luhnRequired">True if the Luhn check digit is required</param>
        /// <returns>A credit card number of a given size with a luhn check digit</returns>
        public static string GenerateCard(string[] prefixes, Range sizeRange, bool luhnRequired)
        {
            // Generate a random number of the specified length - 1 (to give space for the check digit)
            string[] convertedPrefixes = Generator.GenerateRanges(prefixes);
            Random random = new Random();
            bool alternate = false;
            string prefix = convertedPrefixes[random.Next(0, convertedPrefixes.Length)];
            string cardNumber = prefix;
            int totalLength = random.Next(sizeRange.Start.Value, sizeRange.End.Value);

            int generationLength = totalLength - (luhnRequired ? prefix.Length + 1 : prefix.Length);
            for (int i = 0; i < generationLength; i++)
            {
                int value = random.Next(0, 10);
                cardNumber += value.ToString();
            }

            // Is the check digit required?
            if (luhnRequired)
            {
                // Calculate the check digit working backwards from the end to the start
                int sum = 0;
                for (int i = cardNumber.Length - 1; i >= 0; i--)
                {
                    int value = int.Parse(cardNumber[i].ToString());
                    int calculatedDigit = alternate ? value : value * 2;
                    if (calculatedDigit > 9)
                        calculatedDigit -= 9;

                    sum += calculatedDigit;
                    alternate = !alternate;
                }

                // Return the card number and the check digit applied to the last place
                int checkDigit = (10 - (sum % 10)) % 10;
                return cardNumber + checkDigit;
            }

            return cardNumber;
        }
    }
}
