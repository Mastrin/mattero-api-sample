using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Contacts.Common;

namespace Integration.Sample.ApiServer.Contacts.List
{
	/// <summary>
	/// Represents the details of a contact
	/// </summary>
	public class ContactListItem : ListItemBase
	{
		/// <summary>
		/// Specfies whether this contact is a person or company
		/// </summary>
		public ContactType Type { get; set; }

		/// <summary>
		/// An abbreviation for the fullname of the contact
		/// </summary>
		public string ShortName { get; set; }

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
		/// The region code for the address of the contact
		/// </summary>
		public string RegionCode { get; set; }

		/// <summary>
		/// The physical address of the contact
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// The phone number associated with the contact
		/// </summary>
		public Phone Phone { get; set; }

		/// <summary>
		/// The main email of the contact
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The alternative emails asssociated with the contact
		/// </summary>
		public string[] Emails { get; set; } = new string[0];
	}
}