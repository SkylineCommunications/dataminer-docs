namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	/// Class representing an HTTP Connection.
	/// </summary>
	public class HttpConnection : ConnectionSettings, IHttpConnection
	{
		private string busAddress;

		private readonly int id;

		private TimeSpan? elementTimeout;

		private bool isBypassProxyEnabled;

		private int retries;

		private ITcp tcpConfiguration;

		private TimeSpan timeout;

		private const string BypassProxyValue = "bypassProxy";

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpConnection"/> class with default settings for Timeout (1500), Retries (3), Element Timeout (30),
		/// </summary>
		/// <param name="tcpConfiguration">The TCP Connection.</param>
		/// <param name="isByPassProxyEnabled">Allows you to enable the ByPassProxy setting. Default true.</param>
		/// <remarks>In case HTTPS needs to be used. TCP port needs to be 443 or the PollingIP needs to start with https:// . e.g. https://192.168.0.1</remarks>
		public HttpConnection(ITcp tcpConfiguration, bool isByPassProxyEnabled = true)
		{
			if (tcpConfiguration == null) throw new ArgumentNullException("tcpConfiguration");

			this.tcpConfiguration     = tcpConfiguration;
			this.busAddress           = isByPassProxyEnabled ? BypassProxyValue : String.Empty;
			this.IsBypassProxyEnabled = isByPassProxyEnabled;
			this.id                   = -1;
			this.timeout              = new TimeSpan(0, 0, 0, 0, 1500);
			this.retries              = 3;
			this.elementTimeout       = new TimeSpan(0, 0, 0, 30);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpConnection"/> class using the specified <see cref="ElementPortInfo"/>.
		/// </summary>
		/// <param name="info">Instance of <see cref="ElementPortInfo"/> to parse the contents of.</param>
		internal HttpConnection(ElementPortInfo info)
		{
			this.busAddress           = info.BusAddress;
			this.isBypassProxyEnabled = info.ByPassProxy;
			this.retries              = info.Retries;
			this.timeout              = new TimeSpan(0, 0, 0, 0, info.TimeoutTime);
			this.id                   = info.PortID;
			this.elementTimeout       = new TimeSpan(0, 0, 0, 0, info.ElementTimeoutTime);
			this.tcpConfiguration     = new Tcp(info);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpConnection"/> class.
		/// </summary>
		public HttpConnection()
		{
		}

		/// <summary>
		/// Gets the bus address.
		/// </summary>
		/// <value>The buss address.</value>
		public string BusAddress
		{
			get
			{
				return this.busAddress;
			}
		}

		/// <summary>
		/// Gets or sets the element timeout.
		/// </summary>
		/// <value>The element timeout.</value>
		/// <remarks>When <see langword="null"/>, this connection will not be taken into account for the element to go into timeout.</remarks>
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
					this.ChangedPropertyList.Add(ConnectionSetting.ElementTimeout);
					this.elementTimeout = value;
				}
			}
		}

		/// <summary>
		/// Gets the connection ID.
		/// </summary>
		/// <value>The connection ID.</value>
		public int Id
		{
			get
			{
				return this.id;
			}
		}

		/// <summary>
		/// Gets a value indicating whether to bypass the proxy.
		/// </summary>
		/// <value><c>true</c> if the proxy needs to be bypassed; otherwise, <c>false</c>.</value>
		public bool IsBypassProxyEnabled
		{
			get
			{
				return this.isBypassProxyEnabled;
			}

			set
			{
				if (this.isBypassProxyEnabled != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.IsByPassProxyEnabled);
					this.isBypassProxyEnabled = value;
					this.busAddress = this.isBypassProxyEnabled ? BypassProxyValue : String.Empty;
				}
			}
		}

		/// <summary>
		/// Gets or set the number of retries.
		/// </summary>
		/// <value>The number of retries.</value>
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
					this.ChangedPropertyList.Add(ConnectionSetting.Retries);
					this.retries = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the TCP connection configuration.
		/// </summary>
		/// <value>The TCP connection configuration.</value>
		public ITcp TcpConfiguration
		{
			get
			{
				return this.tcpConfiguration;
			}

			set
			{
				if (this.tcpConfiguration != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.PortConnection);
					this.tcpConfiguration = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the timeout.
		/// </summary>
		/// <value>The timeout.</value>
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
					this.ChangedPropertyList.Add(ConnectionSetting.Timeout);
					this.timeout = value;
				}
			}
		}
	}
}