using System;
using Skyline.DataMiner.Storage.Types.DataTypes;
using SLLoggerUtil;
using SLLoggerUtil.LoggerCategoryUtil;

namespace Skyline.DataMiner.Net.LogHelpers
{
	/// <summary>
	/// Helper interface for logger in Elasticsearch.
	/// </summary>
	/// <remarks>Available from DataMiner 10.0.10 onwards (RN 26434).</remarks>
	/// <example>
	/// <code>
	///	public class Script
	///{
	///        private ILogHelper _log;
	///        private Engine _engine;
	///        private ResourceManagerHelper _rmHelper;
	///
	///        public void Run(Engine engine)
	///       {
	///           _engine = engine;
	///            _rmHelper = new ResourceManagerHelper();
	///           _rmHelper.RequestResponseEvent += (sender, args) => args.responseMessage = _engine.SendSLNetSingleResponseMessage(args.requestMessage);
	///
	///           // This call retrieves a connection object for the user running the script.
	///           // This ensures the lines are logged under the correct user.
	///           IConnection userConnection = engine.GetUserConnection();
	///
	///           // In a QAction, you can use the GetUserConnection() from the SLProtocol interface.
	///           // Create the log helper. Make sure it is always disposed!
	///           using (_log = LogHelper.Create(userConnection, "SRM"))
	///           {
	///               // This is logged under Category "Scripting.SRM" on LogLevel.Info.
	///               _log.Log.Info($"Starting booking validation.");
	///
	///               Guid reservationId = Guid.NewGuid();
	///               ValidateBooking(reservationId);
	///
	///               // Log lines are not instantly readable.
	///               _engine.Sleep(5000);
	///
	///               ExampleReadLogLines(reservationId);
	///           }
	///       }
	///
	///       private void ValidateBooking(Guid reservationId)
	///       {
	///            // The logger will now log under category "Scripting.ReservationInstanceID_c79d0529-6744-4fff-b102-2c62c9d30ebf"
	///           _log.ChangeSubjectId(new ReservationInstanceID(reservationId));
	///
	///           // By default, the log helper will only log Info and above (Info, Warning, Error, Fatal).
	///           // If needed, this can be changed. See examples below:
	///           // This enables logging for all levels, except for Trace (Debug, Info, Warning, Error, Fatal):
	///           // _log.ChangeLogLevel(LogLevel.Debug);
	///
	///           // This disables logging for all levels, except for Error and Fatal (Trace, Debug, Info)
	///           // _log.ChangeLogLevel(LogLevel.Error);
	///           _log.Log.Trace($"Starting Get Reservation Instance");
	///
	///           ReservationInstance reservation = _rmHelper.GetReservationInstance(reservationId);
	///
	///           _log.Log.Trace($"Ended Get Reservation Instance");
	///
	///           if (reservation == null)
	///           {
	///               _log.Log.Error($"Could not find the reservation instance.");
	///           }
	///           else
	///           {
	///               // By default the log level is "Info" which means this Debug logging will not be stored in the database
	///               _log.Log.Debug("Retrieved with name {0} and with status {1}", reservation.Name, reservation.Status);
	///           }
	///       }
	///
	///       private void ExampleReadLogLines(Guid reservationId)
	///       {
	///           ReservationInstanceID resId = new ReservationInstanceID(reservationId);
	///
	///           // Get all logs for a specific reservation.
	///           // Reading using implicit paging:
	///
	///           List&lt;LogEntry&gt; logs = _log.LogEntries.Read(LogEntry.Exposers.Name.Equal(resId.ToFileFriendlyString()).ToQuery());
	///
	///           foreach (LogEntry log in logs)
	///           {
	///                // Outputs: "(Implicit Paging) Found log: Could not find the reservation instance. at 6/23/2020 2:02:39 PM +02:00 by SKYLINE2\SvenDD on 668 for ReservationInstanceID_fa3317a7-e7be-4b95-9ae2-56e407c55d2d within Scripting"
	///               _engine.GenerateInformation($"(Implicit Paging) Found log: {log.Message} at {log.TimeStamp} by {log.UserName} on {log.DataMinerId} for {log.Name} within {log.Category}");
	///           }
	///
	///           // Reading using explicit paging
	///           PagingHelper&lt;LogEntry&gt; pagingHelper =
	///           _log.LogEntries.PreparePaging(LogEntry.Exposers.Name.Equal(resId.ToFileFriendlyString()).ToQuery(), 100);
	///
	///           while (pagingHelper.MoveToNextPage())
	///           {
	///               List&lt;LogEntry&gt; currentPage = pagingHelper.GetCurrentPage();
	///               foreach (LogEntry log in currentPage)
	///               {
	///                   // Outputs: "(Explicit Paged) Found log: Could not find the reservation instance. at 6/23/2020 2:02:39 PM +02:00 by SKYLINE2\SvenDD on 668 for ReservationInstanceID_fa3317a7-e7be-4b95-9ae2-56e407c55d2d within Scripting"
	///                   _engine.GenerateInformation($"(Explicit Paged) Found log: {log.Message} at {log.TimeStamp} by {log.UserName} on {log.DataMinerId} for {log.Name} within {log.Category}");
	///               }
	///           }
	///
	///           // Or reading using the Repository API
	///           // Use IDataSetRepository&lt;LogEntry&gt; repository = _log.LogEntries.RawRepository;
	///           // Getting all logs from today ordered by time
	///           DateTimeOffset now = DateTimeOffset.UtcNow;
	///
	///           DateTimeOffset midNight = new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, TimeSpan.Zero);
	///
	///           IQuery&lt;LogEntry&gt; filter = LogEntry.Exposers.Category.Equal(_log.Category.ToString())
	///           .AND(LogEntry.Exposers.TimeStamp.GreaterThanOrEqual(midNight)).ToQuery()
	///           .OrderBy(LogEntry.Exposers.TimeStamp);
	/// 
	///           List&lt;LogEntry&gt; scriptingLogs = _log.LogEntries.Read(filter);
	///
	///           foreach (LogEntry log in scriptingLogs)
	///           {
	///               // Outputs:
	///               //  - "(All Scripting Today) Found log: Starting booking validation. at 6/23/2020 2:00:03 PM +02:00 by SKYLINE2\SvenDD on 668 for SRM within Scripting"
	///               //  - "(All Scripting Today) Found log: Could not find the reservation instance. at 6/23/2020 2:00:03 PM +02:00 by SKYLINE2\SvenDD on 668 for ReservationInstanceID_e2b57e85-84a4-4d55-a15f-2b01b5070fd1 within Scripting"
	///               _engine.GenerateInformation($"(All Scripting Today) Found log: {log.Message} at {log.TimeStamp} by {log.UserName} on {log.DataMinerId} for {log.Name} within {log.Category}");
	///       }
	///   }
	///}
	/// </code>
	/// </example>
	public interface ILogHelper : IDisposable
	{
		/// <summary>
		/// Gets the logger category.
		/// </summary>
		/// <value>The logger category.</value>
		ILoggerCategory Category { get; }

		/// <summary>
		/// Gets the subject ID.
		/// </summary>
		/// <value>The subject ID.</value>
		/// <remarks>
		/// <para>Can be <see langword="null"/>.</para>
		/// <para>Will also fill in the <see cref="SubjectName"/> with <see cref="IDMAObjectRef.ToFileFriendlyString()"/></para>
		/// </remarks>
		IDMAObjectRef SubjectID { get; }

		/// <summary>
		/// Gets the subject name.
		/// </summary>
		/// <value>The subject name.</value>
		/// <remarks>
		/// <para>Filled in by default with the <see cref="IDMAObjectRef.ToFileFriendlyString()"/> of the <see cref="SubjectID"/>.</para>
		/// <para>Can also be custom filled in, then the <see cref="SubjectID"/> is <see langword="null"/>.</para>
		/// </remarks>
		string SubjectName { get; }

		/// <summary>
		/// Gets the log level.
		/// </summary>
		/// <value>The log level.</value>
		LogLevel LogLevel { get; }

		/// <summary>
		/// Gets the interval at which new <see cref="LogEntry"/> objects are flushed to the database.
		/// </summary>
		/// <value>The interval at which new <see cref="LogEntry"/> objects are flushed to the database.</value>
		TimeSpan FlushInterval { get; }

		/// <summary>
		/// Gets the max amount of LogEntries to keep in memory before doing a flush to database.
		/// </summary>
		/// <value>The max amount of LogEntries to keep in memory before doing a flush to database.</value>
		int MaxLogEntriesBeforeFlush { get; }

		/// <summary>
		/// Gets a value indicating whether LogEntries are flushed to database after upserting.
		/// </summary>
		/// <value>If set to <see langword="true" /> (default), the logger will wait for the database to respond after writing log entries to the database.
		/// If set to <see langword="false" />, the LogHelper will not wait for the database to respond after writing log entries to the database.</value>
		/// <remarks>
		/// <note type="note">
		/// <para>If you set this option to false, there are no guarantees that all log entries will get stored in the database, especially in case of e.g.connection issues or exceptions.</para>
		/// </note>
		/// <para>Feature introduced in DataMiner 10.2.0 (RN 28837).</para>
		/// </remarks>
		bool FlushToDatabaseAfterUpsert { get; }

		///<summary>Gets the logger instance</summary>
		/// <value>
		/// The logger instance, used to create new log entries that have to go into the database
		/// as <see cref="LogEntry"/> objects under the LoggerCategories.Scripting category.
		/// </value>
		ILogger Log { get; }

		/// <summary>
		/// Gets the log entries CRUD helper component.
		/// </summary>
		/// <value>The log entries CRUD helper component.</value>
		/// <remarks>
		/// Provides read access to the <see cref="LogEntry"/> objects in database.
		/// </remarks>
		ILogEntryCrudHelperComponent LogEntries { get; }

		/// <summary>
		/// Changes the log level to the specified log level.
		/// </summary>
		/// <param name="logLevel">The log level.</param>
		void ChangeLogLevel(LogLevel logLevel);

		/// <summary>
		/// Changes the subject ID.
		/// </summary>
		/// <param name="subjectId">The subject ID.</param>
		/// <exception cref="ArgumentNullException"><paramref name="subjectId"/> is <see langword="null" />.</exception>
		/// <remarks>
		/// Note: The LogHelper.Log object will be reconstructed when changing the subject ID.
		/// </remarks>
		void ChangeSubjectId(IDMAObjectRef subjectId);

		/// <summary>
		/// Changes the subject name to the specified subject name.
		/// </summary>
		/// <param name="subjectName">The subject name.</param>
		/// <remarks>
		/// Note: The LogHelper.Log object will be reconstructed when changing the subject name.
		/// </remarks>
		void ChangeSubjectName(string subjectName);

		/// <summary>
		/// Changes the flush interval to the specific flush interval.
		/// </summary>
		/// <param name="flushInterval">The flush interval.</param>
		void ChangeFlushInterval(TimeSpan flushInterval);

		/// <summary>
		/// Changes the maximum number of log entries before flush to the specified number.
		/// </summary>
		/// <param name="maxLogEntriesBeforeFlush">The maximum number of log entries before flush.</param>
		void ChangeMaxLogEntriesBeforeFlush(int maxLogEntriesBeforeFlush);

		/// <summary>
		/// Changes the flush to database after upsert configuration.
		/// </summary>
		/// <param name="flushToDatabaseAfterUpsert"><c>true</c> to flush to the database after upsert; otherwise, <c>false</c>.</param>
		/// <remarks>
		/// <para>Feature introduced in DataMiner 10.2.0 (RN 28837).</para>
		/// </remarks>
		/// <seealso cref="ILogHelper.FlushToDatabaseAfterUpsert"/>
		void ChangeFlushToDatabaseAfterUpsert(bool flushToDatabaseAfterUpsert);
	}
}