namespace Skyline.DataMiner.Library.Protocol.Subscription.Monitors
{
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Library.Common.Selectors;
	using Skyline.DataMiner.Library.Common.Subscription.Monitors;
	using Skyline.DataMiner.Scripting;

	using System;

	/// <summary>
	/// Defines extension methods on <see cref="IDmsStandaloneParameter"/> for monitoring.
	/// </summary>
	public static class ParameterMonitorExtensions
	{
		/// <summary>
		///  Starts monitoring alarm level changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="parameter">The parameter to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change.</param>
		/// <remarks>Do not use SLProtocol in this action.</remarks>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		public static void StartAlarmLevelMonitor(this IDmsStandaloneParameter parameter, SLProtocol protocol, Action<ParamAlarmLevelChange> onChange)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
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
			Param selection = new Param(parameter.Element.AgentId, parameter.Element.Id, parameter.Id);
			ParamAlarmLevelMonitor monitor = new ParamAlarmLevelMonitor(parameter.Element.Host.Dms.Communication, sourceElement, selection);

			monitor.Start(onChange);
		}

#pragma warning disable S3242 // Method parameters should be declared with base types
		/// <summary>
		///  Starts monitoring value changes. Every change will perform the onChange action. Important: do not use SLProtocol in the provided action.
		/// </summary>
		/// <param name="parameter">The parameter to monitor.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="onChange">The action to perform on each change.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="onChange"/> is <see langword="null"/>
		/// </exception>
		/// <remarks>Do not use SLProtocol in this action.</remarks>
		public static void StartValueMonitor<T>(this IDmsStandaloneParameter<T> parameter, SLProtocol protocol, Action<ParamValueChange<T>> onChange)
#pragma warning restore S3242 // Method parameters should be declared with base types
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
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
			Param selection = new Param(parameter.Element.AgentId, parameter.Element.Id, parameter.Id);

			var monitor = new ParamValueMonitor<T>(parameter.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Start(onChange);
		}

		/// <summary>
		///  Stops monitoring alarm level changes of the specified parameter.
		/// </summary>
		/// <param name="parameter">The parameter to stop monitoring for alarm level changes.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopAlarmLevelMonitor(this IDmsStandaloneParameter parameter, SLProtocol protocol, bool force = false)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Param selection = new Param(parameter.Element.AgentId, parameter.Element.Id, parameter.Id);
			ParamAlarmLevelMonitor monitor = new ParamAlarmLevelMonitor(parameter.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}

		/// <summary>
		///  Stops monitoring value changes of the specified parameter.
		/// </summary>
		/// <param name="parameter">The parameter to stop monitoring for value changes.</param>
		/// <param name="protocol">The SLProtocol object, which will be used to get the source element.</param>
		/// <param name="force">Force the cleanup.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parameter"/> is <see langword="null"/>
		/// -or-
		/// <paramref name="protocol"/> is <see langword="null"/>
		/// </exception>
		public static void StopValueMonitor(this IDmsStandaloneParameter parameter, SLProtocol protocol, bool force = false)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException("parameter");
			}
			if (protocol == null)
			{
				throw new ArgumentNullException("protocol");
			}

			Element sourceElement = new Element(protocol.DataMinerID, protocol.ElementID);
			Param selection = new Param(parameter.Element.AgentId, parameter.Element.Id, parameter.Id);

			var monitor = new ParamValueMonitor(parameter.Element.Host.Dms.Communication, sourceElement, selection);
			monitor.Stop(force);
		}
	}
}