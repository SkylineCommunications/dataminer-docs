namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	/// A collection of IElementConnection objects.
	/// </summary>
	public class ElementConnectionCollection : IElementConnectionCollection
	{
		private readonly IElementConnection[] connections;
		private readonly bool canBeValidated;
		private readonly IList<IDmsConnectionInfo> protocolConnectionInfo;

		/// <summary>
		/// initiates a new instance.
		/// </summary>
		/// <param name="protocolConnectionInfo"></param>
		internal ElementConnectionCollection(IList<IDmsConnectionInfo> protocolConnectionInfo)
		{
			int amountOfConnections = protocolConnectionInfo.Count;
			this.connections = new IElementConnection[amountOfConnections];
			this.protocolConnectionInfo = protocolConnectionInfo;
			canBeValidated = true;
		}
		/// <summary>
		/// Initiates a new instance.
		/// </summary>
		/// <param name="message"></param>
		internal ElementConnectionCollection(ElementInfoEventMessage message)
		{
			int amountOfConnections = 1;
			if (message !=null && message.ExtraPorts != null)
			{
				amountOfConnections += message.ExtraPorts.Length;
			}

			this.connections = new IElementConnection[amountOfConnections];
			canBeValidated = false;
		}

		/// <summary>
		/// Gets the total amount of elements in the collection.
		/// </summary>
		public int Length
		{
			get { return connections.Length; }
		}

		/// <summary>
		/// Returns the collection as a IElementConnection array.
		/// </summary>
		public IEnumerable<IElementConnection> Enumerator
		{
			get
			{
				return connections;
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<IElementConnection> GetEnumerator()
		{
			return ((IEnumerable<IElementConnection>)connections).GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Gets or sets an entry in the collection.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public IElementConnection this[int index]
		{
			get
			{
				return connections[index];
			}

			set
			{
				bool valid = ValidateConnectionTypeAtPos(index, value);
				if (valid)
				{
					connections[index] = value;
				}
				else
				{
					throw new IncorrectDataException("Invalid connection type provided at index " + index);
				}
			}
		}

		/// <summary>
		/// Validates all connections in the collection. 
		/// </summary>
		/// <returns>returns true when connection is valid, false when invalid.</returns>
		internal bool ValidateConnectionTypes()
		{
			bool valid = true;

			for (int i = 0; i < protocolConnectionInfo.Count; i++)
			{
				IDmsConnectionInfo connectionInfo = protocolConnectionInfo[i];
				IElementConnection conn = this.connections[i];

				valid = ValidateConnectionInfo(conn, connectionInfo);
				if (!valid) break;
			}

			return valid;
		}

		/// <summary>
		/// Validates the provided <see cref="IElementConnection"/> against the provided Protocol.
		/// </summary>
		/// <param name="index">The index position of the connection to validate.</param>
		/// <param name="conn">The IElementConnection connection.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is out of range.</exception>
		/// <returns></returns>
		private bool ValidateConnectionTypeAtPos(int index, IElementConnection conn)
		{
			if (!canBeValidated)
			{
				return true;
			}

			if (index < 0 || ((index + 1) > protocolConnectionInfo.Count))
			{
				throw new ArgumentOutOfRangeException("index", "Index needs to be between 0 and the amount of connections in the protocol minus 1.");
			}

			return ValidateConnectionInfo(conn, protocolConnectionInfo[index]);
		}

		/// <summary>
		/// Validates a single connection.
		/// </summary>
		/// <param name="conn"><see cref="IElementConnection"/> object.</param>
		/// <param name="connectionInfo"><see cref="IDmsConnectionInfo"/> object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="conn"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="connectionInfo"/> is <see langword="null"/>.</exception>
		/// <returns></returns>
		private static bool ValidateConnectionInfo(IElementConnection conn, IDmsConnectionInfo connectionInfo)
		{
			if (conn == null)
			{
				throw new IncorrectDataException("conn: Invalid data , ElementConfiguration does not contain connection info");
			}
			if (connectionInfo == null)
			{
				throw new IncorrectDataException("connectionInfo: Invalid data , Protocol does not contain connection info");
			}

			switch (connectionInfo.Type)
			{
				case ConnectionType.SnmpV1: return ValidateAsSnmpV1(conn);
				case ConnectionType.SnmpV2: return ValidateAsSnmpV2(conn);
				case ConnectionType.SnmpV3: return ValidateAsSnmpV3(conn);
				case ConnectionType.Virtual: return conn is IVirtualConnection;
				case ConnectionType.Http: return conn is IHttpConnection;
				default: return false;
			}
		}

		/// <summary>
		/// Validate a connection for SNMPv1
		/// </summary>
		/// <param name="conn">object of type <see cref="IElementConnection"/> to validate.</param>
		/// <returns></returns>
		private static bool ValidateAsSnmpV1(IElementConnection conn)
		{
			return conn is ISnmpV1Connection || conn is ISnmpV2Connection || conn is ISnmpV3Connection;
		}

		/// <summary>
		/// Validate a connection for SNMPv2
		/// </summary>
		/// <param name="conn">object of type <see cref="IElementConnection"/> to validate.</param>
		/// <returns></returns>
		private static bool ValidateAsSnmpV2(IElementConnection conn)
		{
			return conn is ISnmpV2Connection || conn is ISnmpV3Connection;
		}

		/// <summary>
		/// Validate a connection for SNMPv3
		/// </summary>
		/// <param name="conn">object of type <see cref="IElementConnection"/> to validate.</param>
		/// <returns></returns>
		private static bool ValidateAsSnmpV3(IElementConnection conn)
		{
			return conn is ISnmpV3Connection || conn is ISnmpV2Connection;
		}

		/// <summary>
		/// Clear any update flags for all the provided connections.
		/// </summary>
		public void Clear()
		{
			foreach (IElementConnection connection in connections)
			{
				ConnectionSettings connectionSetting = connection as ConnectionSettings;

				if(connectionSetting != null)
				{
					connectionSetting.ClearUpdates();
				}
			}
		}

		/// <summary>
		/// Indicates if changes occurred on IElementCommunicationConnection objects requiring an update of the SLNET Message.
		/// </summary>
		/// <returns>A boolean indicating an update is required or not. </returns>
		public bool IsUpdateRequired()
		{
			bool isUpdate = false;
			foreach (IElementConnection connection in connections)
			{
				ConnectionSettings connectionSetting = connection as ConnectionSettings;

				if(connectionSetting != null)
				{
					isUpdate = connectionSetting.IsUpdated;
					if (isUpdate) break;
				}
			}

			return isUpdate;
		}

		/// <summary>
		/// Updates the provide ElementPortInfo list based on changes performed on provided IElementCommunicationConnection implementations.
		/// </summary>
		/// <param name="portInfos">List of <see cref="ElementPortInfo"/></param>
		/// <param name="isCompatibilityIssueDetected"></param>
		internal void UpdatePortInfo(ElementPortInfo[] portInfos,bool isCompatibilityIssueDetected)
		{
			for (int i = 0; i < connections.Length; i++)
			{
				ConnectionSettings settings = connections[i] as ConnectionSettings;

				if(settings != null)
				{
					ElementPortInfo info = portInfos[i];
					settings.UpdateElementPortInfo(info, isCompatibilityIssueDetected);
				}
			}
		}

		/// <summary>
		/// Creates a list of ElementPortInfo objects based on the list of IElementCommunicationConnection objects.
		/// </summary>
		/// <returns>List of <see cref="ElementPortInfo"/></returns>
		internal IEnumerable<ElementPortInfo> CreatePortInfo(bool isCompatibilityIssueDetected)
		{
			ElementPortInfo[] portInfoMessages = new ElementPortInfo[connections.Length];

			for (int i = 0; i < connections.Length; i++)
			{
				ConnectionSettings connection = connections[i] as ConnectionSettings;

				if(connection != null)
				{
					portInfoMessages[i] = connection.CreateElementPortInfo(i, isCompatibilityIssueDetected);
				}
			}

			return portInfoMessages;
		}
	}
}
