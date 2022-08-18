namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	using System;

	/// <summary>
	/// Defines extension methods on <see cref="IDmsElement"/> for monitoring.
	/// </summary>
	public static class ElementMonitorExtensions
	{
		/// <summary>
		/// Starts monitoring alarm changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="element">The element to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartAlarmLevelMonitor(this IDmsElement element, SLProtocol protocol, Action<ElementAlarmlevelChange> onChange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
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
			Element selection = new Element(element.AgentId, element.Id);
			ElementAlarmLevelMonitor monitor = new ElementAlarmLevelMonitor(element.Host.Dms.Communication, sourceElement, selection);

			monitor.Start(onChange);
		}

		/// <summary>
		/// Starts monitoring name changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="element">The element to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartNameMonitor(this IDmsElement element, SLProtocol protocol, Action<ElementNameChange> onChange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
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
			Element selection = new Element(element.AgentId, element.Id);
			ElementNameMonitor monitor = new ElementNameMonitor(element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onChange);
		}

		/// <summary>
		/// Starts monitoring state changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="element">The element to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartStateMonitor(this IDmsElement element, SLProtocol protocol, Action<ElementStateChange> onChange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
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
			Element selection = new Element(element.AgentId, element.Id);
			ElementStateMonitor monitor = new ElementStateMonitor(element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onChange);
		}

		/// <summary>
		/// Stops monitoring for element alarm changes.
		/// </summary>
		/// <param name="element">The element to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopAlarmLevelMonitor(this IDmsElement element, SLProtocol protocol, bool force = false)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(element.AgentId, element.Id);
			ElementAlarmLevelMonitor monitor = new ElementAlarmLevelMonitor(element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring for element name changes.
		/// </summary>
		/// <param name="element">The element to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopNameMonitor(this IDmsElement element, SLProtocol protocol, bool force = false)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(element.AgentId, element.Id);
			ElementNameMonitor monitor = new ElementNameMonitor(element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring for element state changes.
		/// </summary>
		/// <param name="element">The element to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="element"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopStateMonitor(this IDmsElement element, SLProtocol protocol, bool force = false)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(element.AgentId, element.Id);
			ElementStateMonitor monitor = new ElementStateMonitor(element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}
	}
}