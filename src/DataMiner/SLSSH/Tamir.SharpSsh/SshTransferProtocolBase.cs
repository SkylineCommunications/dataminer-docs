namespace Tamir.SharpSsh
{
	/// <summary>
	/// Base class for transfer protocols using SSH.
	/// </summary>
	public abstract class SshTransferProtocolBase : SshBase, ITransferProtocol
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SshTransferProtocolBase"/> class using the host, username and password.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="user">The username.</param>
		/// <param name="password">The password.</param>
		public SshTransferProtocolBase(string host, string user, string password)
		  : base(host, user, password)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SshTransferProtocolBase"/> class using the host and username.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="user">The username.</param>
		public SshTransferProtocolBase(string host, string user)
		  : base(host, user)
		{
		}

		/// <summary>
		/// Copies the specified file from the SFTP server to the specified destination directory.
		/// </summary>
		/// <param name="fromFilePath">The file to retrieve.</param>
		/// <param name="toFilePath">The destination directory.</param>
		public abstract void Get(string fromFilePath, string toFilePath);

		/// <summary>
		/// Copies the specified file to the specified directory on the SFTP server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <param name="toFilePath">The directory to which the file should be copied.</param>
		public abstract void Put(string fromFilePath, string toFilePath);

		/// <summary>
		/// Creates the specified directory.
		/// </summary>
		/// <param name="directory">The directory to create.</param>
		public abstract void Mkdir(string directory);

		/// <summary>
		/// Cancels the operation.
		/// </summary>
		public abstract void Cancel();

		/// <summary>
		/// Occurs when the transfer starts.
		/// </summary>
		public event FileTransferEvent OnTransferStart;

		/// <summary>
		/// Occurs when the transfer ends.
		/// </summary>
		public event FileTransferEvent OnTransferEnd;

		/// <summary>
		/// Occurs when the transfer progress updates.
		/// </summary>
		public event FileTransferEvent OnTransferProgress;
	}
}