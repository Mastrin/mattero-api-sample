namespace Integration.Sample.ApiServer.Matters.Common
{
	/// <summary>
	/// The method that cost is applied
	/// </summary>
	public enum CostingMethod
	{
		/// <summary>
		/// Costs are directly tied to time worked
		/// </summary>
		Time,

		/// <summary>
		/// Costs are statically fixed irrespective of time spent
		/// </summary>
		Fixed,

		/// <summary>
		/// Costs are calculated based on a cost template
		/// </summary>
		CostTemplate
	}
}