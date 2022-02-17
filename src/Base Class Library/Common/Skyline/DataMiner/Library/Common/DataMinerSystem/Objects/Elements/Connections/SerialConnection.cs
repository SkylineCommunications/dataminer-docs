namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Class representing a Serial Connection.
	/// </summary>
	public class SerialConnection : ISerialConnection
	{
		/// <summary>
		///	Initiates a new instance with default settings for Timeout (1500), Retries (3), Element Timeout (30),
		///	</summary>
		/// <param name="tcpConnection">The TCP Connection.</param>
		public SerialConnection(ITcp tcpConnection)
		{
			if (tcpConnection == null) throw new ArgumentNullException("tcpConnection");

			Connection = tcpConnection;
			BusAddress = String.Empty;
			Id = -1;
			Timeout = new TimeSpan(0, 0, 0, 0, 1500);
			Retries = 3;
			ElementTimeout = new TimeSpan(0, 0, 0, 30);
		}

		/// <summary>
		///	Initiates a new instance with default settings for Timeout (1500), Retries (3), Element Timeout (30),
		///	</summary>
		/// <param name="udpConnection">The UDP Connection.</param>
		public SerialConnection(IUdp udpConnection)
		{
			if (udpConnection == null) throw new ArgumentNullException("udpConnection");

			Connection = udpConnection;
			BusAddress = String.Empty;
			Id = -1;
			Timeout = new TimeSpan(0, 0, 0, 0, 1500);
			Retries = 3;
			ElementTimeout = new TimeSpan(0, 0, 0, 30);
		}

		/// <summary>
		/// Default empty constructor
		/// </summary>
		public SerialConnection()
		{

		}

		/// <summary>
		/// Get or Sets the connection settings.
		/// </summary>
		public IPortConnection Connection { get; set; }

		/// <summary>
		/// Gets or sets the bus address.
		/// </summary>
		public string BusAddress { get; set; }

		/// <summary>
		/// Get or Set the timeout value.
		/// </summary>
		public TimeSpan Timeout { get; set; }

		/// <summary>
		/// Get or Set the amount of retries.
		/// </summary>
		public int Retries { get; set; }

		/// <summary>
		/// Get or Set the timespan before the element will go into timeout after not responding.
		/// </summary>
		/// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
		public TimeSpan? ElementTimeout { get; set; }

		/// <summary>
		/// Get or Sets the zero based id of the connection.
		/// </summary>
		public int Id { get; private set; }
	}
}