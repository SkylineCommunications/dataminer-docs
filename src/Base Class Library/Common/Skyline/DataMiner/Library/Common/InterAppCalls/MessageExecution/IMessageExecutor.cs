namespace Skyline.DataMiner.Library.Common.InterAppCalls.MessageExecution
{
	using CallSingle;

	/// <summary>
	/// Represents an executor for messages. Command pattern: splits the logic into well defined methods but leaves internal logic for the concrete classes.
	/// </summary>
	public interface IMessageExecutor
	{
		/// <summary>
		/// Creates a return message. (Optional.)
		/// </summary>
		/// <returns>A message representing the response for the processed message.</returns>
		Message CreateReturnMessage();

		/// <summary>
		/// Reads data from SLProtocol, Engine or other data sources. (Optional.)
		/// </summary>
		/// <param name="dataSource">SLProtocol, Engine, or other data sources.</param>
		void DataGets(object dataSource);

		/// <summary>
		/// Writes data to SLProtocol, Engine, or another data destination. (Optional.)
		/// </summary>
		/// <param name="dataDestination">SLProtocol, Engine, or another data destination.</param>
		void DataSets(object dataDestination);

		/// <summary>
		/// Modifies retrieved data and message data into a correct format for setting. (Optional.)
		/// </summary>
		void Modify();

		/// <summary>
		/// Parses the data retrieved from a data source in DataGets. (Optional.)
		/// </summary>
		void Parse();

		/// <summary>
		/// Validates received data for validity before attempting parsing, modification and setting. Should return true if not used.
		/// </summary>
		/// <returns>A boolean indicating if the received data is valid.</returns>
		bool Validate();
	}
}