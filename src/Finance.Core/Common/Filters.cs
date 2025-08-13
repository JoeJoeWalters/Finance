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

        public static Range RangeOf(this string value, char character)
        {
            return new Range
            (
                value.IndexOf(character) + 1,
                value.LastIndexOf(character)
            );
        }

        public static string ValueInRangeOf(this string value, string format, char character)
        {
            Range range = format.RangeOf(character);
            return value.Substring(range.Start.Value - 1, (range.End.Value + 1) - (range.Start.Value - 1));
        }
    }
}
