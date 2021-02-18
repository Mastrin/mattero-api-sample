using Integration.Sample.ApiServer.Common.Models.Base;
using Integration.Sample.ApiServer.Contacts.Common;

namespace Integration.Sample.ApiServer.Contacts.Lookup
{
	/// <summary>
	/// Represent a request for looking up contacts
	/// </summary>
	public class ContactLookupRequest : LookupRequestBase
	{
		/// <summary>
		/// A term associated with the contact. This checks multiple properties including the multiple name properties.
		/// </summary>
		public string Term { get; set; }
		public ContactLookupType Type { get; set; }
	}
}