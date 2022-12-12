namespace Skyline.DataMiner.Library.Common.Subscription.Waiters
{
	using Skyline.DataMiner.Library.Common.Selectors.Data;

	/// <summary>
	/// Represents all expected changes.
	/// </summary>
	public class ExpectedChanges
	{
		/// <summary>
		/// Gets or sets the expected cell changes.
		/// </summary>
		/// <value>The expected cell changes.</value>
		public CellValue[] ExpectedCellChanges { get; set; }

		/// <summary>
		/// Gets or sets the expected parameter changes.
		/// </summary>
		/// <value>The expected parameter changes.</value>
		public ParamValue[] ExpectedParamChanges { get; set; }
	}
}