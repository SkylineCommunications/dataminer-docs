using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Represents an SLNet connection.
	/// </summary>
	public class SLNetConnection : ISLNetConnection
	{
		/// <summary>
		/// Tries to open the connection.
		/// </summary>
		public virtual void TryOpenConnection()
		{
		}

		/// <summary>
		/// Opens the connection.
		/// </summary>
		public virtual void OpenConnection()
		{
		}

		/// <summary>
		/// Closes the connection.
		/// </summary>
		public virtual void CloseConnection()
		{
		}

		/// <summary>
		/// Gets the raw connection.
		/// </summary>
		/// <value>The raw connection.</value>
		public virtual Connection RawConnection
		{
			get;
		}

		/// <summary>
		/// Gets a value indicating whether the connection is alive.
		/// </summary>
		/// <value><c>true</c> if the connection is alive; otherwise, <c>false</c>.</value>
		public virtual bool IsAlive
		{
			get;
		}

		/// <summary>
		/// Sends the specified message to the SLNet process.
		/// </summary>
		/// <param name="message">The SLNet message to send.</param>
		/// <returns>The response message(s) from SLNet.</returns>
		/// <remarks>
		/// <note type="warning">
		/// SLNet messages are subject to change. Therefore, it is not recommended to use these as breaking changes might be introduced in new versions of DataMiner.
		/// </note>
		/// </remarks>
		public virtual DMSMessage[] SendMessage(DMSMessage message)
		{
			return this.SendMessages(message);
		}

		/// <summary>
		/// Sends the specified messages to the SLNet process.
		/// </summary>
		/// <param name="messages">The SLNet messages to send.</param>
		/// <returns>The response message(s) from SLNet.</returns>
		/// <remarks>
		/// <note type="warning">
		/// SLNet messages are subject to change. Therefore, it is not recommended to use these as breaking changes might be introduced in new versions of DataMiner.
		/// </note>
		/// </remarks>
		public virtual DMSMessage[] SendMessages(params DMSMessage[] messages)
		{
			return null;
		}

		/// <summary>
		/// Sends the specified message to the SLNet process.
		/// </summary>
		/// <param name="message">The SLNet message to send.</param>
		/// <returns>The response message from SLNet.</returns>
		/// <remarks>
		/// <note type="warning">
		/// SLNet messages are subject to change. Therefore, it is not recommended to use these as breaking changes might be introduced in new versions of DataMiner.
		/// </note>
		/// </remarks>
		public virtual DMSMessage SendSingleResponseMessage(DMSMessage message)
		{
			return null;
		}
	}
}
