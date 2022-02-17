namespace Tamir.SharpSsh
{
	/// <summary>
	/// SSH based transfer protocol interface.
	/// </summary>
	public interface ITransferProtocol
	{
		/// <summary>
		/// Connects with the server on the default port (22).
		/// </summary>
		void Connect();

		/// <summary>
		/// Closes the connection.
		/// </summary>
		void Close();

		/// <summary>
		/// Cancels the operation.
		/// </summary>
		void Cancel();

		/// <summary>
		/// Copies the specified file from the SFTP server to the specified destination directory.
		/// </summary>
		/// <param name="fromFilePath">The file to retrieve.</param>
		/// <param name="toFilePath">The destination directory.</param>
		void Get(string fromFilePath, string toFilePath);

		/// <summary>
		/// Copies the specified file to the specified directory on the SFTP server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <param name="toFilePath">The directory to which the file should be copied.</param>
		void Put(string fromFilePath, string toFilePath);

		/// <summary>
		/// Creates the specified directory.
		/// </summary>
		/// <param name="directory">The directory to create.</param>
		void Mkdir(string directory);

		/// <summary>
		/// Occurs when the transfer starts.
		/// </summary>
		event FileTransferEvent OnTransferStart;

		/// <summary>
		/// Occurs when the transfer ends.
		/// </summary>
		event FileTransferEvent OnTransferEnd;

		/// <summary>
		/// Occurs when the transfer progress updates.
		/// </summary>
		event FileTransferEvent OnTransferProgress;
	}

	public delegate void FileTransferEvent(string src, string dst, int transferredBytes, int totalBytes, string message);
}