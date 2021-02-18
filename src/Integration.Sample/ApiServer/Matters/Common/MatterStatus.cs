namespace Integration.Sample.ApiServer.Matters.Common
{
	/// <summary>
	/// The current status of the matter
	/// </summary>
	public enum MatterStatus
	{
		/// <summary>
		/// The matter is still open and udner investigation
		/// </summary>
		Open,

		/// <summary>
		/// The work for the matter has finished
		/// </summary>
		Closed
	}
}