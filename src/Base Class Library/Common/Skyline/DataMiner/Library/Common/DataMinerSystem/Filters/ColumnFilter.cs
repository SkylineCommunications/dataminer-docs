namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Filter to be applied on the column when querying a table.
	/// </summary>
	public class ColumnFilter
	{
		/// <summary>
		/// Gets or sets the ID of the column parameter that will be used in the filter.
		/// </summary>
		public int Pid { get; set; }

		/// <summary>
		/// Gets or sets the value that will be used to compare against.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets how the comparison operator.
		/// </summary>
		public ComparisonOperator ComparisonOperator { get; set; }
	}
}
