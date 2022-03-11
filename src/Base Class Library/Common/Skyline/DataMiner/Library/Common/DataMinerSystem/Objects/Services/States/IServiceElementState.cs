namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// The interface for a state of an element included in a service.
	/// </summary>
	public interface IServiceElementState
	{
		/// <summary>
		/// Gets the actual level of the included element (aggregated over the included parameters).
		/// </summary>
		AlarmLevel ActualLevel { get; }

		/// <summary>
		/// Gets the element that is included.
		/// </summary>
		DmsElementId Element { get; }

		/// <summary>
		/// Gets a value indicating whether the included element is in timeout.
		/// </summary>
		bool Timeout { get; }

		/// <summary>
		/// Gets the latch level of the included element (aggregated over the included parameters).
		/// </summary>
		AlarmLevel LatchLevel { get; }

		/// <summary>
		/// Gets the capped latch level of the included element (aggregated over the included parameters).
		/// </summary>
		AlarmLevel CappedLatchLevel { get; }

		/// <summary>
		/// Gets the capped level of the included element (aggregated over the included parameters).
		/// </summary>
		AlarmLevel CappedLevel { get; }

		/// <summary>
		/// Gets a value indicating whether the element is included.
		/// </summary>
		bool IsIncluded { get; }

		/// <summary>
		/// Gets the index of the element in the service.
		/// </summary>
		int Index { get; }

		/// <summary>
		/// Gets the alias that is given to the element in the service.
		/// </summary>
		string Alias { get; }
	}
}