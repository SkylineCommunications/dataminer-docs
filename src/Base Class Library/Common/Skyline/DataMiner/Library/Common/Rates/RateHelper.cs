namespace Skyline.DataMiner.Library.Common.Rates
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Newtonsoft.Json;

	#region Base Classes

	/// <summary>
	/// <para>Class <see cref="RateHelper{T, U}"/> helps calculating rates of all sorts (bit rates, counter rates, etc) based on counters.</para>
	/// This class is meant to be used as base class for more specific RateHelpers depending on<br/>
	/// - The range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc) <br/>
	/// - The type of timing info (<see cref="System.DateTime"/>, <see cref="System.TimeSpan"/>).
	/// </summary>
	[Serializable]
	public class RateHelper<T, U> where U : RateCounter<T>
	{
		[JsonProperty]
		private protected readonly TimeSpan minDelta;

		[JsonProperty]
		private protected readonly TimeSpan maxDelta;

		[JsonProperty]
		private protected readonly List<U> counters = new List<U>();

		[JsonConstructor]
		private protected RateHelper(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase)
		{
			this.minDelta = minDelta;
			this.maxDelta = maxDelta;
			this.RateBase = rateBase;
		}

		/// <summary>
		/// Determines whether the rate should be calculated per second, minute, hour, or day.
		/// </summary>
		[JsonProperty]
		public RateBase RateBase { get; set; }

		/// <summary>
		/// Resets the currently buffered data of this <see cref="RateHelper{T, U}"/> instance.
		/// </summary>
		public void Reset()
		{
			counters.Clear();
		}

		/// <summary>
		/// Serializes the currently buffered data of this <see cref="RateHelper{T, U}"/> instance.
		/// </summary>
		/// <returns>A JSON string containing the serialized data of this <see cref="RateHelper{T, U}"/> instance.</returns>
		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);
		}

		internal static void ValidateMinAndMaxDeltas(TimeSpan minDelta, TimeSpan maxDelta)
		{
			if (minDelta < TimeSpan.Zero)
			{
				throw new ArgumentException("minDelta is a negative TimeSpan.", nameof(minDelta));
			}

			if (maxDelta < TimeSpan.Zero)
			{
				throw new ArgumentException("maxDelta is a negative TimeSpan.", nameof(maxDelta));
			}

			if (maxDelta <= minDelta)
			{
				throw new ArgumentException("minDelta is bigger than maxDelta.");
			}
		}

		private protected double Calculate(U newRateCounter, int oldCounterPos, TimeSpan rateTimeSpan, double faultyReturn)
		{
			// Calculate
			double rate;
			if (oldCounterPos > -1)
			{
				rate = CalculateRate(newRateCounter.Counter, counters[oldCounterPos].Counter, rateTimeSpan);
				counters.RemoveRange(0, oldCounterPos);
			}
			else
			{
				rate = faultyReturn;
			}

			// Add new counter
			counters.Add(newRateCounter);

			return rate;
		}

		private double CalculateRate(dynamic newCounter, dynamic oldCounter, TimeSpan timeSpan)
		{
			return 0.0;
		}
	}

	/// <summary>
	/// <para>Class <see cref="RateOnDateTime{T, U}"/> helps calculate rates of all sorts (bit rates, counter rates, etc) based on counters and DateTimes.</para>
	/// This class is meant to be used as base class for more specific RateHelpers depending on the range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc).
	/// </summary>
	[Serializable]
	public class RateOnDateTime<T,U> : RateHelper<T, U> where U : CounterWithDateTime<T>
	{
		[JsonConstructor]
		private protected RateOnDateTime(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		private protected double Calculate(U newRateCounter, double faultyReturn)
		{
			// Sanity Checks
			if (counters.Any() && (newRateCounter.DateTime <= counters[counters.Count - 1].DateTime || newRateCounter.DateTime - counters[counters.Count - 1].DateTime > maxDelta))
			{
				Reset();
			}

			// Find previous counter to be used
			int oldCounterPos = -1;
			TimeSpan rateTimeSpan = default;
			for (int i = counters.Count - 1; i > -1; i--)
			{
				rateTimeSpan = newRateCounter.DateTime - counters[i].DateTime;
				if (rateTimeSpan >= minDelta)
				{
					oldCounterPos = i;
					break;
				}
			}

			return Calculate(newRateCounter, oldCounterPos, rateTimeSpan, faultyReturn);
		}
	}

	/// <summary>
	/// <para>Class <see cref="RateOnTimeSpan{T, U}"/> helps calculate rates of all sorts (bit rates, counter rates, etc) based on counters and TimeSpans.</para>
	/// This class is meant to be used as base class for more specific RateHelpers depending on the range of counters (<see cref="System.UInt32"/>, <see cref="System.UInt64"/>, etc).
	/// </summary>
	[Serializable]
	public class RateOnTimeSpan<T, U> : RateHelper<T, U> where U : CounterWithTimeSpan<T>
	{
		[JsonConstructor]
		private protected RateOnTimeSpan(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		internal double Calculate(U newRateCounter, double faultyReturn)
		{
			// Sanity Checks
			if ((counters.Any() && newRateCounter.TimeSpan > maxDelta) || newRateCounter.TimeSpan < TimeSpan.Zero)
			{
				Reset();
			}

			// Find previous counter to be used
			int oldCounterPos = -1;
			TimeSpan rateTimeSpan = newRateCounter.TimeSpan;
			for (int i = counters.Count - 1; i > -1; i--)
			{
				if (rateTimeSpan >= minDelta)
				{
					oldCounterPos = i;
					break;
				}

				rateTimeSpan += counters[i].TimeSpan;
			}

			return Calculate(newRateCounter, oldCounterPos, rateTimeSpan, faultyReturn);
		}
	}

	#endregion

	#region Real Classes

	/// <summary>
	/// Allows calculating rates of all sorts (bit rates, counter rates, etc) based on <see cref="System.UInt32"/> counters and <see cref="System.DateTime"/> values.
	/// </summary>
	[Serializable]
	public class Rate32OnDateTime : RateOnDateTime<uint, Counter32WithDateTime>
	{
		[JsonConstructor]
		private Rate32OnDateTime(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		/// <summary>
		/// Deserializes a JSON <see cref="System.String"/> to a <see cref="Rate32OnDateTime"/> instance.
		/// </summary>
		/// <param name="rateHelperSerialized">Serialized <see cref="Rate32OnDateTime"/> instance.</param>
		/// <param name="minDelta">Minimum <see cref="System.TimeSpan"/> necessary between 2 counters when calculating a rate.<br/>
		/// Counters will be buffered until this minimum delta is met.</param>
		/// <param name="maxDelta">Maximum <see cref="System.TimeSpan"/> allowed between 2 counters when calculating a rate.</param>
		/// <param name="rateBase">Choose whether the rate should be calculated per second, minute, hour, or day.</param>
		/// <exception xref="Newtonsoft.Json.JsonReaderException"><paramref name="rateHelperSerialized"/> is an invalid string representation of a <see cref="Rate32OnDateTime"/> instance.</exception>
		/// <returns>If the <paramref name="rateHelperSerialized"/> is valid, a new instance of the <see cref="Rate32OnDateTime"/> class with all data found in <paramref name="rateHelperSerialized"/>.<br/>
		/// Otherwise, throws a <see xref="Newtonsoft.Json.JsonReaderException"/>.</returns>
		public static Rate32OnDateTime FromJsonString(string rateHelperSerialized, TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase = RateBase.Second)
		{
			ValidateMinAndMaxDeltas(minDelta, maxDelta);

			return !String.IsNullOrWhiteSpace(rateHelperSerialized) ?
				JsonConvert.DeserializeObject<Rate32OnDateTime>(rateHelperSerialized) :
				new Rate32OnDateTime(minDelta, maxDelta, rateBase);
		}

		/// <summary>
		/// Calculates the rate using provided <paramref name="newCounter"/> against previous counters buffered in this <see cref="Rate32OnDateTime"/> instance.
		/// </summary>
		/// <param name="newCounter">The latest known counter value.</param>
		/// <param name="utcDateTime">The <see cref="System.DateTime"/> at which <paramref name="newCounter"/> value was taken.</param>
		/// <param name="faultyReturn">The value to be returned in case a correct rate could not be calculated.</param>
		/// <exception cref="ArgumentException"><paramref name="utcDateTime"/> is not of kind <see cref="DateTimeKind.Utc"/></exception>
		/// <returns>The calculated rate or the value specified in <paramref name="faultyReturn"/> in case the rate cannot be calculated.</returns>
		public double Calculate(uint newCounter, DateTime utcDateTime, double faultyReturn = -1)
		{
			var rateCounter = new Counter32WithDateTime(newCounter, utcDateTime);
			return Calculate(rateCounter, faultyReturn);
		}
	}

	/// <summary>
	/// Allows calculating rates of all sorts (bit rates, counter rates, etc) based on <see cref="System.UInt32"/> counters and <see cref="System.TimeSpan"/> values.
	/// </summary>
	[Serializable]
	public class Rate32OnTimeSpan : RateOnTimeSpan<uint, Counter32WithTimeSpan>
	{
		[JsonConstructor]
		internal Rate32OnTimeSpan(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		/// <summary>
		/// Deserializes a JSON <see cref="System.String"/> to a <see cref="Rate32OnTimeSpan"/> instance.
		/// </summary>
		/// <param name="rateHelperSerialized">Serialized <see cref="Rate32OnTimeSpan"/> instance.</param>
		/// <param name="minDelta">Minimum <see cref="System.TimeSpan"/> necessary between 2 counters when calculating a rate.<br/>
		/// Counters will be buffered until this minimum delta is met.</param>
		/// <param name="maxDelta">Maximum <see cref="System.TimeSpan"/> allowed between 2 counters when calculating a rate.</param>
		/// <param name="rateBase">Choose whether the rate should be calculated per second, minute, hour, or day.</param>
		/// <exception xref="Newtonsoft.Json.JsonReaderException"><paramref name="rateHelperSerialized"/> is an invalid string representation of a <see cref="Rate32OnTimeSpan"/> instance.</exception>
		/// <returns>If the <paramref name="rateHelperSerialized"/> is valid, a new instance of the <see cref="Rate32OnTimeSpan"/> class with all data found in <paramref name="rateHelperSerialized"/>.<br/>
		/// Otherwise, throws a <see xref="Newtonsoft.Json.JsonReaderException"/>.</returns>
		public static Rate32OnTimeSpan FromJsonString(string rateHelperSerialized, TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase = RateBase.Second)
		{
			ValidateMinAndMaxDeltas(minDelta, maxDelta);

			return !String.IsNullOrWhiteSpace(rateHelperSerialized) ?
				JsonConvert.DeserializeObject<Rate32OnTimeSpan>(rateHelperSerialized) :
				new Rate32OnTimeSpan(minDelta, maxDelta, rateBase);
		}

		/// <summary>
		/// Calculates the rate using provided <paramref name="newCounter"/> against previous counters buffered in this <see cref="Rate32OnTimeSpan"/> instance.
		/// </summary>
		/// <param name="newCounter">The latest known counter value.</param>
		/// <param name="delta">The elapse <see cref="System.TimeSpan"/> between this new counter and previous one.</param>
		/// <param name="faultyReturn">The value to be returned in case a correct rate could not be calculated.</param>
		/// <returns>The calculated rate or the value specified in <paramref name="faultyReturn"/> in case the rate cannot be calculated.</returns>
		public double Calculate(uint newCounter, TimeSpan delta, double faultyReturn = -1)
		{
			var rateCounter = new Counter32WithTimeSpan(newCounter, delta);
			return Calculate(rateCounter, faultyReturn);
		}
	}

	/// <summary>
	/// Allows calculating rates of all sorts (bit rates, counter rates, etc) based on <see cref="System.UInt64"/> counters and <see cref="System.DateTime"/> values.
	/// </summary>
	[Serializable]
	public class Rate64OnDateTime : RateOnDateTime<ulong, Counter64WithDateTime>
	{
		[JsonConstructor]
		private Rate64OnDateTime(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		/// <summary>
		/// Deserializes a JSON <see cref="System.String"/> to a <see cref="Rate64OnDateTime"/> instance.
		/// </summary>
		/// <param name="rateHelperSerialized">Serialized <see cref="Rate64OnDateTime"/> instance.</param>
		/// <param name="minDelta">Minimum <see cref="System.TimeSpan"/> necessary between 2 counters when calculating a rate.<br/>
		/// Counters will be buffered until this minimum delta is met.</param>
		/// <param name="maxDelta">Maximum <see cref="System.TimeSpan"/> allowed between 2 counters when calculating a rate.</param>
		/// <param name="rateBase">Choose whether the rate should be calculated per second, minute, hour, or day.</param>
		/// <exception xref="Newtonsoft.Json.JsonReaderException"><paramref name="rateHelperSerialized"/> is an invalid string representation of a <see cref="Rate64OnDateTime"/> instance.</exception>
		/// <returns>If the <paramref name="rateHelperSerialized"/> is valid, a new instance of the <see cref="Rate64OnDateTime"/> class with all data found in <paramref name="rateHelperSerialized"/>.<br/>
		/// Otherwise, throws a <see xref="Newtonsoft.Json.JsonReaderException"/>.</returns>
		public static Rate64OnDateTime FromJsonString(string rateHelperSerialized, TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase = RateBase.Second)
		{
			ValidateMinAndMaxDeltas(minDelta, maxDelta);

			return !String.IsNullOrWhiteSpace(rateHelperSerialized) ?
				JsonConvert.DeserializeObject<Rate64OnDateTime>(rateHelperSerialized) :
				new Rate64OnDateTime(minDelta, maxDelta, rateBase);
		}

		/// <summary>
		/// Calculates the rate using provided <paramref name="newCounter"/> against previous counters buffered in this <see cref="Rate64OnDateTime"/> instance.
		/// </summary>
		/// <param name="newCounter">The latest known counter value.</param>
		/// <param name="utcDateTime">The <see cref="System.DateTime"/> at which <paramref name="newCounter"/> value was taken.<br/>
		/// Note that the use of UTC Time is required.</param>
		/// <param name="faultyReturn">The value to be returned in case a correct rate could not be calculated.</param>
		/// <exception cref="ArgumentException"><paramref name="utcDateTime"/> is not of kind <see cref="DateTimeKind.Utc"/></exception>
		/// <returns>The calculated rate or the value specified in <paramref name="faultyReturn"/> in case the rate cannot be calculated.</returns>
		public double Calculate(ulong newCounter, DateTime utcDateTime, double faultyReturn = -1)
		{
			var rateCounter = new Counter64WithDateTime(newCounter, utcDateTime);
			return Calculate(rateCounter, faultyReturn);
		}
	}

	/// <summary>
	/// Allows calculating rates of all sorts (bit rates, counter rates, etc) based on <see cref="System.UInt64"/> counters and <see cref="System.TimeSpan"/> values.
	/// </summary>
	[Serializable]
	public class Rate64OnTimeSpan : RateOnTimeSpan<ulong, Counter64WithTimeSpan>
	{
		[JsonConstructor]
		internal Rate64OnTimeSpan(TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase) : base(minDelta, maxDelta, rateBase) { }

		/// <summary>
		/// Deserializes a JSON <see cref="System.String"/> to a <see cref="Rate64OnTimeSpan"/> instance.
		/// </summary>
		/// <param name="rateHelperSerialized">Serialized <see cref="Rate64OnTimeSpan"/> instance.</param>
		/// <param name="minDelta">Minimum <see cref="System.TimeSpan"/> necessary between 2 counters when calculating a rate.<br/>
		/// Counters will be buffered until this minimum delta is met.</param>
		/// <param name="maxDelta">Maximum <see cref="System.TimeSpan"/> allowed between 2 counters when calculating a rate.</param>
		/// <param name="rateBase">Choose whether the rate should be calculated per second, minute, hour, or day.</param>
		/// <exception xref="Newtonsoft.Json.JsonReaderException"><paramref name="rateHelperSerialized"/> is an invalid string representation of a <see cref="Rate64OnTimeSpan"/> instance.</exception>
		/// <returns>If the <paramref name="rateHelperSerialized"/> is valid, a new instance of the <see cref="Rate64OnTimeSpan"/> class with all data found in <paramref name="rateHelperSerialized"/>.<br/>
		/// Otherwise, throws a <see xref="Newtonsoft.Json.JsonReaderException"/>.</returns>
		public static Rate64OnTimeSpan FromJsonString(string rateHelperSerialized, TimeSpan minDelta, TimeSpan maxDelta, RateBase rateBase = RateBase.Second)
		{
			ValidateMinAndMaxDeltas(minDelta, maxDelta);

			return !String.IsNullOrWhiteSpace(rateHelperSerialized) ?
				JsonConvert.DeserializeObject<Rate64OnTimeSpan>(rateHelperSerialized) :
				new Rate64OnTimeSpan(minDelta, maxDelta, rateBase);
		}

		/// <summary>
		/// Calculates the rate using provided <paramref name="newCounter"/> against previous counters buffered in this <see cref="Rate64OnTimeSpan"/> instance.
		/// </summary>
		/// <param name="newCounter">The latest known counter value.</param>
		/// <param name="delta">The elapse <see cref="System.TimeSpan"/> between this new counter and previous one.</param>
		/// <param name="faultyReturn">The value to be returned in case a correct rate could not be calculated.</param>
		/// <returns>The calculated rate or the value specified in <paramref name="faultyReturn"/> in case the rate cannot be calculated.</returns>
		public double Calculate(ulong newCounter, TimeSpan delta, double faultyReturn = -1)
		{
			var rateCounter = new Counter64WithTimeSpan(newCounter, delta);
			return Calculate(rateCounter, faultyReturn);
		}
	}

	#endregion
}
