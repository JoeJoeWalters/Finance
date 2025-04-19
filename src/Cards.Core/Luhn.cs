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
    }
}
