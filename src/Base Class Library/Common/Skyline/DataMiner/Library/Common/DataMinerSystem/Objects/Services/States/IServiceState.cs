namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// The service state interface.
	/// </summary>
	public interface IServiceState
	{
		/// <summary>
		/// Gets the alarm level of the element.
		/// </summary>
		AlarmLevel Level { get; }

		/// <summary>
		/// Gets the service that is linked to the state.
		/// </summary>
		DmsServiceId Service { get; }

		/// <summary>
		/// Gets a value indicating whether the service is in timeout.
		/// </summary>
		bool Timeout { get; }

		/// <summary>
		/// Gets the latch level of service.
		/// </summary>
		AlarmLevel LatchLevel { get; }

		/// <summary>
		/// Gets the included elements and their state.
		/// </summary>
		IServiceElementState[] IncludedElements { get; }

		/// <summary>
		/// Gets the id of the agent that hosts the service.
		/// </summary>
		int Host { get; }
	}
}
