using System;
using Skyline.SSH;
using Tamir.SharpSsh.jsch;

namespace Tamir.SharpSsh
{
	/// <summary>
	/// SSH base class.
	/// </summary>
	public abstract class SshBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SshBase"/> class using the host, username and password.
		/// </summary>
		/// <param name="sftpHost">The host to connect to.</param>
		/// <param name="user">The username.</param>
		/// <param name="password">The password.</param>
		public SshBase(string sftpHost, string user, string password)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SshBase"/> class using the host and username.
		/// </summary>
		/// <param name="sftpHost">The host to connect to.</param>
		/// <param name="user">The username.</param>
		public SshBase(string sftpHost, string user)
		  : this(sftpHost, user, (string)null)
		{
		}

		/// <summary>
		/// Adds the specified identity file.
		/// </summary>
		/// <param name="privateKeyFile">The private key file.</param>
		public virtual void AddIdentityFile(string privateKeyFile)
		{
		}

		/// <summary>
		/// Adds the specified identity file and passphrase.
		/// </summary>
		/// <param name="privateKeyFile">The private key file.</param>
		/// <param name="passphrase">The passphrase.</param>
		public virtual void AddIdentityFile(string privateKeyFile, string passphrase)
		{
		}

		/// <summary>
		/// Gets the channel type.
		/// </summary>
		protected abstract string ChannelType { get; }

		/// <summary>
		/// Connects with the server on the default port (22).
		/// </summary>
		public virtual void Connect()
		{
		}

		/// <summary>
		/// Connects with the server on the specified port.
		/// </summary>
		/// <param name="tcpPort">The port to connect to.</param>
		/// <exception cref="JSchException"></exception>
		public virtual void Connect(int tcpPort)
		{
		}


		protected virtual void ConnectSession(int tcpPort)
		{
		}

		/// <summary>
		/// Adds the specified key exchange algorithm.
		/// </summary>
		/// <param name="kexAlgorithms">The hey exchange algorithm to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="kexAlgorithms"/> is <see langword="null"/>.</exception>
		public virtual void AddKexAlgorithms(string kexAlgorithms)
		{
		}

		/// <summary>
		/// Closes the connection.
		/// </summary>
		public virtual void Close()
		{
		}

		/// <summary>
		/// Gets a value indicating whether a connection is established.
		/// </summary>
		/// <value><c>true</c> if a connection is established; otherwise, <c>false</c>.</value>
		public virtual bool Connected
		{
			get;
		}

		/// <summary>
		/// Gets the Cipher.
		/// </summary>
		/// <value>The cipher.</value>
		public string Cipher
		{
			get;
		}

		/// <summary>
		/// Gets the Message Authentication Code (MAC).
		/// </summary>
		/// <value>The Message Authentication Code (MAC).</value>
		public string Mac
		{
			get;
		}

		/// <summary>
		/// Gets the server version.
		/// </summary>
		/// <value>The server version.</value>
		public string ServerVersion
		{
			get;
		}

		/// <summary>
		/// Gets the client version.
		/// </summary>
		/// <value>The client version.</value>
		public string ClientVersion
		{
			get;
		}

		/// <summary>
		/// Gets the host.
		/// </summary>
		/// <value>The host.</value>
		public string Host
		{
			get;
		}

		/// <summary>
		/// Gets the host key.
		/// </summary>
		/// <value>The host key.</value>
		public HostKey HostKey
		{
			get;
		}

		/// <summary>
		/// Gets the server port.
		/// </summary>
		/// <value>The server port.</value>
		public int Port
		{
			get;
		}

		/// <summary>
		/// Gets or sets the user password.
		/// </summary>
		/// <value>The user password.</value>
		public string Password
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the user name.
		/// </summary>
		/// <value>The user name.</value>
		public string Username
		{
			get;
		}

		/// <summary>
		/// Gets or sets the timeout value (in ms).
		/// </summary>
		/// <value>The timeout value (in ms).</value>
		public int Timeout { get; set; }

		/// <summary>
		/// Gets the assembly version.
		/// </summary>
		/// <value>The assembly version.</value>
		public static Version Version
		{
			get;
		}

		protected void HandleOnLogging(object sender, LoggingEventArgs e)
		{
		}

		/// <summary>
		/// Gets the most recent log entry.
		/// </summary>
		/// <returns>The most recent log entry.</returns>
		public LoggingEventArgs GetMostRecentLog()
		{
			return null;
		}

		/// <summary>
		/// Occurs when logging.
		/// </summary>
		public event EventHandler<LoggingEventArgs> OnLogging;
	}
}