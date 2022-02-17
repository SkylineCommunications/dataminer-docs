namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface to the result of the executed query on the table.
	/// </summary>
	internal interface IDmsTableQueryResult
	{
		/// <summary>
		/// Gets the total number of pages that are present in the table.
		/// </summary>
		int TotalPageCount { get; }

		/// <summary>
		/// Gets the current page ID that has been returned.
		/// </summary>
		int CurrentPageId { get; }

		/// <summary>
		/// Gets the next page ID to be requested. '-1' when there are no more pages to be retrieved.
		/// </summary>
		int NextPageId { get; }

		/// <summary>
		/// Gets the total number of rows that are present in the table.
		/// </summary>
		int TotalRowCount { get; }

		/// <summary>
		/// Gets the rows that are present in this table page.
		/// </summary>
		ICollection<object[]> PageRows { get; }
	}
}