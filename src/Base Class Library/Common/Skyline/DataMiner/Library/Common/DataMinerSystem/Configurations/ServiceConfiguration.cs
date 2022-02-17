namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using Skyline.DataMiner.Library.Common.Properties;
	using Templates;

	/// <summary>
	/// Represents a service configuration.
	/// </summary>
	public class ServiceConfiguration
	{
		/// <summary>
		/// The parameter settings.
		/// </summary>
		private readonly ServiceParamsConfiguration parameterSettings;

		/// <summary>
		/// The advanced configuration options.
		/// </summary>
		private readonly AdvancedServiceConfiguration advancedConfiguration = new AdvancedServiceConfiguration();

		/// <summary>
		/// The IDms class.
		/// </summary>
		private readonly IDms dms;

		/// <summary>
		/// The properties to be added to the service.
		/// </summary>
		private readonly IDictionary<string, PropertyConfiguration> properties = new Dictionary<string, PropertyConfiguration>();

		/// <summary>
		/// Keeps track of which properties where updated.
		/// </summary>
		private readonly HashSet<string> updatedProperties = new HashSet<string>();

		/// <summary>
		/// The views containing the service.
		/// </summary>
		private readonly ICollection<IDmsView> views = new List<IDmsView>();

		/// <summary>
		/// Service description.
		/// </summary>
		private string description = String.Empty;

		/// <summary>
		/// The name of the service.
		/// </summary>
		private string name;

		/// <summary>
		/// Specific whether or not the properties where loaded.
		/// </summary>
		private bool propertiesLoaded;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceConfiguration"/> class. The parameter settings need to be added to create the service.
		/// </summary>
		/// <param name="dms">The <see cref="IDms"/> interface.</param>
		/// <param name="serviceName">The service name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="serviceName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="dms"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> is empty or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> contains a forbidden character.</exception>
		/// <exception cref="ArgumentException"><paramref name="serviceName"/> contains more than one '%' character.</exception>
		/// <remarks>Forbidden characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</remarks>
		public ServiceConfiguration(IDms dms, string serviceName)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}

			Name = serviceName;
			this.dms = dms;
			this.parameterSettings = new ServiceParamsConfiguration();
		}

		/// <summary>
		/// Gets the advanced settings.
		/// </summary>
		public AdvancedServiceConfiguration AdvancedSettings
		{
			get
			{
				return advancedConfiguration;
			}
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		public string Description
		{
			get
			{
				return description;
			}

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				description = value;
			}
		}

		/// <summary>
		/// Gets or sets the service name.
		/// </summary>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The value of a set operation is empty or white space.</exception>
		/// <exception cref="ArgumentException">The value of a set operation exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains a forbidden character.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains more than one '%' character.</exception>
		/// <remarks>Forbidden characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</remarks>
		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = InputValidator.ValidateName(value, "value");
			}
		}

		/// <summary>
		/// Gets the writable properties of the service.
		/// </summary>
		public IPropertConfigurationCollection Properties
		{
			get
			{
				LoadPropertyDefinitions();

				return new PropertyConfigurationCollection(properties);
			}
		}

		/// <summary>
		/// Gets the views that include the service.
		/// </summary>
		public ICollection<IDmsView> Views
		{
			get
			{
				return views;
			}
		}

		/// <summary>
		/// Gets the included elements.
		/// </summary>
		public ParamConfiguration[] IncludedElements
		{
			get
			{
				return parameterSettings.GetIncludedElements();
			}
		}

		/// <summary>
		/// Gets the list of property names that where updated.
		/// </summary>
		internal IEnumerable<string> UpdatedProperties
		{
			get
			{
				return updatedProperties;
			}
		}

		/// <summary>
		/// Add a service to the service.
		/// </summary>
		/// <param name="serviceId">The DataMiner/Service ID of the service you want to include in the service.</param>
		public void AddService(DmsServiceId serviceId)
		{
			this.parameterSettings.AddService(serviceId);
		}

		/// <summary>
		/// Add an element to the service.
		/// </summary>
		/// <param name="elementId">The DataMiner/Element ID of the element to include in the service.</param>
		/// <param name="parameters">The parameters that need to be included into the service.</param>
		public void AddElement(DmsElementId elementId, List<ElementParamFilterConfiguration> parameters)
		{
			this.parameterSettings.AddElement(elementId, parameters);
		}

		/// <summary>
		/// Loads the writable property definitions when required.
		/// </summary>
		internal void LoadPropertyDefinitions()
		{
			if (!this.propertiesLoaded)
			{
				this.propertiesLoaded = true;

				foreach (IDmsServicePropertyDefinition def in this.dms.ServicePropertyDefinitions)
				{
					if (!def.IsReadOnly)
					{
						properties.Add(def.Name, new PropertyConfiguration(this, def, String.Empty));
					}
				}
			}
		}

		/// <summary>
		/// Adds the name of the property that was updated by the user.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		internal void PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			updatedProperties.Add(e.PropertyName);
		}

		internal Net.Messages.AddServiceMessage GetServiceInfoMessage(int dmaId)
		{
			var serviceInfo = new Net.Messages.ServiceInfoEventMessage
			{
				DataMinerID = dmaId,
				ID = -1,
				Name = name,
				Description = description,
				Properties = GetPropertyInfos(),
				IgnoreTimeouts = advancedConfiguration.IgnoreTimeouts,
				ServiceElementProtocolName = advancedConfiguration.Protocol == null ? null : advancedConfiguration.Protocol.Name,
				ServiceElementProtocolVersion = advancedConfiguration.Protocol == null ? null : advancedConfiguration.Protocol.Version,
				ServiceElementAlarmTemplate = advancedConfiguration.AlarmTemplate == null ? null : advancedConfiguration.AlarmTemplate.Name,
				ServiceElementTrendTemplate = advancedConfiguration.TrendTemplate == null ? null : advancedConfiguration.TrendTemplate.Name,
				ServiceParams = parameterSettings.GetServiceInfoParams(),
				Type = Net.Messages.ServiceType.Service
			};

			Net.Messages.AddServiceMessage message = new Net.Messages.AddServiceMessage
			{
				ViewIDs = GetViewIds(),
				DataMinerID = dmaId,
				Service = serviceInfo
			};

			return message;
		}

		private int[] GetViewIds()
		{
			int viewCount = Views.Count;
			int[] viewIds = new int[viewCount];

			for (int i = 0; i < viewCount; i++)
			{
				viewIds[i] = Views.ElementAt(i).Id;
			}

			return viewIds;
		}

		private Net.Messages.PropertyInfo[] GetPropertyInfos()
		{
			ICollection<Net.Messages.PropertyInfo> propertyInfo = new List<Net.Messages.PropertyInfo>();
			if (updatedProperties.Count != 0)
			{
				foreach (string updatedProperty in UpdatedProperties)
				{
					PropertyConfiguration propertyConfiguration = Properties[updatedProperty];
					propertyInfo.Add(new Net.Messages.PropertyInfo
					{
						DataType = "Service",
						Name = propertyConfiguration.Definition.Name,
						Value = propertyConfiguration.Value
					});
				}
			}

			return propertyInfo.ToArray();
		}
	}
}