namespace Integration.Sample.ApiServer.Common.Models
{
	/// <summary>
	/// Represents a reference to a entity without the full details of the entity
	/// </summary>
	public class GenericEntityReference<TSource>
	{
		/// <summary>
		/// The unique identifier associated with an entity
		/// </summary>
		public TSource Id { get; set; }

		/// <summary>
		/// The name of the entity
		/// </summary>
		public string Name { get; set; }
	}
}