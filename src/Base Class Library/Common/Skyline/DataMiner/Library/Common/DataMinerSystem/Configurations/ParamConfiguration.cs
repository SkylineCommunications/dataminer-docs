namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Net.Messages;

	/// <summary>
	/// Represents an abstract configuration class for elements or services that are included in a service.
	/// </summary>
	public abstract class ParamConfiguration : IServiceParamConfiguration
	{
		/// <summary>
		/// Gets or sets the Alias of the element.
		/// </summary>
		/// <exception cref="ArgumentException">The value has an alias that already exists in the service configuration.</exception>
		public string Alias
		{
			get
			{
				return IncludedElement.Alias;
			}

			set
			{
				if (ParamsSettingsConfiguration.ContainsAlias(value))
				{
					throw new ArgumentException("The alias already exists in the service configuration.", "value");
				}

				IncludedElement.Alias = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the included capped alarm level of the element.
		/// </summary>
		public AlarmLevel IncludedCapped
		{
			get
			{
				return (AlarmLevel)Enum.Parse(typeof(AlarmLevel), IncludedElement.IncludedCapped, true);
			}

			set
			{
				IncludedElement.IncludedCapped = value.ToString();
			}
		}
		
		/// <summary>
		/// Gets or sets the index of the element.
		/// </summary>
		public int Index
		{
			get
			{
				return IncludedElement.Index;
			}

			protected set
			{
				IncludedElement.Index = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the element is excluded.
		/// </summary>
		public bool IsExcluded
		{
			get
			{
				return IncludedElement.IsExcluded;
			}

			set
			{
				IncludedElement.IsExcluded = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the element is a service.
		/// </summary>
		public bool IsService
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Gets or sets the not used capped alarm level of the element.
		/// </summary>
		public AlarmLevel NotUsedCapped
		{
			get
			{
				return (AlarmLevel)Enum.Parse(typeof(AlarmLevel), IncludedElement.NotUsedCapped, true);
			}

			set
			{
				IncludedElement.NotUsedCapped = value.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the paramsSettingsConfiguration class.
		/// </summary>
		internal ServiceParamsConfiguration ParamsSettingsConfiguration { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="ServiceInfoParams"/> object of the included element.
		/// </summary>
		protected ServiceInfoParams IncludedElement { get; set; }

		/// <summary>
		/// Gets the serviceInfoParams object used by SLNet.
		/// </summary>
		/// <returns>The serviceInfoParams object.</returns>
		internal abstract ServiceInfoParams GetServiceInfoParams();
	}
}