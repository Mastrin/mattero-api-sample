using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Contacts.Common;
using System.Collections.Generic;

namespace Integration.Sample.ApiServer.Contacts.Item
{
	/// <summary>
	/// A Detailed view of the contact
	/// </summary>
	public class ContactViewItem : ViewItemBase
	{
		/// <summary>
		///	The full name of the contact where the formatting is dependent on the type of the contact.
		///	A persons full name will have the surname first, followed by the given name, delimited by a comma.
		///	A company will just display the full name
		/// </summary>
		/// <example>
		/// Gently, George
		/// </example>
		public string FullName { get; set; }

		/// <summary>
		/// An abbreviation for the fullname of the contact
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// The website url associated with the contact
		/// </summary>
		/// <example>
		/// https://www.google.com.au
		/// </example>
		public string Website { get; set; }

		/// <summary>
		/// Notes made against the associated contact
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// The Australian Business Number associated with the contact
		/// </summary>
		public string Abn { get; set; }

		/// <summary>
		/// A list of physical addresses associated with the contact
		/// </summary>
		public IEnumerable<Address> Addresses { get; set; }

		/// <summary>
		/// A list of phone numbers associated with the contact
		/// </summary>
		public IEnumerable<Phone> Phones { get; set; }

		/// <summary>
		/// A list of email addresses associated with the contact
		/// </summary>
		/// <example>
		/// george@hotmail.com
		/// </example>
		public IEnumerable<string> Emails { get; set; }

		/// <summary>
		/// A list of custom fields and their associated values as defined in Mattero
		/// </summary>
		public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
	}
}
