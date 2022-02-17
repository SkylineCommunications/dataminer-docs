namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Linq;

	using Skyline.DataMiner.Net.Messages;

	/// <summary>
	///     Represents the Security settings linked to SNMPv3.
	/// </summary>
	public class SnmpV3SecurityConfig : ConnectionSettings, ISnmpV3SecurityConfig
	{
		private SnmpV3AuthenticationAlgorithm authenticationAlgorithm;

		private string authenticationKey;

		private SnmpV3EncryptionAlgorithm encryptionAlgorithm;

		private string encryptionKey;

		private SnmpV3SecurityLevelAndProtocol securityLevelAndProtocol;

		private string username;

		/// <summary>
		///     Initializes a new instance using No Authentication and No Privacy.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <exception cref="System.ArgumentNullException">When the username is null.</exception>
		public SnmpV3SecurityConfig(string username)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}

			this.securityLevelAndProtocol = SnmpV3SecurityLevelAndProtocol.NoAuthenticationNoPrivacy;
			this.username                 = username;
			this.authenticationKey        = string.Empty;
			this.encryptionKey            = string.Empty;
			this.authenticationAlgorithm  = SnmpV3AuthenticationAlgorithm.None;
			this.encryptionAlgorithm      = SnmpV3EncryptionAlgorithm.None;
		}

		/// <summary>
		///     Initializes a new instance using Authentication No Privacy.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="authenticationKey">The Authentication key.</param>
		/// <param name="authenticationAlgorithm">The Authentication Algorithm.</param>
		/// <exception cref="System.ArgumentNullException">When username, authenticationKey is null.</exception>
		/// <exception cref="IncorrectDataException">
		///     When None or DefinedInCredentialsLibrary is selected as authentication
		///     algorithm.
		/// </exception>
		public SnmpV3SecurityConfig(
			string username,
			string authenticationKey,
			SnmpV3AuthenticationAlgorithm authenticationAlgorithm)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}

			if (authenticationKey == null)
			{
				throw new ArgumentNullException("authenticationKey");
			}

			if (authenticationAlgorithm == SnmpV3AuthenticationAlgorithm.None
			    || authenticationAlgorithm == SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary)
			{
				throw new IncorrectDataException(
					"Authentication Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication No Privacy' as Security Level and Protocol.");
			}

			this.securityLevelAndProtocol = SnmpV3SecurityLevelAndProtocol.AuthenticationNoPrivacy;
			this.username                 = username;
			this.authenticationKey        = authenticationKey;
			this.encryptionKey            = string.Empty;
			this.authenticationAlgorithm  = authenticationAlgorithm;
			this.encryptionAlgorithm      = SnmpV3EncryptionAlgorithm.None;
		}

		/// <summary>
		///     Initializes a new instance using Authentication and Privacy.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="authenticationKey">The authentication key.</param>
		/// <param name="encryptionKey">The encryptionKey.</param>
		/// <param name="authenticationProtocol">The authentication algorithm.</param>
		/// <param name="encryptionAlgorithm">The encryption algorithm.</param>
		/// <exception cref="System.ArgumentNullException">When username, authenticationKey or encryptionKey is null.</exception>
		/// <exception cref="IncorrectDataException">
		///     When None or DefinedInCredentialsLibrary is selected as authentication
		///     algorithm or encryption algorithm.
		/// </exception>
		public SnmpV3SecurityConfig(
			string username,
			string authenticationKey,
			SnmpV3AuthenticationAlgorithm authenticationProtocol,
			string encryptionKey,
			SnmpV3EncryptionAlgorithm encryptionAlgorithm)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}

			if (authenticationKey == null)
			{
				throw new ArgumentNullException("authenticationKey");
			}

			if (encryptionKey == null)
			{
				throw new ArgumentNullException("encryptionKey");
			}

			if (authenticationProtocol == SnmpV3AuthenticationAlgorithm.None
			    || authenticationProtocol == SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary)
			{
				throw new IncorrectDataException(
					"Authentication Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication No Privacy' as Security Level and Protocol.");
			}

			if (encryptionAlgorithm == SnmpV3EncryptionAlgorithm.None
			    || encryptionAlgorithm == SnmpV3EncryptionAlgorithm.DefinedInCredentialsLibrary)
			{
				throw new IncorrectDataException(
					"Encryption Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication and Privacy' as Security Level and Protocol.");
			}

			this.securityLevelAndProtocol = SnmpV3SecurityLevelAndProtocol.AuthenticationPrivacy;
			this.username                 = username;
			this.authenticationKey        = authenticationKey;
			this.encryptionKey            = encryptionKey;
			this.authenticationAlgorithm  = authenticationProtocol;
			this.encryptionAlgorithm      = encryptionAlgorithm;
		}

		/// <summary>
		///     Default empty constructor
		/// </summary>
		public SnmpV3SecurityConfig()
		{
		}

		/// <summary>
		///     Initializes a new instance.
		/// </summary>
		/// <param name="securityLevelAndProtocol">The security Level and Protocol.</param>
		/// <param name="username">The username.</param>
		/// <param name="authenticationKey">The authenticationKey</param>
		/// <param name="encryptionKey">The encryptionKey</param>
		/// <param name="authenticationAlgorithm">The authentication Algorithm.</param>
		/// <param name="encryptionAlgorithm">The encryption Algorithm.</param>
		/// <exception cref="System.ArgumentNullException">When username, authenticationKey or encryptionKey is null.</exception>
		internal SnmpV3SecurityConfig(
			SnmpV3SecurityLevelAndProtocol securityLevelAndProtocol,
			string username,
			string authenticationKey,
			string encryptionKey,
			SnmpV3AuthenticationAlgorithm authenticationAlgorithm,
			SnmpV3EncryptionAlgorithm encryptionAlgorithm)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}

			if (authenticationKey == null)
			{
				throw new ArgumentNullException("authenticationKey");
			}

			if (encryptionKey == null)
			{
				throw new ArgumentNullException("encryptionKey");
			}

			this.securityLevelAndProtocol = securityLevelAndProtocol;
			this.username                 = username;
			this.authenticationKey        = authenticationKey;
			this.encryptionKey            = encryptionKey;
			this.authenticationAlgorithm  = authenticationAlgorithm;
			this.encryptionAlgorithm      = encryptionAlgorithm;
		}

		/// <summary>
		///     Gets or sets the AuthenticationProtocol.
		/// </summary>
		public SnmpV3AuthenticationAlgorithm AuthenticationAlgorithm
		{
			get
			{
				return this.authenticationAlgorithm;
			}

			set
			{
				if (this.authenticationAlgorithm != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.AuthenticationProtocol);
					this.authenticationAlgorithm = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets the AuthenticationKey.
		/// </summary>
		public string AuthenticationKey
		{
			get
			{
				return this.authenticationKey;
			}

			set
			{
				if (this.AuthenticationKey != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.AuthenticationKey);
					this.authenticationKey = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets the EncryptionAlgorithm.
		/// </summary>
		public SnmpV3EncryptionAlgorithm EncryptionAlgorithm
		{
			get
			{
				return this.encryptionAlgorithm;
			}

			set
			{
				if (this.encryptionAlgorithm != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.EncryptionAlgorithm);
					this.encryptionAlgorithm = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets the EncryptionKey.
		/// </summary>
		public string EncryptionKey
		{
			get
			{
				return this.encryptionKey;
			}

			set
			{
				if (this.encryptionKey != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.EncryptionKey);
					this.encryptionKey = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets the SecurityLevelAndProtocol.
		/// </summary>
		public SnmpV3SecurityLevelAndProtocol SecurityLevelAndProtocol
		{
			get
			{
				return this.securityLevelAndProtocol;
			}

			set
			{
				if (this.securityLevelAndProtocol != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.SecurityLevelAndProtocol);
					this.securityLevelAndProtocol = value;
				}
			}
		}

		/// <summary>
		///     Gets or sets the username.
		/// </summary>
		public string Username
		{
			get
			{
				return this.username;
			}

			set
			{
				if (this.username != value)
				{
					this.ChangedPropertyList.Add(ConnectionSetting.Username);
					this.username = value;
				}
			}
		}
	}
}