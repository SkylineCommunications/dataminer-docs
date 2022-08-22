namespace Skyline.DataMiner.Library.Common
{
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