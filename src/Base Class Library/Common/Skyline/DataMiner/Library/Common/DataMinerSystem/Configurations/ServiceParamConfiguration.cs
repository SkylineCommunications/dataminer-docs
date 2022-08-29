namespace Skyline.DataMiner.Library.Common
{
	using Net.Messages;

	/// <summary>
	/// Represents a configuration class for services that are included in services.
	/// </summary>
	public class ServiceParamConfiguration : ParamConfiguration
	{
		/// <summary>
		/// Gets or sets the DataMiner/service ID of the included service.
		/// </summary>
		public DmsServiceId ServiceId
		{
			get
			{
				return new DmsServiceId(IncludedElement.DataMinerID, IncludedElement.ElementID);
			}

			set
			{
				IncludedElement.DataMinerID = value.AgentId;
				IncludedElement.ElementID = value.ServiceId;
			}
		}

		/// <summary>
		/// Gets the Service info params object for SLNet.
		/// </summary>
		/// <returns>The service info params object for SLNet.</returns>
		internal override ServiceInfoParams GetServiceInfoParams()
		{
			return IncludedElement;
		}
	}
}