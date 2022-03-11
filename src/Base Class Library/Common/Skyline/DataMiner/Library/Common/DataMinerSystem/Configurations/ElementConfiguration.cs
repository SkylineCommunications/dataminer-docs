namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using Skyline.DataMiner.Library.Common.Properties;
	using Templates;

	/// <summary>
	/// Represents an element configuration.
	/// </summary>
	public class ElementConfiguration
	{
		/// <summary>
		/// The advanced configuration options.
		/// </summary>
		private readonly AdvancedElementConfiguration advancedConfiguration = new AdvancedElementConfiguration();

		/// <summary>
		/// The IDms class.
		/// </summary>
		private readonly IDms dms;

		/// <summary>
		/// The DVE configuration options.
		/// </summary>
		private readonly DveElementConfiguration dveConfiguration = new DveElementConfiguration();

		/// <summary>
		/// The properties to be added to the element.
		/// </summary>
		private readonly IDictionary<string, PropertyConfiguration> properties = new Dictionary<string, PropertyConfiguration>();

		/// <summary>
		/// Instance of the protocol this element executes.
		/// </summary>
		private readonly IDmsProtocol protocol;

		/// <summary>
		/// Keeps track of which properties where updated.
		/// </summary>
		private readonly HashSet<string> updatedProperties = new HashSet<string>();

		/// <summary>
		/// The view containing the element.
		/// </summary>
		private readonly ICollection<IDmsView> views = new List<IDmsView>();

		/// <summary>
		/// The alarm template assigned to this element.
		/// </summary>
		private IDmsAlarmTemplate alarmTemplate;

		/// <summary>
		/// Element description.
		/// </summary>
		private string description = String.Empty;

		/// <summary>
		/// The name of the element.
		/// </summary>
		private string name;

		/// <summary>
		/// Specific whether or not the properties where loaded.
		/// </summary>
		private bool propertiesLoaded;

		/// <summary>
		/// The element state.
		/// </summary>
		private ConfigurationElementState state = ConfigurationElementState.Active;

		/// <summary>
		/// The trend template assigned to this element.
		/// </summary>
		private IDmsTrendTemplate trendTemplate;

		/// <summary>
		/// The type of the element.
		/// </summary>
		private string type = String.Empty;
		/// <summary>
		/// The connections available to this element.
		/// </summary>
		private ElementConnectionCollection connections;

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementConfiguration"/> class and defines by default a virtual connection.
		/// </summary>
		/// <param name="dms">The <see cref="IDms"/> interface.</param>
		/// <param name="elementName">The element name.</param>
		/// <param name="protocol">The protocol.</param>
		/// <exception cref="ArgumentNullException"><paramref name="elementName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="dms"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> is empty or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> contains a forbidden character.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> contains more than one '%' character.</exception>
		/// <remarks>Forbidden characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</remarks>
		public ElementConfiguration(IDms dms, string elementName, IDmsProtocol protocol)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Name = elementName;
			this.dms = dms;
			this.protocol = protocol;
			this.connections = new ElementConnectionCollection(protocol.ConnectionInfo);
			IVirtualConnection myVirtualConnection = new VirtualConnection();
			Connections[0] = myVirtualConnection;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementConfiguration"/> class.
		/// </summary>
		/// <param name="dms">The <see cref="IDms"/> interface.</param>
		/// <param name="elementName">The element name.</param>
		/// <param name="protocol">The protocol.</param>
		/// <param name="connectionInfo">The connections that will be used to create the element.</param>
		/// <exception cref="ArgumentNullException"><paramref name="elementName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="dms"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> is empty or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> contains a forbidden character.</exception>
		/// <exception cref="ArgumentException"><paramref name="elementName"/> contains more than one '%' character.</exception>
		/// <remarks>Forbidden characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</remarks>
		public ElementConfiguration(IDms dms, string elementName, IDmsProtocol protocol, IEnumerable<IElementConnection> connectionInfo)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Name = elementName;
			this.dms = dms;
			this.protocol = protocol;
			this.connections = new ElementConnectionCollection(protocol.ConnectionInfo);
			int i = 0;
			foreach (IElementConnection conn in connectionInfo)
			{
				this.connections[i] = conn;
				i++;
			}

		}

		/// <summary>
		/// Gets the advanced settings.
		/// </summary>
		public AdvancedElementConfiguration AdvancedSettings
		{
			get
			{
				return advancedConfiguration;
			}
		}

		/// <summary>
		/// Gets or sets the alarm template.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is an alarm template that is not compatible with the protocol of the element.</exception>
		public IDmsAlarmTemplate AlarmTemplate
		{
			get
			{
				return alarmTemplate;
			}

			set
			{
				if (!InputValidator.IsCompatibleTemplate(value, this.Protocol))
				{
					throw new ArgumentException("The specified alarm template is not compatible with the protocol this element executes.", "value");
				}
				else
				{
					this.alarmTemplate = value;
				}
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
		/// Gets the DVE settings.
		/// </summary>
		public DveElementConfiguration DveSettings
		{
			get
			{
				return dveConfiguration;
			}
		}

		/// <summary>
		/// Gets or sets the element name.
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
		/// Gets the writable properties of the elements.
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
		/// Gets the protocol.
		/// </summary>
		public IDmsProtocol Protocol
		{
			get
			{
				return protocol;
			}
		}

		/// <summary>
		/// Gets or sets the element state.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is invalid.</exception>
		public ConfigurationElementState State
		{
			get
			{
				return state;
			}

			set
			{
				if (value == ConfigurationElementState.Active || value == ConfigurationElementState.Paused || value == ConfigurationElementState.Stopped)
				{
					state = value;
				}
				else
				{
					throw new ArgumentException("Invalid state specified.", "value");
				}
			}
		}

		/// <summary>
		/// Gets or sets the trend template.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is a trend template that is not compatible with the protocol of the element.</exception>
		public IDmsTrendTemplate TrendTemplate
		{
			get
			{
				return trendTemplate;
			}

			set
			{
				if (!InputValidator.IsCompatibleTemplate(value, this.Protocol))
				{
					throw new ArgumentException("The specified trend template is not compatible with the protocol this element executes.", "value");
				}
				else
				{
					trendTemplate = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the type of the element.
		/// </summary>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		public string Type
		{
			get
			{
				return type;
			}

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				type = value;
			}
		}

		/// <summary>
		/// Gets the views that include the element.
		/// </summary>
		public ICollection<IDmsView> Views
		{
			get
			{
				return views;
			}
		}

		/// <summary>
		/// Gets or sets the list of connections on the element.
		/// </summary>
		public ElementConnectionCollection Connections
		{
			get { return connections; }

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != connections.Length)
				{
					throw new IncorrectDataException("IElementConnection array length does not match expected value");
				}
				else
				{
					bool valid = value.ValidateConnectionTypes();
					if (!valid)
					{
						throw new IncorrectDataException("Invalid Connection Type provided.");
					}
					connections = value;
				}
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
		/// Loads the writable property definitions when required.
		/// </summary>
		internal void LoadPropertyDefinitions()
		{
			if (!this.propertiesLoaded)
			{
				this.propertiesLoaded = true;

				foreach (IDmsElementPropertyDefinition def in this.dms.ElementPropertyDefinitions)
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
	}
}