using System;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Delegate used for the <see cref="IConnection.OnEventsDropped"/> event of the <see cref="IConnection"/> interface.
    /// </summary>
    public delegate void EventsDroppedEventHandler(Object sender, EventsDroppedEventArgs e);

	/// <summary>
	/// Event arguments for use with <see cref="EventsDroppedEventHandler"/>.
	/// </summary>
	/// <remarks>
	/// <seealso cref="IConnection.OnEventsDropped"/>
	/// </remarks>
	public class EventsDroppedEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new <see cref="EventsDroppedEventArgs"/> instance.
		/// </summary>
		/// <param name="reason">Reason why events have been dropped.</param>
		public EventsDroppedEventArgs(String reason)
		{
			_reason = reason;
		}

		/// <summary>
		/// Gets the reason why events have been dropped.
		/// </summary>
		/// <value>The reason why events have been dropped.</value>
		public string Reason
		{
			get
			{
				return _reason;
			}
		}

		private string _reason;
	}

}