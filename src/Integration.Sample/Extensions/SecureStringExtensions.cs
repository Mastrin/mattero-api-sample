using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Integration.Sample.Extensions
{
	public static class SecureStringExtensions
	{
		public static string ToUnsecureString(this SecureString value)
		{
			IntPtr valuePtr = IntPtr.Zero;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
				return Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}
		}
	}
}