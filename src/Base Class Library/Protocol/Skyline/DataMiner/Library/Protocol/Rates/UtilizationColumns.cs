namespace Skyline.DataMiner.Library.Protocol.Rates
{
	/// <summary>
	/// Class that contains the references to all the parameters that are needed to calculate the utilization.
	/// </summary>
	public class UtilizationColumns
	{
		private readonly Identifiers.ColumnIdentifier utilizationColumn;
		private readonly Identifiers.ColumnIdentifier duplexColumn;
		private readonly Identifiers.ColumnIdentifier speedColumn;

		/// <summary>
		/// Initializes a new instance of the <see cref="UtilizationColumns"/> class.
		/// </summary>
		/// <param name="utilizationColumn">Parameter information where the result of the utilization calculation will be stored.</param>
		/// <param name="speedColumn">Parameter information where the speed values can be found.</param>
		/// <param name="duplexColumn">Parameter information about the column that contains the duplex values.</param>
		public UtilizationColumns(Identifiers.ColumnIdentifier utilizationColumn, Identifiers.ColumnIdentifier speedColumn, Identifiers.ColumnIdentifier duplexColumn)
		{
			this.utilizationColumn = utilizationColumn;
			this.speedColumn = speedColumn;
			if (duplexColumn.TablePid <= 0)
			{
				throw new System.ArgumentException("The passed duplexColumn must contain a TablePid");
			}

			this.duplexColumn = duplexColumn;
		}

		/// <summary>
		/// Gets the parameter information where the result of the utilization calculation will be stored.
		/// </summary>
		public Identifiers.ColumnIdentifier UtilizationColumn
		{
			get
			{
				return utilizationColumn;
			}
		}

		/// <summary>
		/// Gets the parameter information where the duplex values can be found.
		/// </summary>
		public Identifiers.ColumnIdentifier DuplexColumn
		{
			get
			{
				return duplexColumn;
			}
		}

		/// <summary>
		/// Gets the parameter information where the speed values can be found.
		/// </summary>
		public Identifiers.ColumnIdentifier SpeedColumn
		{
			get
			{
				return speedColumn;
			}
		}
	}
}
