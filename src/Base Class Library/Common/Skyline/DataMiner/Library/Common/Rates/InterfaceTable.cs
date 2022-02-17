namespace Skyline.DataMiner.Library.Common.Rates
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Class that contains the data of all the interfaces. This can be seen as an object that contains all the data of a table.
	/// </summary>
	public class InterfaceTable
	{
		private readonly ICollection<InterfaceRow> interfaceRows;
		private readonly TimeSpan? delta;
		private readonly int bufferedDeltaValue;
		private readonly int minDelta;

		/// <summary>
		/// Initializes a new instance of the <see cref="InterfaceTable"/> class.
		/// </summary>
		/// <param name="interfaceRows">Collection that contains the data of all interfaces.</param>
		/// <param name="delta">Time span between this and previous executed poll group.</param>
		/// <param name="bufferedDeltaValue">Value of how long ago a group got valid polled results before the previous executed poll group.</param>
		/// <param name="minDelta">The minimum value <paramref name="delta" /> must have (in ms).</param>
		public InterfaceTable(ICollection<InterfaceRow> interfaceRows, TimeSpan? delta, int bufferedDeltaValue, int minDelta)
		{
			this.interfaceRows = interfaceRows;
			this.delta = delta;
			this.minDelta = minDelta;
			this.bufferedDeltaValue = bufferedDeltaValue;
		}

		/// <summary>
		/// Gets the collection containing all the interface rows.
		/// </summary>
		/// <value>The collection containing all the interface rows.</value>
		public ICollection<InterfaceRow> InterfaceRows
		{
			get
			{
				return interfaceRows;
			}
		}

		/// <summary>
		/// Gets the time span between this and previous executed poll group.
		/// </summary>
		/// <value>The time span between this and previous executed poll group.</value>
		public TimeSpan? Delta
		{
			get
			{
				return delta;
			}
		}

		/// <summary>
		/// Gets the value of how long ago a group got valid polled results before the previous executed poll group.
		/// </summary>
		/// <value>The value of how long ago a group got valid polled results before the previous executed poll group.</value>
		public int BufferedDeltaValue
		{
			get
			{
				return bufferedDeltaValue;
			}
		}

		/// <summary>
		/// Gets the minimum value the delta must have (in ms).
		/// </summary>
		/// <value>The minimum value the delta must have (in ms).</value>
		public int MinDelta
		{
			get
			{
				return minDelta;
			}
		}
	}
}
