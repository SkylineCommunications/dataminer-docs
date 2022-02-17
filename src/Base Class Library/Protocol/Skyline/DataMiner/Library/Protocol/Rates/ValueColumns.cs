namespace Skyline.DataMiner.Library.Protocol.Rates
{
	/// <summary>
	/// Class that contains the references to the current and previous counter parameters.
	/// </summary>
	public class ValueColumns
	{
		private readonly Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier currentValuesColumn;
		private readonly Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier previousValuesColumn;

		/// <summary>
		/// Initializes a new instance of the <see cref="ValueColumns"/> class.
		/// </summary>
		/// <param name="currentValuesColumn">Parameter information where the current values can be found.</param>
		/// <param name="previousValuesColumn">Parameter information where the previous values can be found..</param>
		public ValueColumns(Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier currentValuesColumn, Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier previousValuesColumn)
		{
			this.currentValuesColumn = currentValuesColumn;
			this.previousValuesColumn = previousValuesColumn;
		}

		/// <summary>
		/// Gets the parameter information where the current values can be found.
		/// </summary>
		public Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier CurrentValuesColumn
		{
			get
			{
				return currentValuesColumn;
			}
		}

		/// <summary>
		/// Gets the parameter information where the previous values can be found.
		/// </summary>
		public Skyline.DataMiner.Library.Protocol.Identifiers.ColumnIdentifier PreviousValuesColumn
		{
			get
			{
				return previousValuesColumn;
			}
		}
	}
}
