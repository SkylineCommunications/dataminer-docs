namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Globalization;
	using System.Runtime.Serialization;
	using Net.Messages;
	using Newtonsoft.Json;

	/// <summary>
	/// The state of the service retrieved from a SLNetMessage.
	/// </summary>
	public class ServiceState : IServiceState
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceState"/> class. 
		/// This constructor is available for serialization.
		/// </summary>
		public ServiceState()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceState"/> class from the service state info event from SLNet.
		/// </summary>
		/// <param name="serviceStateInfo">The service state info event response from SLNet.</param>
		internal ServiceState(ServiceStateEventMessage serviceStateInfo)
		{
			Service = new DmsServiceId(serviceStateInfo.DataMinerID, serviceStateInfo.ElementID);
			Timeout = serviceStateInfo.Timeout;
			LatchLevel = (AlarmLevel)serviceStateInfo.LatchLevel;
			IncludedElements = ServiceElementState.GetServiceElements(serviceStateInfo);
			Host = serviceStateInfo.HostingAgentID;
			Level = (AlarmLevel)serviceStateInfo.Level;
		}

		/// <summary>
		/// Gets the service DMA/ID.
		/// Needed to identify the service when getting service state updates through subscriptions.
		/// </summary>
		public DmsServiceId Service { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the service is in timeout or not.
		/// </summary>
		public bool Timeout { get; private set; }

		/// <summary>
		/// Gets the latchlevel of the service.
		/// </summary>
		public AlarmLevel LatchLevel { get; private set; }

		/// <summary>
		/// Gets the included elements in the service.
		/// </summary>
		public IServiceElementState[] IncludedElements { get; private set; }

		/// <summary>
		/// Gets the DataMiner ID of the agent on which the service is hosted.
		/// </summary>
		public int Host { get; private set; }

		/// <summary>
		/// Gets the service alarm level.
		/// </summary>
		public AlarmLevel Level { get; private set; }
	}
}
