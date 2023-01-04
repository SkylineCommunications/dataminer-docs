namespace Skyline.DataMiner.Library.Common.Rates
{
	using System;

	using Newtonsoft.Json;

	#region Base Classes

	/// <summary>
	/// <para>Class <see cref="RateCounter{T}"/> used by RateHelper classes in order to keep counters data.</para>
	/// This class is meant to be used as base class for more specific counter classes depending on <br/>
	/// - The range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc) <br/>
	/// - The type of timing info (<see cref="System.DateTime"/>, <see cref="System.TimeSpan"/>).
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class RateCounter<T>
	{
		private protected RateCounter() { } // Default constructor for Deserializer

		private protected RateCounter(T counter)
		{
			Counter = counter;
		}

		[JsonProperty]
		internal T Counter { get; set; }
	}

	/// <summary>
	/// <para>Class <see cref="CounterWithDateTime{T}"/> used by RateHelper classes in order to keep counters data together with <see cref="System.DateTime"/>.</para>
	/// This class is meant to be used as base class for more specific counter classes depending on the range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc).
	/// </summary>
	public class CounterWithDateTime<T> : RateCounter<T>
	{
		private protected CounterWithDateTime() { } // Default constructor for Deserializer

		private protected CounterWithDateTime(T counter, DateTime utcDateTime) : base(counter)
		{
			if (utcDateTime.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("UTC should be used.", nameof(utcDateTime));
			}

			DateTime = utcDateTime;
		}

		[JsonProperty]
		internal DateTime DateTime { get; set; }
	}

	/// <summary>
	/// <para>Class <see cref="CounterWithTimeSpan{T}"/> used by RateHelper classes in order to keep counters data together with <see cref="System.TimeSpan"/>.</para>
	/// This class is meant to be used as base class for more specific counter classes depending on the range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc).
	/// </summary>
	public class CounterWithTimeSpan<T> : RateCounter<T>
	{
		private protected CounterWithTimeSpan() { } // Default constructor for Deserializer

		private protected CounterWithTimeSpan(T counter, TimeSpan timeSpan) : base(counter)
		{
			TimeSpan = timeSpan;
		}

		[JsonProperty]
		internal TimeSpan TimeSpan { get; set; }
	}

	#endregion

	#region Real Classes

	/// <summary>
	/// Class <see cref="Counter32WithDateTime"/> used by RateHelper classes in order to keep <see cref="System.UInt32"/> counters together with their <see cref="System.DateTime"/>.
	/// </summary>
	public class Counter32WithDateTime : CounterWithDateTime<uint>
	{
		internal Counter32WithDateTime(uint counter, DateTime utcDateTime) : base(counter, utcDateTime) { }

		private Counter32WithDateTime() { } // Default constructor for Deserializer
	}

	/// <summary>
	/// Class <see cref="Counter32WithTimeSpan"/> used by RateHelper classes in order to keep <see cref="System.UInt32"/> counters together with their <see cref="System.TimeSpan"/>.
	/// </summary>
	public class Counter32WithTimeSpan : CounterWithTimeSpan<uint>
	{
		internal Counter32WithTimeSpan(uint counter, TimeSpan timeSpan) : base(counter, timeSpan) { }

		private Counter32WithTimeSpan() { } // Default constructor for Deserializer
	}

	/// <summary>
	/// Class <see cref="Counter64WithDateTime"/> used by RateHelper classes in order to keep <see cref="System.UInt64"/> counters together with their <see cref="System.DateTime"/>.
	/// </summary>
	public class Counter64WithDateTime : CounterWithDateTime<ulong>
	{
		internal Counter64WithDateTime(ulong counter, DateTime dateTime) : base(counter, dateTime) { }

		private Counter64WithDateTime() { } // Default constructor for Deserializer
	}

	/// <summary>
	/// Class <see cref="Counter64WithTimeSpan"/> used by RateHelper classes in order to keep <see cref="System.UInt64"/> counters together with their <see cref="System.TimeSpan"/>.
	/// </summary>
	public class Counter64WithTimeSpan : CounterWithTimeSpan<ulong>
	{
		internal Counter64WithTimeSpan(ulong counter, TimeSpan timeSpan) : base(counter, timeSpan) { }

		private Counter64WithTimeSpan() { } // Default constructor for Deserializer
	}

	#endregion
}
