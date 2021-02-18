namespace Integration.Sample.ApiServer.Contacts.Common
{
	/// <summary>
	/// The representation of a global physical address
	/// </summary>
	public class Address
	{
		/// <summary>
		///		Required. CLDR region code of the country/region of the address.
		/// </summary>
		/// <remarks>
		///		See http://cldr.unicode.org/ and http://www.unicode.org/cldr/charts/30/supplemental/territory_information.html for details.
		/// </remarks>
		/// <example>"CH" for Switzerland</example>
		public string RegionCode { get; set; }
		/// <summary>
		///		Highest administrative subdivision which is used for postal addresses of a country or region
		/// </summary>
		/// <example>
		///		State, a province, an oblast, or a prefecture
		///	</example>
		public string AdministrativeArea { get; set; }
		/// <summary>
		///		Generally refers to the city/town portion of the address
		/// </summary>
		/// <example>
		///		Suburb
		/// </example>
		public string Locality { get; set; }
		/// <summary>
		///		Sublocality of the address. For example, this can be neighborhoods, boroughs, districts
		/// </summary>
		public string SubLocality { get; set; }

		/// <summary>
		///		Postal code of the address.
		/// </summary>
		/// <remarks>
		///		Not all countries use or require postal codes to be present, but where they are used, they may trigger additional validation with other parts of the address (e.g. state/zip validation in the U.S.A.).
		/// </remarks>
		public string PostalCode { get; set; }

		/// <summary>
		///		Line1 of unstructured address lines describing the lower levels of an address.
		///		The order of address lines should be "envelope order" for the country/region of the address.
		/// </summary>
		public string Line1 { get; set; }
		/// <summary>
		///		Line2 of unstructured address lines describing the lower levels of an address.
		/// </summary>
		public string Line2 { get; set; }

		/// <summary>
		///		Address formatted according to the country rules
		/// </summary>
		public string FormattedAddress { get; set; }

		public override string ToString()
			=> FormattedAddress;
	}
}