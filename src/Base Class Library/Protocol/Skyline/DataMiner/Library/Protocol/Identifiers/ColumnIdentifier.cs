namespace Skyline.DataMiner.Library.Protocol.Identifiers
{
	/// <summary>
	/// Class used to store the column index and ID of a parameter into one object.
	/// </summary>
	public class ColumnIdentifier
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnIdentifier"/> class.
		/// </summary>
		/// <param name="idx">Column index of the parameter.</param>
		/// <param name="pid">ID of the parameter.</param>
		public ColumnIdentifier(uint idx, int pid)
		{
			Idx = idx;
			Pid = pid;
			TablePid = -1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnIdentifier"/> class.
		/// </summary>
		/// <param name="tablePid">The parameter ID of the table that this column belongs to.</param>
		/// <param name="idx">Column index of the parameter.</param>
		/// <param name="pid">ID of the parameter.</param>
		public ColumnIdentifier(int tablePid, uint idx, int pid)
		{
			Idx = idx;
			Pid = pid;
			TablePid = tablePid;
		}

		/// <summary>
		/// Gets or sets the column index of the parameter.
		/// </summary>
		public uint Idx { get; set; }

		/// <summary>
		/// Gets or sets the ID of the parameter.
		/// </summary>
		public int Pid { get; set; }

		/// <summary>
		/// Gets or sets the parameter ID of the table that this column belongs to.
		/// </summary>
		public int TablePid { get; set; }
	}
}
