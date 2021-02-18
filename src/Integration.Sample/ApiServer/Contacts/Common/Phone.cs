namespace Integration.Sample.ApiServer.Contacts.Common
{
	/// <summary>
	/// Represents either a local or international phone number
	/// </summary>
	public class Phone
	{
		/// <summary>
		///		Number in the RFC 3966 format.
		///		Represented as per INTERNATIONAL format, but with all spaces and other separating symbols replaced with a hyphen,
		///		and with any phone number extension appended with ";ext=". It also will have a prefix of "tel:" added, e.g. "tel:+41-44-668-1800;ext=55".
		/// </summary>
		public string Rfc3966 { get; set; }

		/// <summary>
		///		Number for viewing in the UI.
		///		Represented as per NATIONAL format for the local numbers (so far Australian only) and as per INTERNATIONAL for foreign numbers,
		///		e.g. "+41 44 668 18 00 ext. 55"
		/// </summary>
		public string Number { get; set; }

		public override string ToString()
			=> Number;
	}
}