namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;
	using Net.Messages;

	/// <summary>
	/// Represents a base class for all of the components in a DmsService object.
	/// </summary>
	public class ServiceParamFilterSettings
	{
		private readonly ServiceParamFilter serviceParamFilter;

		internal ServiceParamFilterSettings(ServiceParamFilter serviceParamFilter)
		{
			this.serviceParamFilter = serviceParamFilter;
		}

		/// <summary>
		/// Gets the filter for the parameter.
		/// </summary>
		public string Filter
		{
			get
			{
				return serviceParamFilter.Filter;
			}
		}

		/// <summary>
		/// Gets the filter value for the parameter.
		/// </summary>
		public string FilterValue
		{
			get
			{
				return serviceParamFilter.FilterValue;
			}
		}

		/// <summary>
		/// Gets the filter type for the parameter.
		/// </summary>
		public FilterType FilterType
		{
			get
			{
				return (FilterType)serviceParamFilter.FilterType;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the parameter is included.
		/// </summary>
		public bool IsIncluded
		{
			get
			{
				return serviceParamFilter.IsIncluded;
			}
		}

		/// <summary>
		/// Gets the matrix port for the parameter.
		/// </summary>
		public int MatrixPort
		{
			get
			{
				return serviceParamFilter.MatrixPort;
			}
		}

		/// <summary>
		/// Gets the ID of the parameter.
		/// </summary>
		public int ParameterID
		{
			get
			{
				return serviceParamFilter.ParameterID;
			}
		}

		internal ServiceParamFilter IncludedParameters
		{
			get
			{
				return serviceParamFilter;
			}
		}

		internal static ServiceParamFilterSettings[] GetParamFilters(ServiceInfoParams serviceParams)
		{
			List<ServiceParamFilterSettings> lParamFilters = new List<ServiceParamFilterSettings>();
			foreach (ServiceParamFilter paramFilter in serviceParams.ParameterFilters)
			{
				lParamFilters.Add(new ServiceParamFilterSettings(paramFilter));
			}

			return lParamFilters.ToArray();
		}
	}
}