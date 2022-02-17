using Skyline.DataMiner.Net.Messages.SLDataGateway;
using SLLoggerUtil;
using System;

namespace Skyline.DataMiner.Storage.Types.DataTypes
{
	/// <summary>
	/// Represents a log entry.
	/// </summary>
	[Serializable]
	public class LogEntry : DataType, IEquatable<LogEntry>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LogEntry"/> class.
		/// </summary>
		/// <param name="timeStamp">The timestamp.</param>
		/// <param name="message">The message.</param>
		/// <param name="logLevel">The log level.</param>
		/// <param name="category">The category.</param>
		/// <param name="name">The name.</param>
		/// <param name="dataMinerId">The DataMiner agent ID.</param>
		/// <param name="processId">The process ID.</param>
		/// <param name="processName">The process name.</param>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userName">The user name.</param>
		public LogEntry(
		  DateTimeOffset timeStamp,
		  string message,
		  LogLevel logLevel,
		  string category,
		  string name,
		  int dataMinerId,
		  int processId,
		  string processName,
		  int threadId,
		  string userName)
		{
			this.Id = Guid.NewGuid();
			this.TimeStamp = timeStamp;
			this.Message = message;
			this.LogLevel = logLevel;
			this.Category = category;
			this.Name = name;
			this.DataMinerId = dataMinerId;
			this.ProcessId = processId;
			this.ProcessName = processName;
			this.ThreadId = threadId;
			this.UserName = userName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogEntry"/> class.
		/// </summary>
		public LogEntry()
		{
		}

		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value>The ID.</value>
		public Guid Id { get; private set; }

		/// <summary>
		/// Gets the timestampe.
		/// </summary>
		/// <value>The timestamp.</value>
		public DateTimeOffset TimeStamp { get; private set; }

		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; private set; }

		/// <summary>
		/// Gets the log level.
		/// </summary>
		/// <value>The log level.</value>
		public SLLoggerUtil.LogLevel LogLevel { get; private set; }

		/// <summary>
		/// Gets the category.
		/// </summary>
		/// <value>The category.</value>
		public string Category { get; private set; }

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the full name.
		/// </summary>
		/// <value>The full name.</value>
		public string FullName
		{
			get;
		}

		/// <summary>
		/// Gets the DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int DataMinerId { get; private set; }

		/// <summary>
		/// Gets the process ID.
		/// </summary>
		/// <value>The process ID.</value>
		public int ProcessId { get; private set; }

		/// <summary>
		/// Gets the process name.
		/// </summary>
		/// <value>The process name.</value>
		public string ProcessName { get; private set; }

		/// <summary>
		/// Gets the thread ID.
		/// </summary>
		/// <value>The thread ID.</value>
		public int ThreadId { get; private set; }

		/// <summary>
		/// Gets the user name.
		/// </summary>
		/// <value>The uesr name.</value>
		public string UserName { get; private set; }


		public bool FromMigration { get; set; }

		/// <summary>
		/// Gets the data type ID.
		/// </summary>
		/// <value>The data type ID.</value>
		public string DataTypeID
		{
			get
			{
				return this.Id.ToString("N");
			}
		}

		public FilterElement<T> ToFilter<T>()
		{
			return null;
		}

		/// <inheritdoc />
		public string[] ToStringArray()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public object[] ToInterOp()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public DataType toType(string[] data)
		{
			throw new NotImplementedException();
		}

		public bool Equals(LogEntry other)
		{
			if (other == null)
				return false;
			return this == other || this.Id.Equals(other.Id);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (this == obj)
				return true;
			return obj.GetType() == this.GetType() && this.Equals((LogEntry)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		public class Exposers
		{
			/// <summary>
			/// ID exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, Guid> Id;

			/// <summary>
			/// Timestamp exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, DateTimeOffset> TimeStamp = new Exposer<LogEntry, DateTimeOffset>((Func<LogEntry, DateTimeOffset>)(x => x.TimeStamp), new string[1]
			{
		nameof (TimeStamp)
			});
			/// <summary>
			/// Message exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> Message = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.Message), new string[1]
			{
		nameof (Message)
			});
			/// <summary>
			/// Log level name exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> LogLevelName = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.LogLevel.Name), new string[1]
			{
		"LogLevel.Name"
			});
			/// <summary>
			/// Log level exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, int> LogLevel = new Exposer<LogEntry, int>((Func<LogEntry, int>)(x => x.LogLevel.Level), new string[1]
			{
		"LogLevel.Level"
			});
			/// <summary>
			/// Category exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> Category = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.Category), new string[1]
			{
		nameof (Category)
			});
			/// <summary>
			/// Name exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> Name = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.Name), new string[1]
			{
		nameof (Name)
			});
			/// <summary>
			/// Full name exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> FullName = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.FullName), new string[1]
			{
		nameof (FullName)
			});
			/// <summary>
			/// DataMiner Agent ID exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, int> DataMinerId = new Exposer<LogEntry, int>((Func<LogEntry, int>)(x => x.DataMinerId), new string[1]
			{
		nameof (DataMinerId)
			});
			/// <summary>
			/// Process ID exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, int> ProcessId = new Exposer<LogEntry, int>((Func<LogEntry, int>)(x => x.ProcessId), new string[1]
			{
		nameof (ProcessId)
			});
			/// <summary>
			/// Process name exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> ProcessName = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.ProcessName), new string[1]
			{
		nameof (ProcessName)
			});
			/// <summary>
			/// Thread ID exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, int> ThreadId = new Exposer<LogEntry, int>((Func<LogEntry, int>)(x => x.ThreadId), new string[1]
			{
		nameof (ThreadId)
			});
			/// <summary>
			/// User name exposer.
			/// </summary>
			public static readonly Exposer<LogEntry, string> UserName = new Exposer<LogEntry, string>((Func<LogEntry, string>)(x => x.UserName), new string[1]
			{
		nameof (UserName)
			});
		}
	}
}
