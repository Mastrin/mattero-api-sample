using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace System.Reflection
{
	public static class PropertyInfoExtensions
	{
		public static string GetDisplayName(this PropertyInfo propertyInfo)
		{
			var attribute = propertyInfo
				.GetCustomAttributes()
				.Where(attribute => attribute is DisplayAttribute || attribute is DisplayNameAttribute)
				.OrderBy(attribute => attribute is DisplayAttribute ? 0 : 1)
				.FirstOrDefault();

			return attribute switch
			{
				DisplayAttribute displayAttribute => displayAttribute.Name,
				DisplayNameAttribute displayNameAttribute => displayNameAttribute.DisplayName,
				_ => propertyInfo.Name
			};
		}
	}
}
