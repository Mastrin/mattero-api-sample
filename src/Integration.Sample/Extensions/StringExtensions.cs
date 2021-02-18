using System;
using System.Security;

namespace Integration.Sample.Extensions
{
	public static class StringExtensions
	{
		public static string ToLowerCamelCase(this string str)
		{
			if (str == null)
				throw new ArgumentNullException(nameof(str));

			if (string.IsNullOrWhiteSpace(str))
				return str;

			var output = str[..1].ToLower();

			if (str.Length > 1)
				output += str[1..];

			return output;
		}

		public static string FormatControllerName(this string str)
		{
			if (str == null)
				throw new ArgumentNullException(nameof(str));

			if (string.IsNullOrWhiteSpace(str))
				throw new ArgumentException(nameof(str));

			if (str.EndsWith("Controller"))
				str = str[0..^10];

			return str;
		}

		public static string FormatActionName(this string str)
		{
			if (str == null)
				throw new ArgumentNullException(nameof(str));

			if (string.IsNullOrWhiteSpace(str))
				throw new ArgumentException(nameof(str));

			if (str.EndsWith("Async"))
				str = str[0..^5];

			return str;
		}


		public static SecureString ToSecureString(this string str)
		{
			SecureString secureString = new SecureString();
			foreach (char c in str)
				secureString.AppendChar(c);

			return secureString;
		}
	}
}