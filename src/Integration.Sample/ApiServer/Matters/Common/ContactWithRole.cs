namespace Integration.Sample.ApiServer.Matters.Common
{
	/// <summary>
	/// Represents a contact entity with its associated role
	/// </summary>
	public class ContactWithRole
	{
		/// <summary>
		/// The name of the role
		/// </summary>
		public string RoleName { get; set; }

		/// <summary>
		/// Associated identifier of the field
		/// </summary>
		public string FieldId { get; set; }

		/// <summary>
		/// Identifier of the contanct
		/// </summary>
		public string ContactId { get; set; }

		/// <summary>
		/// Name for the contact
		/// </summary>
		public string ContactName { get; set; }

		/// <summary>
		/// Specifices whether this contact role is mandatory
		/// </summary>
		public bool Mandatory { get; set; }
	}
}
