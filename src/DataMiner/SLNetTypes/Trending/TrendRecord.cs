using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Net.Trending
{
	/// <summary>
	/// Represents a trend record.
	/// </summary>
	[Serializable]
	public abstract class TrendRecord : IComparable, ICloneable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TrendRecord"/> class.
		/// </summary>
		public TrendRecord() { }

		public abstract string GetStringValue();

		/// <summary>
		/// Initializes a new instance of the <see cref="TrendRecord"/> class using the specified status and time.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="time">The time.</param>
		public TrendRecord(int status, DateTime time)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TrendRecord"/> class using the specified record.
		/// </summary>
		/// <param name="record">The trend record.</param>
		public TrendRecord(TrendRecord record)
		{
		}

		/// <summary>
		/// Gets or sets the time.
		/// </summary>
		/// <value>The time.</value>
		public DateTime Time { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public int Status { get; set; }

		public abstract string[] ToStringArray(int parameterID, string parameterIndex, string[] columnNames);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings:</returns>
		public int CompareTo(object obj)
		{
			return 0;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return null;
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
		{
			return null;
		}
	}
}
