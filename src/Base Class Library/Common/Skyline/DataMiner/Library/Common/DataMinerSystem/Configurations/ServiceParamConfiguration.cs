namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Net.Messages;

	/// <summary>
	/// Represents a configuration class for services that are included in services.
	/// </summary>
	public class ServiceParamConfiguration : ParamConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceParamConfiguration"/> class.
		/// </summary>
		/// <param name="parametersConfiguration">The parameter settings of the service.</param>
		/// <param name="infoParams">The ServiceInfoParams object.</param>
		/// <param name="index">The unique index of the item included in the service.</param>
		/// <exception cref="ArgumentNullException"><paramref name="infoParams"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="infoParams"/> has an alias that already exists in the service configuration.</exception>
		/// <exception cref="ArgumentException"><paramref name="infoParams"/> is not a service.</exception>
		internal ServiceParamConfiguration(ServiceParamsConfiguration parametersConfiguration, ServiceInfoParams infoParams, int index)
		{
			this.ParamsSettingsConfiguration = parametersConfiguration;
			if (infoParams == null)
			{
				throw new ArgumentNullException("infoParams");
			}

			if (!infoParams.IsService)
			{
				throw new ArgumentException("The serviceinfoparams are not for a service instance.", "infoParams");
			}

			if (parametersConfiguration.ContainsAlias(infoParams.Alias))
			{
				throw new ArgumentException("The alias already exists in the service configuration.", "infoParams");
			}

			IncludedElement = infoParams;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceParamConfiguration"/> class.
		/// </summary>
		/// <param name="parametersConfiguration">The parameter settings of the service.</param>
		/// <param name="serviceId">The service ID of the service that needs to be included.</param>
		/// <param name="index">The unique index of the item included in the service.</param>
		internal ServiceParamConfiguration(ServiceParamsConfiguration parametersConfiguration, DmsServiceId serviceId, int index)
		{
			this.ParamsSettingsConfiguration = parametersConfiguration;
			IncludedElement = new ServiceInfoParams(serviceId.AgentId, serviceId.ServiceId, true);
		}

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