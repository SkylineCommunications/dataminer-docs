using Skyline.DataMiner.Net.Messages;
using System;
using System.Globalization;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Delegate used for the <see cref="IConnection.OnNewMessage"/> event of the <see cref="IConnection"/> interface.
    /// </summary>
    public delegate void NewMessageEventHandler(Object sender, NewMessageEventArgs e); 

	/// <summary>
	/// Event arguments for use with <seealso cref="NewMessageEventHandler"/>.
	/// </summary>
	/// <remarks>
	/// <seealso cref="IConnection.OnNewMessage"/>
	/// </remarks>
	public class NewMessageEventArgs : EventArgs
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="NewMessageEventArgs"/> class.
		/// </summary>
		/// <param name="msg">The message.</param>
		public NewMessageEventArgs(DMSMessage msg)
		{
		}

		/// <summary>
		/// Gets the number of bytes
		/// of the incoming package.
		/// </summary>
		/// <value>The number of bytes of the incoming package.</value>
		public int ByteSize { get; internal set; }

		/// <summary>
		/// Gets the message associated with this event.
		/// </summary>
		/// <value>The message associated with this event.</value>
		public DMSMessage Message
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Returns a value indicating whether this message was sent because of a subscription in the default set. 
		/// </summary>
		/// <returns>
		/// <c>true</c> if this message was sent because of a subscription in the default set; otherwise, <c>false</c>.
		/// </returns>
		public bool FromDefaultSet()
		{
			return FromSet(null);
		}

		/// <summary>
		/// Returns a value indicating whether the message was sent to the client because of a subscription in the set with the given ID.
		/// </summary>
		/// <param name="setID"></param>
		/// <returns>
		/// <c>true</c> if the message was sent to the client because of a subscription in the set with the given ID; otherwise, <c>false</c>.
		/// </returns>
		public bool FromSet(string setID)
		{
			return false;
		}

		/// <summary>
		/// Gets a value indicating whether the event needs to go to any subscription set.
		/// </summary>
		/// <value><c>true</c> if the event needs to go to any subscription set; otherwise, <c>false</c>.</value>
		public bool IsForAllSets
        {
            get
            {
				return false;
            }
        }

		/// <summary>
		/// Gets a collection of set IDs. To find out if this event applies to a certain set,
		/// use the <see cref="FromSet"/> and <see cref="FromDefaultSet"/> instead.
		/// </summary>
		public string[] SetIDs
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return String.Empty;
		}
	}

}