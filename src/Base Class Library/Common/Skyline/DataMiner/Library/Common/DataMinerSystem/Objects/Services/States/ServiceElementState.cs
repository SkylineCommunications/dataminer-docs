namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;
	using Net.Messages;

	/// <summary>
	/// The state of the element (only included parameters) that is part of the service.
	/// </summary>
	public class ServiceElementState : IServiceElementState
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceElementState"/> class. 
		/// This constructor is available for serialization.
		/// </summary>
		public ServiceElementState()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceElementState"/> class. 
		/// </summary>
		/// <param name="serviceElement">The service element state returned by SLNet.</param>
		internal ServiceElementState(Net.Messages.ServiceElementState serviceElement)
		{
			ActualLevel = (AlarmLevel)serviceElement.ActualLevel;
			Element = new DmsElementId(serviceElement.DataMinerID, serviceElement.ElementID);
			Timeout = serviceElement.IsTimeout;
			LatchLevel = (AlarmLevel)serviceElement.LatchLevel;
			CappedLatchLevel = (AlarmLevel)serviceElement.CappedLatchLevel;
			CappedLevel = (AlarmLevel)serviceElement.CappedLevel;
			IsIncluded = serviceElement.IsIncluded;
			Index = serviceElement.Index;
			Alias = serviceElement.Alias;
		}

		/// <summary>
		/// Gets the actual level of the included element (aggregated over the included parameters).
		/// </summary>
		public AlarmLevel ActualLevel { get; private set; }

		/// <summary>
		/// Gets the element that is included.
		/// </summary>
		public DmsElementId Element { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the included element is in timeout.
		/// </summary>
		public bool Timeout { get; private set; }

		/// <summary>
		/// Gets the latch level of the included element (aggregated over the included parameters).
		/// </summary>
		public AlarmLevel LatchLevel { get; private set; }

		/// <summary>
		/// Gets the capped latch level of the included element (aggregated over the included parameters).
		/// </summary>
		public AlarmLevel CappedLatchLevel { get; private set; }

		/// <summary>
		/// Gets the capped level of the included element (aggregated over the included parameters).
		/// </summary>
		public AlarmLevel CappedLevel { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the element is included.
		/// </summary>
		public bool IsIncluded { get; private set; }

		/// <summary>
		/// Gets the index of the element in the service.
		/// </summary>
		public int Index { get; private set; }

		/// <summary>
		/// Gets the alias that is given to the element in the service.
		/// </summary>
		public string Alias { get; private set; }

		/// <summary>
		/// Returns the service element states based on the Service state event message from SLNet.
		/// </summary>
		/// <param name="serviceStateInfo">The service state event message from SLNet.</param>
		/// <returns>The service element states.</returns>
		internal static IServiceElementState[] GetServiceElements(ServiceStateEventMessage serviceStateInfo)
		{
			List<IServiceElementState> lServiceElements = new List<IServiceElementState>(serviceStateInfo.ElementStates.Length);
			foreach (var serviceElement in serviceStateInfo.ElementStates)
			{
				lServiceElements.Add(new ServiceElementState(serviceElement));
			}

			return lServiceElements.ToArray();
		}
	}
}