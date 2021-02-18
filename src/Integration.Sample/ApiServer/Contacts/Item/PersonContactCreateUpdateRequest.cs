using Integration.Sample.ApiServer.Contacts.Common;
using System;

namespace Integration.Sample.ApiServer.Contacts.Item
{
	/// <summary>
	/// Used to create or update a person contact
	/// </summary>
	public class PersonContactCreateUpdateRequest : ContactCreateUpdateRequest
	{
		/// <summary>
		/// The given name of the contact
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The middle name of the contact
		/// </summary>
		public string MiddleName { get; set; }

		/// <summary>
		/// The surname of the contact
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The date the contact was born
		/// </summary>
		public DateTime? Birthday { get; set; }

		/// <summary>
		/// The Company the contact works for or is associated with
		/// </summary>
		/// <example>
		/// Google
		/// </example>
		public string Company { get; set; }

		/// <summary>
		/// The job title for the company the associated contact works for
		/// </summary>
		public string JobTitle { get; set; }

		/// <summary>
		/// The contacts title or pronoun
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The Gender the contact identifies with
		/// </summary>
		public Gender Gender { get; set; }
	}
}