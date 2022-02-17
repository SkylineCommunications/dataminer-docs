namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using Net.Messages;

	/// <summary>
	/// Represents a base class for all of the components in a DmsService object.
	/// </summary>
	public class ServiceParamSettings
	{
		private readonly ServiceInfoParams includedElement;

		private ServiceParamFilterSettings[] serviceParamFilters;

		private bool isLoaded;

		internal ServiceParamSettings(ServiceInfoParams infoParams)
		{
			includedElement = infoParams;
		}

		/// <summary>
		/// Gets the Alias of the element.
		/// </summary>
		public string Alias
		{
			get
			{
				return includedElement.Alias;
			}
		}

		/// <summary>
		/// Gets the DataMiner ID of the element.
		/// </summary>
		public int DataMinerID
		{
			get
			{
				return includedElement.DataMinerID;
			}
		}

		/// <summary>
		/// Gets the element ID of the element.
		/// </summary>
		public int ElementID
		{
			get
			{
				return includedElement.ElementID;
			}
		}

		/// <summary>
		/// Gets the group ID to which the element belongs.
		/// </summary>
		public int GroupID
		{
			get
			{
				return includedElement.GroupID;
			}
		}

		/// <summary>
		/// Gets the included capped alarm level of the element.
		/// </summary>
		public AlarmLevel IncludedCapped
		{
			get
			{
				return (AlarmLevel)Enum.Parse(typeof(AlarmLevel), includedElement.IncludedCapped, true);
			}
		}

		/// <summary>
		/// Gets the index of the element.
		/// </summary>
		public int Index
		{
			get
			{
				return includedElement.Index;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the element is excluded.
		/// </summary>
		public bool IsExcluded
		{
			get
			{
				return includedElement.IsExcluded;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the element is a service.
		/// </summary>
		public bool IsService
		{
			get
			{
				return includedElement.IsService;
			}
		}

		/// <summary>
		/// Gets the not used capped alarm level of the element.
		/// </summary>
		public AlarmLevel NotUsedCapped
		{
			get
			{
				return (AlarmLevel)Enum.Parse(typeof(AlarmLevel), includedElement.NotUsedCapped, true);
			}
		}

		/// <summary>
		/// Gets the parameter filters for the included element.
		/// </summary>
		public ServiceParamFilterSettings[] ParameterFilters
		{
			get
			{
				if (!isLoaded)
				{
					LoadOnDemand();
				}

				return serviceParamFilters;
			}
		}

		internal ServiceInfoParams IncludedElement
		{
			get
			{
				List<ServiceParamFilter> lIncludedParameters = new List<ServiceParamFilter>();
				foreach (var parameter in serviceParamFilters)
				{
					lIncludedParameters.Add(parameter.IncludedParameters);
				}

				includedElement.ParameterFilters = lIncludedParameters.ToArray();

				return includedElement;
			}
		}

		internal static ServiceParamSettings[] GetServiceParameters(ServiceInfoEventMessage serviceInfo)
		{
			List<ServiceParamSettings> lParams = new List<ServiceParamSettings>();
			foreach (ServiceInfoParams parameters in serviceInfo.ServiceParams)
			{
				lParams.Add(new ServiceParamSettings(parameters));
			}

			return lParams.ToArray();
		}

		private void LoadOnDemand()
		{
			isLoaded = true;
			serviceParamFilters = ServiceParamFilterSettings.GetParamFilters(includedElement);
		}
	}
}