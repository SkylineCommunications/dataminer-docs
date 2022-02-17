namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	///     Class representing an SNMPv1 connection.
	/// </summary>
	public class SnmpV1Connection : ConnectionSettings, ISnmpV1Connection
	{
		private readonly int id;

		private readonly Guid libraryCredentials;

		private string deviceAddress;

		private TimeSpan? elementTimeout;

		private string getCommunityString;

		private int retries;

		private string setCommunityString;

		private TimeSpan timeout;

		private IUdp udpIpConfiguration;

		/// <summary>
		///     /// Initiates a new instance with default settings for Get Community String (public), Set Community String
		///     (private), Device Address (empty),
		///     Command Timeout (1500ms), Retries (3) and Element Timeout (30s).
		/// </summary>
		/// <param name="udpConfiguration">The UDP configuration parameters.</param>
		public SnmpV1Connection(IUdp udpConfiguration)
		{
			if (udpConfiguration == null)
			{
				throw new ArgumentNullException("udpConfiguration");
			}

			this.id                 = -1;
			this.udpIpConfiguration = udpConfiguration;
			this.getCommunityString = "public";
			this.setCommunityString = "private";
			this.deviceAddress      = String.Empty;
			this.timeout            = new TimeSpan(0, 0, 0, 0, 1500);
			this.retries            = 3;
			this.elementTimeout     = new TimeSpan(0, 0, 0, 30);
		}

		/// <summary>
		///     Default empty constructor
		/// </summary>
		public SnmpV1Connection()
		{
		}

		/// <summary>
		///     Get or Set the device address.
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
		///     Get or sets the Get community string.
		/// </summary>
		public string GetCommunityString
		{
			get
			{
				return this.getCommunityString;
			}

			set
			{
				if (this.getCommunityString != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.GetCommunityString);
					this.getCommunityString = value;
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
		}

		/// <summary>
		///     Get the libraryCredentials
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
		///     Get or set the Set Community String.
		/// </summary>
		public string SetCommunityString
		{
			get
			{
				return this.setCommunityString;
			}

			set
			{
				if (this.setCommunityString != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.SetCommunityString);
					this.setCommunityString = value;
				}
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
				if (this.udpIpConfiguration==null || !this.udpIpConfiguration.Equals(value))
				{
					this.ChangedPropertyList.Add(ConnectionSetting.PortConnection);
					this.udpIpConfiguration = value;
				}
			}
		}
	}
}