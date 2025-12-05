using System;
using System.Collections;
using System.IO;
using System.Timers;
using Tamir.SharpSsh.jsch;

namespace Tamir.SharpSsh
{
	/// <summary>
	/// Provides functionality to communicate with a server via the SSH File Transfer Protocol (SFTP).
	/// </summary>
	/// <example>
	/// <code>
	/// Sftp sftp;
	/// try
	/// {
	///		sftp = new Sftp(host, userName);
	///
	///		if (authenticationMethod == AuthenticationType.Password)
	///		{
	///			sftp.Password = connInfo.password;
	///		}
	///		else if (File.Exists(identityFile) &amp;&amp; authenticationMethod == AuthenticationType.IdentityFile)
	///		{				
	///			sftp.AddIdentityFile(identityFile);				
	///		}
	/// 
	///		sftp.Timeout = 5000;
	///		sftp.Connect(connInfo.port);
	///		var files = sftp.GetFileList(FilePath);
	///		sftp.Close();
	///	}
	///	catch (Exception e)
	/// {
	///		// Handle exception.
	/// }
	/// finally
	/// {
	///		if (sftp != null)
	///		{
	///			sftp.Close();
	///		}
	/// }
	/// </code>
	/// </example>
	public class Sftp : SshTransferProtocolBase
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Sftp"/> class using the host name, username and password.
		/// </summary>
		/// <param name="sftpHost">The name of the host.</param>
		/// <param name="user">The username.</param>
		/// <param name="password">The password.</param>
		public Sftp(string sftpHost, string user, string password)
		  : base(sftpHost, user, password)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Sftp"/> class using the host name and username.
		/// </summary>
		/// <param name="sftpHost">The name of the host.</param>
		/// <param name="user">The username.</param>
		public Sftp(string sftpHost, string user)
		  : base(sftpHost, user)
		{
		}

		/// <summary>
		/// Gets the channel type.
		/// </summary>
		protected override string ChannelType
		{
			get;
		}

		private ChannelSftp SftpChannel
		{
			get;
		}

		/// <summary>
		/// Cancels the operation.
		/// </summary>
		public override void Cancel()
		{
		}

		/// <summary>
		/// Copies the specified file from the SFTP server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <exception cref="SftpException"></exception>
		public void Get(string fromFilePath)
		{
		}

		/// <summary>
		/// Copies the specified files from the SFTP server.
		/// </summary>
		/// <param name="fromFilePaths">The files to copy.</param>
		/// <exception cref="SftpException"></exception>
		public void Get(string[] fromFilePaths)
		{
		}

		/// <summary>
		/// Copies the specified files from the SFTP server to the specified destination directory.
		/// </summary>
		/// <param name="fromFilePaths">The files to copy.</param>
		/// <param name="toDirPath">The destination directory.</param>
		/// <exception cref="SftpException"></exception>
		public void Get(string[] fromFilePaths, string toDirPath)
		{
		}

		/// <summary>
		/// Copies the specified file from the SFTP server to the specified destination directory.
		/// </summary>
		/// <param name="fromFilePath">The file to retrieve.</param>
		/// <param name="toFilePath">The destination directory.</param>
		/// <exception cref="SftpException"></exception>
		public override void Get(string fromFilePath, string toFilePath)
		{
		}

		/// <summary>
		/// Copies the specified file to the SFTP server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy to the SFTP server.</param>
		/// <exception cref="SftpException"></exception>
		public void Put(string fromFilePath)
		{
		}

		/// <summary>
		/// Copies the specified files to the SFTP server.
		/// </summary>
		/// <param name="fromFilePaths">The files to copy.</param>
		/// <exception cref="SftpException"></exception>
		public void Put(string[] fromFilePaths)
		{
		}

		/// <summary>
		/// Copies the specified files to the specified directory on the SFTP server.
		/// </summary>
		/// <param name="fromFilePaths">The files to copy.</param>
		/// <param name="toDirPath">The directory to which the files should be copied.</param>
		/// <remarks>The directory must already exists.</remarks>
		/// <exception cref="SftpException"></exception>
		public void Put(string[] fromFilePaths, string toDirPath)
		{
		}

		/// <summary>
		/// Copies the specified file to the specified directory on the SFTP server.
		/// </summary>
		/// <param name="fromFilePath">The file to copy.</param>
		/// <param name="toFilePath">The directory to which the file should be copied.</param>
		/// <exception cref="SftpException"></exception>
		public override void Put(string fromFilePath, string toFilePath)
		{
		}

		/// <summary>
		/// Creates the specified directory.
		/// </summary>
		/// <param name="directory">The directory to create.</param>
		/// <exception cref="SftpException">The specified directory already exists.</exception>
		public override void Mkdir(string directory)
		{
		}

		/// <summary>
		/// Retrieves the files in the specified directory.
		/// </summary>
		/// <param name="path">The directory path.</param>
		/// <returns>The files in the specified directory.</returns>
		/// <exception cref="SftpException">The specified directory does not exist.</exception>
		public ArrayList GetFileList(string path)
		{
			return null;
		}

		/// <summary>
		/// Retrieves the time the file has last been modified.
		/// </summary>
		/// <param name="path">The file for which the last modified time should be retrieved.</param>
		/// <param name="fileNameComparisonMethod">The file name comparison method.</param>
		/// <returns>The time the file has last been modified.</returns>
		public string GetFileLastModifiedTime(string path, StringComparison fileNameComparisonMethod = StringComparison.InvariantCultureIgnoreCase)
		{
			return string.Empty;
		}
	}
}