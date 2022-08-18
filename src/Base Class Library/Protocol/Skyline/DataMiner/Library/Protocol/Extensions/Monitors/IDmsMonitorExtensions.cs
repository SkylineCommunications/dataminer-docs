namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	using System;

	/// <summary>
	/// Defines extension methods on <see cref="IDms"/> for monitoring.
	/// </summary>
	public static class IDmsMonitorExtensions
	{
		/// <summary>
		///  Starts monitoring alarm level changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="dms">The dms to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change.</param>
		/// <remarks>Do not use SLProtocol in this action.</remarks>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartElementAlarmLevelMonitor(this IDms dms, SLProtocol protocol, Action<ElementAlarmlevelChange> onChange)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
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
			ElementAlarmLevelMonitor monitor = new ElementAlarmLevelMonitor(dms.Communication, sourceElement, new Element(-1, -1), "CLP_DmsEAlarms");

			monitor.Start(onChange);
		}

		/// <summary>
		/// Starts monitoring name changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="dms">The dms to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartElementNameMonitor(this IDms dms, SLProtocol protocol, Action<ElementNameChange> onChange)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
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
			ElementNameMonitor monitor = new ElementNameMonitor(dms.Communication, sourceElement, new Element(-1, -1), "CLP_DmsENames");
			monitor.Start(onChange);
		}

		/// <summary>
		/// Starts monitoring state changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="dms">The dms to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change. Do not use SLProtocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartElementStateMonitor(this IDms dms, SLProtocol protocol, Action<ElementStateChange> onChange)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
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
			ElementStateMonitor monitor = new ElementStateMonitor(dms.Communication, sourceElement, new Element(-1, -1), "CLP_DmsEStates");
			monitor.Start(onChange);
		}

		/// <summary>
		/// Starts monitoring state changes for any Service. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="dms">The dms to monitor.</param>
		/// <param name="protocol">The SLProtocol object.</param>
		/// <param name="onChange">The action to perform on each change. Do not use the SLPtrocol in this action.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartServiceStateMonitor(this IDms dms, SLProtocol protocol, Action<ServiceStateChange> onChange)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
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
			ServiceStateMonitor monitor = new ServiceStateMonitor(dms.Communication, sourceElement, new Service(-1, -1), "CLP_DmsSStates");
			monitor.Start(onChange);
		}

		/// <summary>
		/// Stops monitoring for alarm changes.
		/// </summary>
		/// <param name="dms">The dms to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopElementAlarmLevelMonitor(this IDms dms, SLProtocol protocol, bool force = false)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(-1, -1);
			ElementAlarmLevelMonitor monitor = new ElementAlarmLevelMonitor(dms.Communication, sourceElement, selection, "CLP_DmsEAlarms");
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring for element name changes.
		/// </summary>
		/// <param name="dms">The dms to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopElementNameMonitor(this IDms dms, SLProtocol protocol, bool force = false)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(-1, -1);
			ElementNameMonitor monitor = new ElementNameMonitor(dms.Communication, sourceElement, selection, "CLP_DmsENames");
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring for element state changes.
		/// </summary>
		/// <param name="dms">The dms to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopElementStateMonitor(this IDms dms, SLProtocol protocol, bool force = false)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Element selection = new Element(-1, -1);
			ElementStateMonitor monitor = new ElementStateMonitor(dms.Communication, sourceElement, selection, "CLP_DmsEStates");
			monitor.Stop(force);
		}

		/// <summary>
		/// Stops monitoring state changes for Services.
		/// </summary>
		/// <param name="dms">The dms to stop monitoring.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to find the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="dms"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopServiceStateMonitor(this IDms dms, SLProtocol protocol, bool force = false)
		{
			if (dms == null)
			{
				throw new ArgumentNullException("dms");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Service selection = new Service(-1, -1);
			ServiceStateMonitor monitor = new ServiceStateMonitor(dms.Communication, sourceElement, selection, "CLP_DmsSStates");
			monitor.Stop(force);
		}
	}
}