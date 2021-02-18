using Integration.Sample.ApiServer.Common.Models;

namespace Integration.Sample.ApiServer.PracticeAreas.Common
{
	/// <summary>
	/// Represents a reference to a practice area entity without the full details of the entity
	/// </summary>
	public class PracticeAreaReference : EntityReference
	{
		/// <summary>
		///		The stage ID
		/// </summary>
		public GenericEntityReference<int> Stage { get; set; }
	}
}