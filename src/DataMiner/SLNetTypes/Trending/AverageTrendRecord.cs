using System;
using Skyline.DataMiner.Net.Messages;
using System.Globalization;

namespace Skyline.DataMiner.Net.Trending
{
	/// <summary>
	/// Represents an average trend record.
	/// </summary>
	[Serializable]
	public class AverageTrendRecord : TrendRecord
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AverageTrendRecord"/> class representing an average trend record.
		/// </summary>
		public AverageTrendRecord() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="AverageTrendRecord"/> class representing an average trend record.
		/// </summary>
		/// <param name="status">The status.</param>
		/// <param name="time">The timestamp of the average trend record.</param>
		/// <param name="avg">The average value.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		public AverageTrendRecord(int status, DateTime time, double avg, double min, double max) : base(status, time)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AverageTrendRecord"/> class representing an average trend record.
		/// </summary>
		public AverageTrendRecord(AverageTrendRecord record) : base(record)
		{
		}

		/// <summary>
		/// Gets or sets the average value.
		/// </summary>
		/// <value>The average value.</value>
		public double AverageValue { get; set; }

		/// <summary>
		/// Gets or sets the minimum value.
		/// </summary>
		/// <value>The minimum value.</value>
		public double MinimumValue { get; set; }

		/// <summary>
		/// Gets or sets the maximum value.
		/// </summary>
		/// <value>The maximum value.</value>
		public double MaximumValue { get; set; }

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
