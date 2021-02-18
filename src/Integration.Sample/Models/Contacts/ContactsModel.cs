using Integration.Sample.ApiServer.Contacts.Common;
using Integration.Sample.Attributes;
using Integration.Sample.Models.Common;
using System.ComponentModel;

namespace Integration.Sample.Models.Contacts
{
	public class ContactsModel : IEditLinkModel
	{
		[TableIgnore]
		public string Id { get; set; }

		[DisplayName("Name")]
		public string FullName { get; set; }

		public string Type { get; set; }

		public string Email { get; set; }

		public Phone Phone { get; set; }

		[TableIgnore]
		[TablePropertyLink(nameof(FullName))]
		public string EditLink { get; set; }
	}
}