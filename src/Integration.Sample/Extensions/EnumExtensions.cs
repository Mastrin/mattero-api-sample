namespace System
{
	public static class EnumExtensions
	{
		public static string ToDisplayName(this Enum flag)
		{
			var name = flag.ToString();

			string output = string.Empty;
			foreach (char chr in name)
			{
				if (char.IsUpper(chr) && output != string.Empty)
					output += " ";

				output += chr;
			}

			return output;
		}
	}
}