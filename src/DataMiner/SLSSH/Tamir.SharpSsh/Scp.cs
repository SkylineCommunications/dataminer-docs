/// <summary>
/// This namespace contains classes implementing SSH File Transfer Protocol (SFTP) and Secure Copy (SCP) functionality.
/// </summary>
/// <remarks>
/// <note type="note">
/// <para>This namespace is obsolete for SCP and SFTP implementations.Please refer to the following page for an alternative for such implementations: https://github.com/sshnet/SSH.NET.</para>
/// </note>
/// </remarks>
namespace Tamir.SharpSsh
{
	/// <summary>
	/// Provides functionality to communicate with a server via the Secure Copy Protocol (SCP).
	/// </summary>
	/// <example>
	/// <code>
	/// Scp scp = null;
	/// try
	/// {
	///		scp = new Scp("192.168.2.201", "user", "pw");
	///		scp.Timeout = 5 * 1000;
	///		scp.Connect();
	/// 
	///		if (scp.Connected)
	///		{ 
	///			scp.Get("path/to/remote/file", "path/to/local/file");
	///		}
	///	}
	///	catch(Exception e)
	///	{
	///		// Handle exception.
	///	}
	///	finally
	///	{
	///		if(scp != null)
	///		{
	///			scp.Close();
	///		}
	///	}
	///	</code>
	///	<code>
	///	Scp scp = null;
	/// try
	/// {
	///		scp = new Scp(host, userName);
	///		scp.AddIdentityFile(identityFile);
	///		scp.Timeout = 5000;
	///		scp.Connect();
	///	
	///		if (scp.Connected)
	///		{
	///			scp.Get(fileToDownLoad, downloadLocation);
	///		}
	///	}
	///	catch (Exception e)
	///	{
	///		// Handle exception.
	///	}
	///	finally
	///	{
	///		if(scp != null)
	///		{
	///			scp.Close();
	///		}
	///	}
	/// </code>
	/// </example>
	public class Scp : SshTransferProtocolBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Scp"/> class using the host, username and password.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="user">The username.</param>
		/// <param name="password">The password.</param>
		public Scp(string host, string user, string password)
		  : base(host, user, password)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Scp"/> class using the host and username.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="user">The username.</param>
		public Scp(string host, string user)
		  : base(host, user)
		{
		}

		/// <summary>
		/// Gets the channel type.
		/// </summary>
		/// <value>The channel type.</value>
		protected override string ChannelType
		{
			get;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the copy is recursive.
		/// </summary>
		/// <value><c>true</c> if recursive mode is enabled; otherwise, <c>false</c>.</value>
		public bool Recursive
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to preserve file attributes.
		/// </summary>
		/// <value><c>true</c> if the p switch is enabled (preserving modification times, access times, and modes from the original file.); otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>When uploading a file using the To method, by default, the -p switch is used ('Preserves modification times, access times, and modes from the original file.').</para>
		/// <para>This property allows to enable or disable this switch.</para>
		///	<para>Feature introduced in DataMiner 9.5.3 (RN 15080).</para>
		/// </remarks>
		/// <example>
		/// <para>The following example translates to: scp -t remotefilepath</para>
		/// <code>
		/// Scp scp = new Scp("host", "user", "password");
		/// scp.PreserveFileAttributes = false;
		/// scp.To("localfilepath", "remotefilepath");
		/// </code>
		/// <para>The following example translates to: scp -t -p remotefilepath</para>
		/// <code>
		/// Scp scp = new Scp("host", "user", "password");
		/// scp.PreserveFileAttributes = true;
		/// scp.To("localfilepath", "remotefilepath");
		/// </code>
		/// </example>
		public bool PreserveFileAttributes
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether verbose output is enabled.
		/// </summary>
		public bool Verbos
		{
			get;
			set;
		}

		/// <summary>
		/// Cancels the operation.
		/// </summary>
		public override void Cancel()
		{
		}

		/// <summary>
		/// Creates the specified directory.
		/// </summary>
		/// <param name="dir">The name of the directory to create.</param>
		/// <remarks>The file specified in dir will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public override void Mkdir(string dir)
		{
		}

		/// <summary>
		/// Copies the specified file from the server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <param name="toFilePath">The copied file path.</param>
		public override void Put(string fromFilePath, string toFilePath)
		{
		}

		/// <summary>
		/// Copies the specified file from the server to the specified folder.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <param name="toFilePath">The name of the local copy.</param>
		/// <exception cref="SshTransferException"><paramref name="fromFilePath"/> is not a directory.</exception>
		/// <remarks>The file specified in fromFilePath will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public override void Get(string fromFilePath, string toFilePath)
		{
		}

		/// <summary>
		/// Copies the specified file to the sever.
		/// </summary>
		/// <param name="localPath">The file to copy to the server.</param>
		/// <param name="remotePath">The name of the copied file.</param>
		/// <exception cref="SshTransferException">The file specified in <paramref name="localPath"/> was not found.</exception>
		/// <exception cref="SshTransferException">When copying directories, the recursive option must be set to true.</exception>
		/// <remarks>The remote path specified in remotePath will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public void To(string localPath, string remotePath)
		{
		}

		/// <summary>
		/// Copies the specified file to the sever.
		/// </summary>
		/// <param name="localPath">The file to copy to the server.</param>
		/// <param name="remotePath">The name of the copied file.</param>
		/// <param name="_recursive">Indicates whether items of the specified directory must be copied recursively.</param>
		/// <exception cref="SshTransferException">The file specified in <paramref name="localPath"/> was not found.</exception>
		/// <exception cref="SshTransferException">When copying directories, the recursive option must be set to true.</exception>
		/// <remarks>The remote path specified in remotePath will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public void To(string localPath, string remotePath, bool _recursive)
		{
		}

		/// <summary>
		/// Copies the specified file from the server to the specified folder.
		/// </summary>
		/// <param name="remoteFile">The file to copy.</param>
		/// <param name="localPath">The name of the local copy.</param>
		/// <exception cref="SshTransferException"><paramref name="localPath"/> is not a directory.</exception>
		/// <remarks>The file specified in remoteFile will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public void From(string remoteFile, string localPath)
		{
		}

		/// <summary>
		/// Copies the specified file from the server to the specified folder.
		/// </summary>
		/// <param name="remoteFile">The file to copy.</param>
		/// <param name="localPath">The name of the local copy.</param>
		/// <param name="_recursive">Value indicating whether the copy should be recursive.</param>
		/// <exception cref="SshTransferException"><paramref name="localPath"/> is not a directory.</exception>
		/// <remarks>The file specified in remoteFile will not be automatically enclosed in double quotes if it does not contain a space. (RN 14337)</remarks>
		public void From(string remoteFile, string localPath, bool _recursive)
		{
		}
	}
}