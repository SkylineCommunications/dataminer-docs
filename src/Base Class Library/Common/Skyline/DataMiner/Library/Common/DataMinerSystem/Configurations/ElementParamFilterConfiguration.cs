namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using Net.Messages;

	/// <summary>
	/// Represents a class for the element parameters included in the service.
	/// </summary>
	public class ElementParamFilterConfiguration
	{
		private readonly ServiceParamFilter serviceParamFilter;

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementParamFilterConfiguration"/> class.
		/// </summary>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="filter">The filter in case of a table parameter.</param>
		/// <param name="included">Indicates if the parameter is included.</param>
		/// <exception cref="ArgumentException"><paramref name="pid"/> is invalid.</exception>
		public ElementParamFilterConfiguration(int pid, string filter, bool included)
		{
			if (pid < 0)
			{
				throw new ArgumentException("The parameter ID should be greater than 0.", "pid");
			}

			serviceParamFilter = new ServiceParamFilter(pid, filter, included);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementParamFilterConfiguration"/> class.
		/// </summary>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="filter">The filter in case of a table parameter.</param>
		/// <param name="included">Indicates if the parameter is included.</param>
		/// <param name="type">The type of the filter.</param>
		/// <exception cref="ArgumentException"><paramref name="pid"/> is invalid.</exception>
		public ElementParamFilterConfiguration(int pid, string filter, bool included, FilterType type)
		{
			if (pid < 0)
			{
				throw new ArgumentException("The parameter ID should be greater than 0.", "pid");
			}

			serviceParamFilter = new ServiceParamFilter(pid, filter, included, (Net.Messages.FilterType)type);
		}

		internal ElementParamFilterConfiguration(ServiceParamFilter serviceParamFilter)
		{
			this.serviceParamFilter = serviceParamFilter;
		}

		/// <summary>
		/// Gets or sets the filter for the parameter.
		/// </summary>
		public string Filter
		{
			get
			{
				return serviceParamFilter.Filter;
			}

			set
			{
				serviceParamFilter.Filter = value;
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
		/// Gets or sets the filter type for the parameter.
		/// </summary>
		public FilterType FilterType
		{
			get
			{
				return (FilterType)serviceParamFilter.FilterType;
			}

			set
			{
				serviceParamFilter.FilterType = (Net.Messages.FilterType)value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the parameter is included.
		/// </summary>
		public bool IsIncluded
		{
			get
			{
				return serviceParamFilter.IsIncluded;
			}

			set
			{
				serviceParamFilter.IsIncluded = value;
			}
		}

		/// <summary>
		/// Gets or sets the matrix port for the parameter.
		/// </summary>
		public int MatrixPort
		{
			get
			{
				return serviceParamFilter.MatrixPort;
			}

			set
			{
				serviceParamFilter.MatrixPort = value;
			}
		}

		/// <summary>
		/// Gets or sets the ID of the parameter.
		/// </summary>
		public int ParameterID
		{
			get
			{
				return serviceParamFilter.ParameterID;
			}

			set
			{
				serviceParamFilter.ParameterID = value;
			}
		}

		internal ServiceParamFilter ServiceParamFilter
		{
			get
			{
				return serviceParamFilter;
			}
		}

		internal static List<ElementParamFilterConfiguration> GetParameterFilters(ServiceInfoParams infoParams)
		{
			List<ElementParamFilterConfiguration> lParameters = new List<ElementParamFilterConfiguration>();
			foreach (var parameter in infoParams.ParameterFilters)
			{
				lParameters.Add(new ElementParamFilterConfiguration(parameter));
			}

			return lParameters;
		}
	}
}