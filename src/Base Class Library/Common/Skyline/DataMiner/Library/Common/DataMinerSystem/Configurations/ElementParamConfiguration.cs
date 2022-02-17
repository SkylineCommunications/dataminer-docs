namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Net.Messages;

	/// <summary>
	/// Represents a configuration class for elements that are included in services.
	/// </summary>
	public class ElementParamConfiguration : ParamConfiguration
	{
		private List<ElementParamFilterConfiguration> parameterFilters;

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementParamConfiguration"/> class.
		/// </summary>
		/// <param name="paramsSettingsConfiguration">The parameter settings of the service.</param>
		/// <param name="infoParams">The ServiceInfoParams object.</param>
		/// <param name="index">The unique index of the item included in the service.</param>
		/// <exception cref="ArgumentNullException"><paramref name="infoParams"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="infoParams"/> has an alias that already exists in the service configuration.</exception>
		/// <exception cref="ArgumentException"><paramref name="infoParams"/> is a service.</exception>
		internal ElementParamConfiguration(ServiceParamsConfiguration paramsSettingsConfiguration, ServiceInfoParams infoParams, int index)
		{
			this.ParamsSettingsConfiguration = paramsSettingsConfiguration;
			if (infoParams == null)
			{
				throw new ArgumentNullException("infoParams");
			}

			if (infoParams.IsService)
			{
				throw new ArgumentException("The serviceinfoparams are for a service instance.", "infoParams");
			}

			if (paramsSettingsConfiguration.ContainsAlias(infoParams.Alias))
			{
				throw new ArgumentException("The alias already exists in the service configuration.", "infoParams");
			}

			IncludedElement = infoParams;
			parameterFilters = ElementParamFilterConfiguration.GetParameterFilters(infoParams);
			Index = index;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementParamConfiguration"/> class.
		/// </summary>
		/// <param name="paramsSettingsConfiguration">The parameter settings of the service.</param>
		/// <param name="elementId">The DataMiner/element ID of the element to include.</param>
		/// <param name="parameters">The parameters that need to be included in the service.</param>
		/// <param name="index">The unique index of the item included in the service.</param>
		internal ElementParamConfiguration(ServiceParamsConfiguration paramsSettingsConfiguration, DmsElementId elementId, List<ElementParamFilterConfiguration> parameters, int index)
		{
			this.ParamsSettingsConfiguration = paramsSettingsConfiguration;
			IncludedElement = new ServiceInfoParams(elementId.AgentId, elementId.ElementId, false);
			parameterFilters = parameters;
			Index = index;
		}

		/// <summary>
		/// Gets or sets the DataMiner/element ID of the included element.
		/// </summary>
		public DmsElementId ElementId
		{
			get
			{
				return new DmsElementId(IncludedElement.DataMinerID, IncludedElement.ElementID);
			}

			set
			{
				IncludedElement.DataMinerID = value.AgentId;
				IncludedElement.ElementID = value.ElementId;
			}
		}

		/// <summary>
		/// Gets the parameters included in the service for this element.
		/// </summary>
		/// <returns>The </returns>
		public List<ElementParamFilterConfiguration> ParameterFilters
		{
			get
			{
				return parameterFilters;
			}
		}

		/// <summary>
		/// Sets the parameters included in the service for this element.
		/// </summary>
		/// <param name="parameters">The parameters that need to be included in the service.</param>
		public void SetParameterFilters(List<ElementParamFilterConfiguration> parameters)
		{
			parameterFilters = parameters;
		}

		/// <summary>
		/// Adds a parameter for the element to the service.
		/// </summary>
		/// <param name="paramFilter">The parameter filter.</param>
		public void AddParameter(ElementParamFilterConfiguration paramFilter)
		{
			ParameterFilters.Add(paramFilter);
		}
		
		/// <summary>
		/// Gets the serviceInfoParams object used by SLNet.
		/// </summary>
		/// <returns>The serviceInfoParams object.</returns>
		internal override ServiceInfoParams GetServiceInfoParams()
		{
			IncludedElement.ParameterFilters = ParameterFilters.Select(pf => pf.ServiceParamFilter).ToArray();
			return IncludedElement;
		}
	}
}