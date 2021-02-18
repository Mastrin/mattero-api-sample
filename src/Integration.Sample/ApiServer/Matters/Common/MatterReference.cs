using Integration.Sample.ApiServer.Common.Models;

namespace Integration.Sample.ApiServer.Matters.Common
{
	/// <summary>
	/// Represents a reference to a matter entity without the full details of the entity
	/// </summary>
	public class MatterReference : EntityReference
	{
		/// <summary>
		/// The number associate with the matter
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// The title or name of the matter
		/// </summary>
		public string Title { get; set; }
	}
}