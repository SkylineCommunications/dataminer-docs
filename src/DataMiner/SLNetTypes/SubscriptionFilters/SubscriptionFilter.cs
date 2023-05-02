using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// <para>SubscriptionFilters are used in CreateSubscriptionMessage to indicate which types of messages
	/// should be subscribed to. The different types of <see cref="SubscriptionFilter"/> objects can be used 
	/// to subscribe with a certain level of granularity:</para>
	/// <list type="bullet">
	///		<item><description>
	///			<see cref="SubscriptionFilter"/>: Subscribes to all messages of a given type (DMS).
	///		</description></item>
	///		<item><description>
	///			SubscriptionFilterCluster: Limits subscription to one particular cluster.
	///		</description></item>
	///		<item><description>
	///			SubscriptionFilterDMA: Limits messages to one particular DataMiner Agent.
	///		</description></item>
	///		<item><description>
	///			SubscriptionFilterElement: Limits messages to one particular element.
	///		</description></item>
	///		<item><description>
	///			SubscriptionFilterParameter: Limits messages to one particular parameter.
	///		</description></item>
	/// </list>
	/// </summary>
	[Serializable]
	public class SubscriptionFilter : ICloneable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionFilter"/> class.
		/// </summary>
		public SubscriptionFilter()
		{
			Filters = new string[0];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionFilter"/> class.
		/// </summary>
		/// <param name="messageType">Name of the message type to subscribe to. All classes inherited from <see cref="DMSMessage"/>
		/// that are in the <c>SLNetTypes.dll</c> assembly can be used. The <c>messageType</c> name 
		/// is the fully qualified name, starting from <c>Skyline.DataMiner.Net</c>
		/// (e.g. "<c>AlarmEventMessage</c>" subscribes to all <see cref="AlarmEventMessage"/> messages)
		/// </param>
		public SubscriptionFilter(string messageType) : this(messageType, null)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionFilter"/> class.
		/// </summary>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="filters">The filters.</param>
		/// <exception cref="System.ArgumentNullException"><paramref name="messageType"/> is <see langword="null"/>.</exception>
		public SubscriptionFilter(string messageType, string[] filters)
		{
		}

		/// <summary>
		/// Initializes a new <see cref="SubscriptionFilter"/> instance for the given message type.
		/// </summary>
		/// <param name="messageType">Message type.</param>
		public SubscriptionFilter(Type messageType) : this(messageType, SubscriptionFilterOptions.None)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SubscriptionFilter"/> class.
		/// </summary>
		/// <param name="messageType">Type of the message.</param>
		/// <param name="options">The options.</param>
		/// <exception cref="System.ArgumentNullException"><paramref name="messageType"/> is <see langword="null"/>.</exception>
		public SubscriptionFilter(Type messageType, SubscriptionFilterOptions options) : this()
		{
		}

		protected SubscriptionFilter(SubscriptionFilter subscriptionFilter)
			: this(subscriptionFilter.MessageType, subscriptionFilter.Filters)
		{
		}

		/// <summary>
		/// The type of messages this <see cref="SubscriptionFilter"/> handles.
		/// </summary>
		public string MessageType;

		/// <summary>
		/// Extra filters. Can currently be used for <see cref="AlarmEventMessage"/> filters (alarmfilter combinations)
		/// and parameter change subscriptions (partial table subscription info).
		/// </summary>
		public string[] Filters;

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			if (Options != SubscriptionFilterOptions.None)
				return MessageTypeWithFilterInfo + " [" + Options + "]";
			else
				return MessageTypeWithFilterInfo;
		}

		/// <summary>
		/// Same as <see cref="MessageType"/>, but if filters are specified, also contains the list
		/// of filters in the string. Used by <see cref="ToString"/>.
		/// </summary>
		protected virtual string MessageTypeWithFilterInfo
		{
			get
			{
				return String.Empty;
			}
		}

		/// <summary>
		/// Checks if two <see cref="SubscriptionFilter"/> objects are identical. 
		/// </summary>
		/// <remarks>
		/// Two SubscriptionFilters are equal if they have the same type and have the same 
		/// values for their fields.
		/// </remarks>
		/// <param name="obj">Subscription filter to compare against</param>
		/// <returns><c>true</c> if the given object is equal; <c>false</c> otherwise</returns>
		public override bool Equals(object obj)
		{
			return true;
		}

		/// <summary>
		/// Serves as a hash function for a particular type, suitable for use in 
		/// hashing algorithms and data structures like a hash table.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return 0;
		}

		/// <summary>
		/// Checks if the two given sets of subscription filters contain the same items.
		/// </summary>
		/// <param name="set1">First set of subscription filters.</param>
		/// <param name="set2">Second set of subscription filters.</param>
		/// <returns><c>true</c> if the specified sets are equal; otherwise, <c>false</c>.</returns>
		public static bool EqualsSet(SubscriptionFilter[] set1, SubscriptionFilter[] set2)
		{
			return true;
		}

		/// <summary>
		/// Checks if the two given sets of subscription filters contain the same items.
		/// </summary>
		/// <param name="set1">First set of subscription filters.</param>
		/// <param name="set2">Second set of subscription filters.</param>
		/// <returns><c>true</c> if the specified sets are equal; otherwise, <c>false</c>.</returns>
		public static bool EqualsSet(List<SubscriptionFilter> set1, List<SubscriptionFilter> set2)
		{
			return true;
		}

		/// <summary>
		/// Gets or sets extra options, such as "skip initial events"
		/// </summary>
		/// <value>The extra options.</value>
		public SubscriptionFilterOptions Options { get; set; }

		/// <summary>
		/// Determines whether the specified option is present.
		/// </summary>
		/// <param name="option">The option.</param>
		/// <returns>
		///   <c>true</c> if the specified option is set; otherwise, <c>false</c>.
		/// </returns>
		public bool HasOption(SubscriptionFilterOptions option)
		{
			return ((Options & option) == option);
		}

		/// <summary>
		/// Returns a (deep) clone of this object 
		/// </summary>
		/// <returns>The clone.</returns>
		public virtual Object Clone()
		{
			return new SubscriptionFilter(this);
		}

		/// <summary>
		/// Returns the <c>Type</c> object that corresponds to the <c>MessageType</c> that 
		/// is specified in the SubscriptionFilter.
		/// </summary>
		/// <remarks>
		/// This method returns <c>null</c> for non-built-in types (any type not
		/// defined in SLNetTypes.dll or part of the Skyline.DataMiner.Net.Messages
		/// namespace).
		/// </remarks>
		/// <returns></returns>
		public Type ToTypeObject()
		{
			return ToType(MessageType);
		}

		/// <summary>
		/// Gets the name of the type (e.g. AlarmEventMessage) that needs to be used in
		/// a subscription filter if one wants to subscribe to the given type of messages.
		/// </summary>
		/// <param name="type">Type to get the name of.</param>
		/// <returns></returns>
		public static string ToTypeName(Type type)
		{
			return String.Empty;
		}

		/// <summary>
		/// Converts a given type name (e.g. AlarmEventMessage) into the associated
		/// Type object.
		/// </summary>
		/// <param name="messageType">Message type.</param>
		/// <remarks>
		/// This method returns <c>null</c> for non-built-in types (any type not
		/// defined in SLNetTypes.dll or part of the Skyline.DataMiner.Net.Messages
		/// namespace).
		/// </remarks>
		/// <returns></returns>
		public static Type ToType(string messageType)
		{
			// remove unwanted spaces (would cause GetType to fail)
			return null;
		}

		/// <summary>
		/// Base namespace for messages. If message types are within this namespace,
		/// they can be qualified with their type name only, without the need
		/// to specify the full type namespace.
		/// </summary>
		public const string BaseNameSpace = "Skyline.DataMiner.Net.Messages.";

		/// <summary>
		/// Message type from which all messages must derive.
		/// </summary>
		public static readonly Type BaseMessageType = typeof(DMSMessage);
	}

	[Serializable]
	[Flags]
	public enum SubscriptionFilterOptions
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0x000,
		/// <summary>
		/// Skip initial events.
		/// </summary>
		SkipInitialEvents = 0x001
	}
}