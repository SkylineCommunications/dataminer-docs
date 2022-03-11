namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	///     Class representing a SNMPv3 class.
	/// </summary>
	public class SnmpV3Connection : ConnectionSettings, ISnmpV3Connection
	{
		private readonly int id;

		private readonly Guid libraryCredentials;

		private string deviceAddress;

		private TimeSpan? elementTimeout;

		private int retries;

		private ISnmpV3SecurityConfig securityConfig;

		private TimeSpan timeout;

		private IUdp udpIpConfiguration;

		/// <summary>
		///     Initializes a new instance.
		/// </summary>
		/// <param name="udpConfiguration">The udp configuration settings.</param>
		/// <param name="securityConfig">The SNMPv3 security configuration.</param>
		public SnmpV3Connection(IUdp udpConfiguration, SnmpV3SecurityConfig securityConfig)
		{
			if (udpConfiguration == null)
			{
				throw new ArgumentNullException("udpConfiguration");
			}

			if (securityConfig == null)
			{
				throw new ArgumentNullException("securityConfig");
			}

			this.libraryCredentials = Guid.Empty;
			this.id                 = -1;
			this.udpIpConfiguration = udpConfiguration;
			this.deviceAddress      = String.Empty;
			this.securityConfig     = securityConfig;
			this.timeout            = new TimeSpan(0, 0, 0, 0, 1500);
			this.retries            = 3;
			this.elementTimeout     = new TimeSpan(0, 0, 0, 30);
		}

		/// <summary>
		///     Default empty constructor
		/// </summary>
		public SnmpV3Connection()
		{
		}

		/// <summary>
		///     Gets or Sets the device address.
		/// </summary>
		public string DeviceAddress
		{
			get
			{
				return this.deviceAddress;
			}

			set
			{
				if (this.deviceAddress != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.DeviceAddress);
					this.deviceAddress = value;
				}
			}
		}

		/// <summary>
		///     Get or Set the timespan before the element will go into timeout after not responding.
		/// </summary>
		/// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
		public TimeSpan? ElementTimeout
		{
			get
			{
				return this.elementTimeout;
			}

			set
			{
				if (this.elementTimeout != value)
				{
					if (value == null || (value.Value.TotalSeconds >= 1 && value.Value.TotalSeconds <= 120))
					{
						this.ChangedPropertyList.Add(ConnectionSetting.ElementTimeout);
						this.elementTimeout = value;
					}
					else
					{
						throw new IncorrectDataException("ElementTimeout value should be between 1 and 120 sec.");
					}
				}
			}
		}

		/// <summary>
		/// Gets the zero based id of the connection.
		/// </summary>
		public int Id
		{
			get
			{
				return this.id;
			}

			// set
			// {
			// 	ChangedPropertyList.Add("Id");
			// 	id = value;
			// }
		}

		/// <summary>
		///     Get the libraryCredentials.
		/// </summary>
		public Guid LibraryCredentials
		{
			get
			{
				return this.libraryCredentials;
			}
		}

		/// <summary>
		///     Get or Set the amount of retries.
		/// </summary>
		public int Retries
		{
			get
			{
				return this.retries;
			}

			set
			{
				if (this.retries != value)
				{
					if (value >= 0 && value <= 10)
					{
						this.ChangedPropertyList.Add(ConnectionSetting.Retries);
						this.retries = value;
					}
					else
					{
						throw new IncorrectDataException("Retries value should be between 0 and 10.");
					}
				}
			}
		}

		/// <summary>
		///     Gets or sets the SNMPv3 security configuration.
		/// </summary>
		public ISnmpV3SecurityConfig SecurityConfig
		{
			get
			{
				return this.securityConfig;
			}

			set
			{
				this.ChangedPropertyList.Add(ConnectionSetting.SecurityConfig);
				this.securityConfig = value;
			}
		}

		/// <summary>
		///     Get or Set the timeout value.
		/// </summary>
		public TimeSpan Timeout
		{
			get
			{
				return this.timeout;
			}

			set
			{
				if (this.timeout != value)
				{
					if (value.TotalMilliseconds >= 10 && value.TotalMilliseconds <= 120000)
					{
						this.ChangedPropertyList.Add(ConnectionSetting.Timeout);
						this.timeout = value;
					}
					else
					{
						throw new IncorrectDataException("Timeout value should be between 10 and 120 sec.");
					}
				}
			}
		}

		/// <summary>
		///     Get or Set the UDP Connection settings
		/// </summary>
		public IUdp UdpConfiguration
		{
			get
			{
				return this.udpIpConfiguration;
			}

			set
			{
				if (this.udpIpConfiguration == null || !this.udpIpConfiguration.Equals(value))
				{
					this.ChangedPropertyList.Add(ConnectionSetting.PortConnection);
					this.udpIpConfiguration = value;
				}
			}
		}
	}
}