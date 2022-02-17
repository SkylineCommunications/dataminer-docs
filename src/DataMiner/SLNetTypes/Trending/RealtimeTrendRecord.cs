using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.Trending
{
	/// <summary>
	/// Represents a real-time trend record.
	/// </summary>
	[Serializable]
	public class RealtimeTrendRecord : TrendRecord
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RealtimeTrendRecord"/> class.
		/// </summary>
		public RealtimeTrendRecord() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="RealtimeTrendRecord"/> class using the specified status, time and value.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="time">The time.</param>
		/// <param name="value">The value.</param>
		public RealtimeTrendRecord(int status, DateTime time, string value) : base(status, time)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RealtimeTrendRecord"/> class using the specified record.
		/// </summary>
		/// <param name="record">The real-time trend record.</param>
		public RealtimeTrendRecord(RealtimeTrendRecord record) : base(record)
		{
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public string Value { get; set; }

		public override string[] ToStringArray(int parameterID, string parameterIndex, string[] columnNames)
		{
			return null;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return null;
		}

		public override string GetStringValue()
		{
			return null;
		}
	}
}
