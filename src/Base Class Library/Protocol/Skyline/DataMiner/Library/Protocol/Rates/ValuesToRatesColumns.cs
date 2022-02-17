namespace Skyline.DataMiner.Library.Protocol.Rates
{
	/// <summary>
	/// Class used to store all column indexes and IDs of parameters that are needed to calculate a rate.
	/// </summary>
	public class ValuesToRatesColumns
	{
		private readonly uint currentValuesColumnIdx;
		private readonly Identifiers.ColumnIdentifier previousValuesColumn;
		private readonly Identifiers.ColumnIdentifier rateColumn;

		/// <summary>
		/// Initializes a new instance of the <see cref="ValuesToRatesColumns"/> class.
		/// </summary>
		/// <param name="currentValuesColumn">Parameter information where the current polled value can be found.</param>
		/// <param name="previousValuesColumn">Parameter information where the previous polled value will be stored.</param>
		/// <param name="rateColumn">Parameter information where the result of the rate calculation will be stored.</param>
		public ValuesToRatesColumns(Identifiers.ColumnIdentifier currentValuesColumn, Identifiers.ColumnIdentifier previousValuesColumn, Identifiers.ColumnIdentifier rateColumn)
		{
			currentValuesColumnIdx = currentValuesColumn.Idx;
			this.previousValuesColumn = previousValuesColumn;
			this.rateColumn = rateColumn;
		}

		/// <summary>
		/// Gets the column index of the parameter that contains the current polled value.
		/// </summary>
		public uint CurrentValuesColumnIdx
		{
			get
			{
				return currentValuesColumnIdx;
			}
		}

		/// <summary>
		/// Gets the parameter information where the previous polled value will be stored.
		/// </summary>
		public Identifiers.ColumnIdentifier PreviousValuesColumn
		{
			get
			{
				return previousValuesColumn;
			}
		}

		/// <summary>
		/// Gets the parameter information where the result of the rate calculation will be stored.
		/// </summary>
		public Identifiers.ColumnIdentifier RateColumn
		{
			get
			{
				return rateColumn;
			}
		}
	}
}
