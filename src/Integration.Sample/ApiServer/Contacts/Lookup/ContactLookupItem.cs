using Integration.Sample.ApiServer.Common.Models.Base;

namespace Integration.Sample.ApiServer.Contacts.Lookup
{
	/// <summary>
	/// Represents the details of a contact
	/// </summary>
	public class ContactLookupItem : LookupItemBase
	{
		/// <summary>
		/// The contacts title or pronoun
		/// </summary>
		public string Title { get; set; }

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
		/// The Company associated with the contact
		/// </summary>
		public string Company { get; set; }

		/// <summary>
		/// The job title for the company the associated contact works for
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// Additional information stored against the contact
		/// </summary>
		public string AdditionalInfo { get; set; }
	}
}