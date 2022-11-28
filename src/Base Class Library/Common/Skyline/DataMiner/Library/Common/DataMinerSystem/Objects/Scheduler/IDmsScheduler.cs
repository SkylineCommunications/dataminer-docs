namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Skyline.DataMiner.Net.Scheduling;

	using SLDataGateway.API.Types.Tasks;

	/// <summary>
	/// Represents the DataMiner Scheduler component.
	/// </summary>
	public interface IDmsScheduler
	{
		/// <summary>
		/// Retrieves all tasks on this agent.
		/// </summary>
		/// <returns>The tasks.</returns>
		IEnumerable<IDmsSchedulerTask> GetTasks();

		/// <summary>
		/// Creates the specified task.
		/// Replaces: slScheduler.SetInfo(userCookie, TSI_CREATE (1), taskData, out response);.
		/// </summary>
		/// <param name="createData">Array of data as expected by old Interop call.</param>
		/// <returns>The ID of the created task.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="createData"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// var dms = protocol.GetDms();
		/// var dma = dms.GetAgent(protocol.DataMinerID);
		/// var scheduler = dma.Scheduler;
		///
		/// DateTime startDate = DateTime.Now.AddDays(5);
		/// DateTime endDate = DateTime.Now.AddDays(10);
		///
		/// string activStartDay = startDate.ToString("yyyy-MM-dd");
		/// string activStopDay = endDate.ToString("yyyy-MM-dd");
		///
		/// string startTime = startDate.ToString("HH:mm:ss");
		/// string endTime = endDate.ToString("HH:mm:ss");
		///
		/// string taskType = "once"; // Task type (1=once , 2=weekly, 3=monthly, 4=daily)
		/// string runInterval = "1"; // Run interval (x minutes(daily) / 1,...,31,101,102(monthly) / 1,3,5,7 (1=Monday, 7=Sunday)(weekly))
		///
		/// string scriptName = "scriptName";
		/// string elemLinked = ""; //"PROTOCOL:1:123:456", // example of linking element 123/456 to script dummy 1
		/// string paramLinked = "";
		/// string taskName = "SchedulerCreateTaskTest";
		/// string taskDescription = "Task description";
		///
		/// object[] schedulerTaskData = new object[] {
		/// new object[] {
		///		new string[] // general info
		///		{
		///			taskName, // [0] : name
		///			activStartDay, // [1] : start date (YYYY-MM-DD) (leave empty to have start time == current time)
		///			activStopDay, // [2] : end date (YYYY-MM-DD) (can be left empty)
		///			startTime, // [3] : start run time (HH:MM)
		///			taskType, // [4] : task type (daily / monthly / weekly / once)
		///			runInterval, // [5] : run interval (x minutes / 1,...,31,101,102 / 1,3,5,7 (1=Monday, 7=Sunday)) (101-112 -&gt; months)
		///			"", // [6] : # of repeats before final actions are executed
		///			taskDescription, // [7] : description
		///			"TRUE", // [8] : enabled (TRUE/FALSE)
		///			endTime, // [9] : end run time (HH:MM) (only affects daily tasks)
		///			"", // [10]: minutes interval for weekly/monthly tasks. Either an end date or a repeat count should be specified
		///		}
		///	},
		/// new object[] // repeat actions
		/// {
		///		new string[] {
		///			"automation", // action type
		///			scriptName, // name of automation script
		///			elemLinked, // example of linking element 123/456 to script dummy 1
		///			paramLinked, // ... other options &amp; further linking of dummies to elements can be added
		///			// elem2Linked,
		///			"CHECKSETS:FALSE",
		///			"DEFER:False", // run sync
		///		}
		/// },
		///	new object[] {} // final actions
		///	};
		/// </code>
		/// </example>
		int CreateTask(object[] createData);

		/// <summary>
		/// Updates the specified task.
		/// Replaces: slScheduler.SetInfo(userCookie, TSI_UPDATE (2), taskData, out response);
		/// </summary>
		/// <param name="updateData">Array of data as expected by old Interop call.</param>
		/// <returns>Returns 0 if successful.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="updateData"/> is <see langword="null"/>.</exception>
		/// <example>
		/// <code>
		/// int taskId = 100;
		/// string taskDescription = "Updated Task description";
		/// DateTime startDate = DateTime.Now.AddDays(5);
		/// DateTime endDate = DateTime.Now.AddDays(10);
		/// 
		/// string activStartDay = startDate.ToString("yyyy-MM-dd");
		/// string activStopDay = endDate.ToString("yyyy-MM-dd");
		/// 
		/// string startTime = startDate.ToString("HH:mm:ss");
		/// string endTime = endDate.ToString("HH:mm:ss");
		/// 
		/// string taskType = "once";   // Task type     (1=once , 2=weekly, 3=monthly, 4=daily)
		/// string runInterval = "1";   // Run interval  (x minutes(daily) / 1,...,31,101,102(mothly)   / 1,3,5,7 (1=monday, 7=sunday)(weekly))
		///
		/// string scriptName = "scriptName";
		/// string elemLinked = "";     //"PROTOCOL:1:123:456",   // example of linking element 123/456 to script dummy 1
		/// string paramLinked = "";
		///
		/// object[] schedulerTaskData = new object[]
		/// {
		///	/*
		/// varData => PPSA
		///
		/// [0][0][*] : general info
		/// 	  [0] : task id
		///		  [1] : name					(empty = no change)					
		///		  [2] : start date (YYYY-MM-DD) (empty = no change)
		///		  [3] : end date (YYYY-MM-DD)	(empty = no change)
		///		  [4] : start run time (HH:MM)	(empty = no change)
		///		  [5] : task type				(empty = no change)
		///		  [6] : run interval			(empty = no change)
		///		  [7] : # of repeats before final actions are executed (empty = no change)
		///		  [8] : description				(empty = no change)
		///		  [9] : enabled					(empty = no change / TRUE or FALSE)
		///		  [10]: End time	
		///		  [11]: minutes interval for weekly/monthly tasks 
		///	   [1][*]	  : repeated actions		([1][0][0] empty = don't change actions)
		/// 	  [0] : type
		///		  ... : extra info
		///    [2][*]    : final actions			([2][0][0] empty = don't change actions)
		///		  [0] : type
		///		  ... : extra info
		/// 
		/// result:
		///		E_FAIL/E_INVALIDARG
		/// 	S_OK
		/// */
		///		new object[]
		///		{
		///			new string[]    // general info
		///			{
		///				taskId.ToString(),               // [0] : task ID
		///				taskName,                        // [1] : name
		///				activStartDay,                   // [2] : start date (YYYY-MM-DD) (leave empty to have start time == current time)
		///				activStopDay,                    // [3] : end date (YYYY-MM-DD)      (can be left empty)
		///				startTime,                       // [4] : start run time (HH:MM)
		///				taskType,                        // [5] : task type     (daily   / monthly            / weekly /                      once)
		///				runInterval,                     // [6] : run interval  (x minutes / 1,...,31,101,102   / 1,3,5,7 (1=monday, 7=sunday)) (101-112 -> months)
		///				"",                              // [7] : # of repeats before final actions are executed
		///				taskDescription,				 // [8] : description
		///				"TRUE",                          // [9] : enabled (TRUE/FALSE)
		///				endTime,                         // [10] : end run time (HH:MM) (only affects daily tasks)       
		///				""                               // [11]: minutes interval for weekly/monthly tasks either an enddate or a repeat count should be specified
		///			}
		///		},
		///		new object[]  // repeat actions
		///		{
		///			//new string[]
		///			//{
		///			//	"automation",           // action type 
		///			//	scriptName,             // name of automation script
		///			//	elemLinked,             // example of linking element 123/456 to script dummy 1
		///			//	paramLinked,            // ... other options &amp; further linking of dummies to elements can be added
		///			//	// elem2Linked,
		///			//	"CHECKSETS:FALSE",
		///			//	"DEFER:False",			// run sync
		///			//}
		///		},
		///		new object[] {} // final actions
		/// };
		///
		/// int returnValue = scheduler.UpdateTask(schedulerTaskData);
		/// </code>
		/// </example>
		int UpdateTask(object[] updateData);

		/// <summary>
		/// Deletes the task with the specified ID.
		/// Replaces: slScheduler.SetInfo(userCookie, TSI_DELETE (3), Convert.ToUInt32(TaskId), out response);
		/// </summary>
		/// <param name="taskId">The ID of the task to be deleted.</param>
		/// <returns>Returns 0 if successful.</returns>
		int DeleteTask(int taskId);

		/// <summary>
		/// Retrieves the Scheduler status.
		/// Replaces: slScheduler.GetInfo(userCookie, TSI_STATUS (13), out response);
		/// </summary>
		/// <example>
		/// <code>
		/// IDms myDms = protocol.GetDms();
		/// IDma myDma = myDms.GetAgent(protocol.DataMinerID);
		/// IDmsScheduler scheduler = myDma.Scheduler;
		///
		/// var tasksStatus = scheduler.GetStatus() as Object[];
		///
		/// foreach (var taskStatus in tasksStatus)
		///	{
		///		var taskStatusInfo = (string[])taskStatus;
		///
		///		string name = taskStatusInfo[0];
		///		string status = taskStatusInfo[1]; // Running/Pending/Finished
		///		string lastResult = taskStatusInfo[2];
		///		string nextRunTime = taskStatusInfo[3]; // "YYYY-MM-DD HH:MM:SS"
		///		string lastRunTime = taskStatusInfo[4]; // "YYYY-MM-DD HH:MM:SS"
		///		string lastRunTimeCode = taskStatusInfo[5]; // "0" - undefined, "1" - OK, "2" - Warning, "3" - Failed string
		/// }
		/// </code>
		/// </example>
		object GetStatus();
	}
}