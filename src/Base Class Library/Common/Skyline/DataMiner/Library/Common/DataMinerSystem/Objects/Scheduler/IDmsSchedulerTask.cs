namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Represents a Scheduler Task.
	/// </summary>
	public interface IDmsSchedulerTask
	{
		/// <summary>
		/// Gets a value indicating whether to choose the Agent.
		/// </summary>
		/// <value><c>true</c> to choose Agent; otherwise, <c>false</c>.</value>
		bool ChooseAgent { get; }

		/// <summary>
		/// Gets the description of the task.
		/// </summary>
		/// <value>The description of the task.</value>
		string Description { get; }

		/// <summary>
		/// Gets a value indicating whether the task is enabled.
		/// </summary>
		/// <value><c>true</c> if the task is enabled; otherwise, <c>false</c>.</value>
		bool IsEnabled { get; }

		/// <summary>
		/// Gets the end time of the task.
		/// </summary>
		/// <value>The end time of the task.</value>
		DateTime EndTime { get; }

		/// <summary>
		/// Gets a value indicating whether the task has run.
		/// </summary>
		/// <value><c>true</c> if the task has run; otherwise, <c>false</c>.</value>
		int HasRun { get; }

		/// <summary>
		/// Gets a value indicating whether the task is finished.
		/// </summary>
		/// <value><c>true</c> if the task is finished; otherwise, <c>false</c>.</value>
		bool IsFinished { get; }

		/// <summary>
		/// Gets the ID of the Agent that is handling the task.
		/// </summary>
		/// <value>The ID of the Agent that is handling the task.</value>
		int HandlingAgentId { get; }

		/// <summary>
		/// Gets the ID of the task.
		/// </summary>
		/// <value>The ID of the task.</value>
		int Id { get; }

		/// <summary>
		/// Get the result of the last run.
		/// </summary>
		/// <value>The result of the last run.</value>
		string LastRunResult { get; }

		/// <summary>
		/// Get the time it took for the last run.
		/// </summary>
		/// <value>The time it took for the last run.</value>
		string LastRunTime { get; }

		/// <summary>
		/// Gets the time until the next run.
		/// </summary>
		/// <value>The time until the next run.</value>
		string NextRunTime { get; }

		/// <summary>
		/// Gets the number of repetitions of this task.
		/// </summary>
		/// <value>The number of repetitions of this task.</value>
		int Repetitions { get; }

		/// <summary>
		/// Gets the repetition interval.
		/// </summary>
		/// <value>The repetition interval.</value>
		string RepetitionInterval { get; }

		/// <summary>
		/// Gets the repetition interval expressed in minutes.
		/// </summary>
		/// <value>The repetition interval expressed in minutes.</value>
		string RepetitionIntervalInMinutes { get; }

		/// <summary>
		/// Gets a value indicating whether the task is visible.
		/// </summary>
		/// <value><c>true</c> if the task is visible; otherwise, <c>false</c>.</value>
		bool Show { get; }

		/// <summary>
		/// Gets the start time of the task.
		/// </summary>
		/// <value>The start time of the task.</value>
		DateTime StartTime { get; }

		/// <summary>
		/// Gets the name of the task.
		/// </summary>
		/// <value>The name of the task.</value>
		string TaskName { get; }

		/// <summary>
		/// Gets the repetition type.
		/// </summary>
		/// <value>The repetition type.</value>
		DmsSchedulerRepetitionType RepetitionType { get; }
	}
}