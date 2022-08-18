namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	using System;

	/// <summary>
	/// Defines extension methods on the <see cref="IDmsColumn"/> class for monitoring.
	/// </summary>
	public static class ColumnMonitorExtensions
	{
		/// <summary>
		///  Starts monitoring alarm level changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="column">The column of the cell to monitor.</param>
		/// <param name="primaryKey">The primary key of the cell to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="column"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="primaryKey"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartAlarmLevelMonitor(this IDmsColumn column, string primaryKey, SLProtocol protocol, Action<CellAlarmLevelChange> onChange)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			if (String.IsNullOrWhiteSpace(primaryKey))
			{
				throw new ArgumentNullException("primaryKey");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (onChange == null)
			{
				throw new ArgumentNullException("onChange");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);

			Cell selection = new Cell(column.Table.Element.AgentId, column.Table.Element.Id, column.Table.Id, column.Id, primaryKey);
			CellAlarmLevelMonitor monitor = new CellAlarmLevelMonitor(column.Table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onChange);
		}

#pragma warning disable S3242 // Method parameters should be declared with base types
		/// <summary>
		///  Starts monitoring value changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="column">The column of the cell to monitor.</param>
		/// <param name="primaryKey">The primary key of the cell to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="column"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="primaryKey"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartValueMonitor<T>(this IDmsColumn<T> column, string primaryKey, SLProtocol protocol, Action<CellValueChange<T>> onChange)
#pragma warning restore S3242 // Method parameters should be declared with base types
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}

			if (String.IsNullOrWhiteSpace(primaryKey))
			{
				throw new ArgumentNullException("primaryKey");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (onChange == null)
			{
				throw new ArgumentNullException("onChange");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);

			Cell selection = new Cell(column.Table.Element.AgentId, column.Table.Element.Id, column.Table.Id, column.Id, primaryKey);
			var monitor = new CellValueMonitor<T>(column.Table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onChange);
		}

		/// <summary>
		/// Stops monitoring alarm level changes of the specified cell.
		/// </summary>
		/// <param name="column">The column of the cell to stop monitoring.</param>
		/// <param name="primaryKey">The primary key of the cell to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="column"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="primaryKey"/> is <see langword="null"/>
		/// </exception>
		public static void StopAlarmLevelMonitor(this IDmsColumn column, string primaryKey, SLProtocol protocol, bool force = false)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (String.IsNullOrWhiteSpace(primaryKey))
			{
				throw new ArgumentNullException("primaryKey");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Cell selection = new Cell(column.Table.Element.AgentId, column.Table.Element.Id, column.Table.Id, column.Id, primaryKey);
			CellAlarmLevelMonitor monitor = new CellAlarmLevelMonitor(column.Table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring value changes of the specified cell.
		/// </summary>
		/// <param name="column">The column of the cell to stop monitoring.</param>
		/// <param name="primaryKey">The primary key of the cell to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		public static void StopValueMonitor(this IDmsColumn column, string primaryKey, SLProtocol protocol, bool force = false)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Cell selection = new Cell(column.Table.Element.AgentId, column.Table.Element.Id, column.Table.Id, column.Id, primaryKey);
			CellValueMonitor monitor = new CellValueMonitor(column.Table.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}

	}
}