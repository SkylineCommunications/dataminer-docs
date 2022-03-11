namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;

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
		int CreateTask(object[] createData);

		/// <summary>
		/// Updates the specified task.
		/// Replaces: slScheduler.SetInfo(userCookie, TSI_UPDATE (2), taskData, out response);
		/// </summary>
		/// <param name="updateData">Array of data as expected by old Interop call.</param>
		/// <returns>Returns 0 if successful.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="updateData"/> is <see langword="null"/>.</exception>
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
		object GetStatus();
	}
}