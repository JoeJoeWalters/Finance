namespace Finance.Core.Common
{
    public static class Filters
    {
        public static string NumericsOnly(this string sortCode)
        {
            string result = string.Empty;
            string numbers = "0123456789";
            int i = 0;

            for (i = 0; i < sortCode.Length; i++)
            {
                if (numbers.Contains(sortCode.ElementAt(i)))
                    result += sortCode.ElementAt(i);
            }
            return result;
        }
    }
}
