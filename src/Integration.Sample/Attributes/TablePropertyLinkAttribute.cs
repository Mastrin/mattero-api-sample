using System;

namespace Integration.Sample.Attributes
{
	public class TablePropertyLinkAttribute : Attribute
	{
		public TablePropertyLinkAttribute(string propertyName)
			=> this.PropertyName = propertyName;

		public string PropertyName { get; }
	}
}