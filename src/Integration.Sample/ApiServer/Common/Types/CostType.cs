namespace Integration.Sample.ApiServer.CostRecords.Common.Types
{
	/// <summary>
	/// The type of a cost
	/// </summary>
	public enum CostType
	{
		/// <summary>
		/// Cost directly linked to time worked
		/// </summary>
		Time,

		/// <summary>
		/// Cost linked to a financial transaction
		/// </summary>
		Expense
	}
}