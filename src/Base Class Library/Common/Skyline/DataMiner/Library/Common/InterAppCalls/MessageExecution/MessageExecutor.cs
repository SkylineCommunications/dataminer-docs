namespace Skyline.DataMiner.Library.Common.InterAppCalls.MessageExecution
{
	using CallSingle;

	/// <summary>
	/// Represents a message executor for a specific provided message. There may only be one executor per message type.
	/// </summary>
	/// <typeparam name="T">The message type.</typeparam>
	public abstract class MessageExecutor<T> : IMessageExecutor
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageExecutor{T}"/> class using the specified message.
		/// </summary>
		/// <param name="message">The message</param>
		protected MessageExecutor(T message)
		{
			Message = message;
		}

		/// <summary>
		/// Gets the message to execute.
		/// </summary>
		public T Message { get; private set; }

		/// <summary>
		/// Creates a return message. (Optional.)
		/// </summary>
		/// <returns>A message representing the response for the processed message.</returns>
		public abstract Message CreateReturnMessage();

		/// <summary>
		/// Reads data from SLProtocol, Engine or other data sources. (Optional.)
		/// </summary>
		/// <param name="dataSource">SLProtocol, Engine, or other data sources.</param>
		public abstract void DataGets(object dataSource);

		/// <summary>
		/// Writes data to SLProtocol, Engine, or another data destination. (Optional.)
		/// </summary>
		/// <param name="dataDestination">SLProtocol, Engine, or another data destination.</param>
		public abstract void DataSets(object dataDestination);

		/// <summary>
		/// Modifies retrieved data and Message data into a correct format for setting. (Optional.)
		/// </summary>
		public abstract void Modify();

		/// <summary>
		/// Parses the data retrieved from a data source in DataGets. (Optional.)
		/// </summary>
		public abstract void Parse();

		/// <summary>
		/// Validates received data for validity before attempting parsing, modification and setting. Should return true if not used.
		/// </summary>
		/// <returns>A boolean indicating if the received data is valid.</returns>
		public abstract bool Validate();
	}
}