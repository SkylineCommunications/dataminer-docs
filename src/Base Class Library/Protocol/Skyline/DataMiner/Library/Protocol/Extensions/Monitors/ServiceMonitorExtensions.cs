namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using System;
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Defines extension methods on <see cref="IDmsService"/> for monitoring.
	/// </summary>
	public static class ServiceMonitorExtensions
	{
		/// <summary>
		/// Starts monitoring alarm changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="service">The service to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onchange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="service"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onchange"/> is <see langword="null"/>
		/// </exception>
		public static void StartAlarmLevelMonitor(this IDmsService service, SLProtocol protocol, Action<ServiceAlarmLevelChange> onchange)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (onchange == null)
			{
				throw new ArgumentNullException("onchange");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Service selection = new Service(service.AgentId, service.Id);
			ServiceAlarmLevelMonitor monitor = new ServiceAlarmLevelMonitor(service.Host.Dms.Communication, sourceElement, selection);

			monitor.Start(onchange);
		}
		
		/// <summary>
		/// Starts monitoring state changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="service">The service to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onchange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="service"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onchange"/> is <see langword="null"/>
		/// </exception>
		public static void StartStateMonitor(this IDmsService service, SLProtocol protocol, Action<ServiceStateChange> onchange)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			if (onchange == null)
			{
				throw new ArgumentNullException("onchange");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Service selection = new Service(service.AgentId, service.Id);
			ServiceStateMonitor monitor = new ServiceStateMonitor(service.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onchange);
		}

		/// <summary>
		/// Stops monitoring for service alarm changes.
		/// </summary>
		/// <param name="service">The service to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="service"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopAlarmLevelMonitor(this IDmsService service, SLProtocol protocol, bool force = false)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Service selection = new Service(service.AgentId, service.Id);
			ServiceAlarmLevelMonitor monitor = new ServiceAlarmLevelMonitor(service.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}
		
		/// <summary>
		/// Stops monitoring for service state changes.
		/// </summary>
		/// <param name="service">The service to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="service"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopStateMonitor(this IDmsService service, SLProtocol protocol, bool force = false)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}

			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Service selection = new Service(service.AgentId, service.Id);
			ServiceStateMonitor monitor = new ServiceStateMonitor(service.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}
	}
}