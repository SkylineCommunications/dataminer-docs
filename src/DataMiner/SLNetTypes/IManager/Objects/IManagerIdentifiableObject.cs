using Skyline.DataMiner.Net.Time;
using System;

namespace Skyline.DataMiner.Net.IManager.Objects
{
	public interface IManagerIdentifiableObject<T> : IManagerObject where T : IEquatable<T>
	{
		T ID { get; }
	}

	public interface ITimeRangeObject<T> : IManagerIdentifiableObject<T> where T : IEquatable<T>
	{
		DateTime StartTimeUTC { get; }
		DateTime EndTimeUTC { get; }

		TimeRangeUtc TimeRange { get; }
	}
}