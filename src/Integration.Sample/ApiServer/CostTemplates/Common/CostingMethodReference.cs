using Integration.Sample.ApiServer.Common.Models;
using Integration.Sample.ApiServer.Matters.Common;

namespace Integration.Sample.ApiServer.CostTemplates.Common
{
	/// <summary>
	/// Represents a reference to a costing method entity without the full details of the entity
	/// </summary>
	public class CostingMethodReference
	{
		/// <summary>
		/// The Costing Method associated with the entity
		/// </summary>
		public CostingMethod CostingMethod { get; set; }

		/// <summary>
		/// Represents a reference to a cost template entity without the full details of the entity
		/// </summary>
		public EntityReference CostTemplate { get; set; }
	}
}