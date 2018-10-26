namespace Apparent.Trafikverket.Util
{
	public static class StringHelper
	{
		public static string FixSpecialChars(this string input)
		{
			if (string.IsNullOrWhiteSpace(input)) return input;

			input = input.ToLower().Replace("å", "[aring]");
			input = input.ToLower().Replace("ä", "å");
			input = input.ToLower().Replace("[aring]", "ä");

			return input;
		}
	}
}