namespace Integration.Sample.ApiServer.Contacts.Item
{
	/// <summary>
	/// Used to create or update a company contact
	/// </summary>
	public class CompanyContactCreateUpdateRequest : ContactCreateUpdateRequest
	{
		/// <summary>
		/// The name of the company contact
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Australian Company Number of the company contact
		/// </summary>
		public string Acn { get; set; }
	}
}