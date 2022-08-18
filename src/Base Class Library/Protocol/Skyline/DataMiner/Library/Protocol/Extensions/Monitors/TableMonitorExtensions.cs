namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using System;

	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Defines extension methods on <see cref="IDmsTable"/> for monitoring.
	/// </summary>
	public static class TableMonitorExtensions
	{
#pragma warning disable S3242 // Method parameters should be declared with base types
		/// <summary>
		///  Starts monitoring table changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="table">The table to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="primaryKeyColumnIdx">The IDX of the table index column.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="table"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="primaryKeyColumnIdx "/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartValueMonitor(this IDmsTable table, SLProtocol protocol, int primaryKeyColumnIdx, Action<TableValueChange> onChange)
#pragma warning restore S3242 // Method parameters should be declared with base types
		{
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (primaryKeyColumnIdx < 0)
			{
				throw new ArgumentOutOfRangeException("primaryKeyColumnIdx");
			}

			if (onChange == null)
			{
				throw new ArgumentNullException("onChange");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);

			Param selection = new Param(table.Element.AgentId, table.Element.Id, table.Id);
			var monitor = new TableValueMonitor(table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(primaryKeyColumnIdx, onChange);
		}

		/// <summary>
		/// Stops monitoring value changes of the specified table.
		/// </summary>
		/// <param name="table">The table to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		public static void StopValueMonitor(this IDmsTable table, SLProtocol protocol, bool force = false)
		{
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Param selection = new Param(table.Element.AgentId, table.Element.Id, table.Id);
			var monitor = new TableValueMonitor(table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}
	}
}
