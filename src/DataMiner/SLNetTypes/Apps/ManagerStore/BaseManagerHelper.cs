using Skyline.DataMiner.Net.Messages;
using System;

namespace Skyline.DataMiner.Net.ManagerStore
{
	/// <summary>
	/// Manager helper base class.
	/// </summary>
	/// <remarks>
	/// The basis of every helper for a manager in the ManagerStore. 
	/// Use <see cref="CrudHelperComponent{T}"/> objects in the class that inherits from this.
	/// </remarks>
	public class BaseManagerHelper
    {
        /// <summary>
        /// The delegate that does message handling.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <returns>Messages.</returns>
        public delegate DMSMessage[] MessageHandlerDelegate(DMSMessage[] messages);

		/// <summary>
		/// Gets the message handler.
		/// </summary>
		/// <value>The message handler.</value>
		protected Func<DMSMessage[], DMSMessage[]> MessageHandler { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseManagerHelper"/> using the specified message handler.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		public BaseManagerHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseManagerHelper"/> using the specified message handler.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		public BaseManagerHelper(MessageHandlerDelegate messageHandler)
        {
        }
    }
}