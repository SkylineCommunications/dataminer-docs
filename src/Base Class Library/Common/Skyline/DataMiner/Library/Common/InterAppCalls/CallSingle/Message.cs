namespace Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle
{
	using Skyline.DataMiner.Library.Common;
    using Skyline.DataMiner.Library.Common.Attributes;
	using Skyline.DataMiner.Library.Common.InterAppCalls.Shared;
	using Skyline.DataMiner.Library.Common.Serializing;
	using Skyline.DataMiner.Library.Common.Subscription.Waiters.InterApp;
	using Skyline.DataMiner.Net;

	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.Serialization;

	/// <summary>
	/// Represents a single command or response.
	/// </summary>
    [DllImport("System.Runtime.Serialization.dll")]
	public class Message
	{
		private ISerializer internalSerializer;

		/// <summary>
		/// Initializes a new instance of the <see cref="Message"/> class.
		/// </summary>
		/// <remarks>Creates an instance of Message with a new GUID created using <see cref="System.Guid.NewGuid"/>.</remarks>
		public Message()
		{
			Guid = System.Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Message"/> class using the specified GUID.
		/// </summary>
		/// <param name="guid">The GUID.</param>
		public Message(string guid)
		{
			Guid = guid;
		}

		/// <summary>
		/// Gets or sets a globally unique identifier (GUID) identifying this message.
		/// </summary>
		/// <value>A globally unique identifier (GUID) identifying this message.</value>
		public string Guid { get; set; }

		/// <summary>
		/// The internal serializer used to serialize this message.
		/// </summary>
		[IgnoreDataMember]
		public ISerializer InternalSerializer
		{
			get
			{
				if (internalSerializer == null)
				{
					internalSerializer = SerializerFactory.CreateInterAppSerializer(typeof(Message));
				}

				return internalSerializer;
			}

			set { internalSerializer = value; }
		}

		/// <summary>
		/// Gets or sets the return address.
		/// </summary>
		/// <value>The return address.</value>
		/// <remarks>The return address represents a parameter on a specific element (identified by a DataMiner Agent ID, element ID and parameter ID) which will be checked for a return message. This use of this property is optional.</remarks>
		public ReturnAddress ReturnAddress { get; set; }

		/// <summary>
		/// Gets or sets the source of this message.
		/// </summary>
		/// <value>The source of this message.</value>
		public Source Source { get; set; }

		/// <summary>
		/// Retrieves the executor of this message using reflection. This contains all logic to perform when receiving this message.
		/// </summary>
		/// <returns>The executor holding all logic for processing this message.</returns>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for this type of message.</exception>
		public MessageExecution.IMessageExecutor CreateExecutor()
		{
			return MessageExecution.MessageExecutorFactory.CreateExecutor(this);
		}

		/// <summary>
		/// Retrieves the executor of this message using custom mapping. This contains all logic to perform when receiving this message.
		/// </summary>
		/// <param name="messageToExecutorMapping">A mapping to link message type with the right execution type.</param>
		/// <returns>The executor holding all logic for processing this message.</returns>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for this type of message.</exception>
		public MessageExecution.IMessageExecutor CreateExecutor(IDictionary<Type, Type> messageToExecutorMapping)
		{
			return MessageExecution.MessageExecutorFactory.CreateExecutor(this, messageToExecutorMapping);
		}

		/// <summary>
		/// Tries to get the Executor and run the following methods in order:
		/// DataGets (always), Parse (always), Validate (always), Modify (if validate true), DataSets (if validate true), CreateReturnMessage (always).
		/// </summary>
		/// <param name="dataSource">A source used during DataGets, usually SLProtocol or Engine.</param>
		/// <param name="dataDestination">A destination used during DataSets, usually SLProtocol or Engine.</param>
		/// <param name="optionalReturnMessage">The return message that might get created in the CreateReturnMessage method.</param>
		/// <returns>A boolean to indicate if the execution was successful.</returns>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for this type of message.</exception>
		public bool TryExecute(object dataSource, object dataDestination, out Message optionalReturnMessage)
		{
			var executor = CreateExecutor();
			return DefaultExecuteFlow(dataSource, dataDestination, out optionalReturnMessage, executor);
		}

		/// <summary>
		/// Tries to get the Executor and run the following methods in order:
		/// DataGets (always), Parse (always), Validate (always), Modify (if validate true), DataSets (if validate true), CreateReturnMessage (always).
		/// </summary>
		/// <param name="dataSource">A source used during DataGets, usually SLProtocol or Engine.</param>
		/// <param name="dataDestination">A destination used during DataSets, usually SLProtocol or Engine.</param>
		/// <param name="messageToExecutorMapping">A mapping to link message type with the right execution type.</param>
		/// <param name="optionalReturnMessage">The return message that might get created in the CreateReturnMessage method.</param>
		/// <returns>A boolean to indicate if the execution was successful.</returns>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for this type of message.</exception>
		public bool TryExecute(object dataSource, object dataDestination, IDictionary<Type, Type> messageToExecutorMapping, out Message optionalReturnMessage)
		{
			var executor = CreateExecutor(messageToExecutorMapping);
			return DefaultExecuteFlow(dataSource, dataDestination, out optionalReturnMessage, executor);
		}

		/// <summary>
		/// Sends this message using a default serializer and SLNet communication to a specific DataMiner Agent ID/element ID/parameter ID without waiting on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">The DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">The element ID of the destination.</param>
		/// <param name="parameterId">The parameter ID of the destination.</param>
		public void Send(IConnection connection, int agentId, int elementId, int parameterId)
		{
			var destination = new DmsElementId(agentId, elementId);
			IDms thisDma = connection.GetDms();
			var element = thisDma.GetElement(destination);
			var parameter = element.GetStandaloneParameter<string>(parameterId);
			Stopwatch sw = new Stopwatch();
			sw.Start();
			string value = Serialize();
			System.Diagnostics.Debug.WriteLine("CLP - InterApp - Serialized: " + sw.ElapsedMilliseconds + " ms");
			sw.Restart();
			parameter.SetValue(value);
			System.Diagnostics.Debug.WriteLine("CLP - InterApp - Value Set to external pid: " + sw.ElapsedMilliseconds + " ms");
		}

		/// <summary>
		/// Sends this message using SLNet communication to a specific DataMiner Agent ID/element ID/parameter ID without waiting on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">The DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">The element ID of the destination.</param>
		/// <param name="parameterId">The parameter ID of the destination.</param>
		/// <param name="serializer">A custom serializer.</param>
		public void Send(IConnection connection, int agentId, int elementId, int parameterId, ISerializer serializer)
		{
			this.InternalSerializer = serializer;
			this.Send(connection, agentId, elementId, parameterId);
		}

		/// <summary>
		/// Sends this message using SLNet communication to a specific DataMiner Agent ID/element ID/parameter ID and waits on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">The DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">The element ID of the destination.</param>
		/// <param name="parameterId">The parameter ID of the destination.</param>
		/// <param name="timeout">The maximum time to wait between each reply. Wait time resets each time a reply is received.</param>
		/// <returns>The reply response to this command.</returns>
		public Message Send(IConnection connection, int agentId, int elementId, int parameterId, TimeSpan timeout)
		{
			if (ReturnAddress != null)
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				using (MessageWaiter waiter = new MessageWaiter(new ConnectionCommunication(connection), null, InternalSerializer, this))
				{
					System.Diagnostics.Debug.WriteLine("CLP - InterApp - Creation of MessageWait: " + sw.ElapsedMilliseconds + " ms");
					sw.Restart();
					Send(connection, agentId, elementId, parameterId);
					System.Diagnostics.Debug.WriteLine("CLP - InterApp - Sent: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
					System.Diagnostics.Debug.WriteLine("CLP - InterApp - Sending of message: " + sw.ElapsedMilliseconds + " ms");
					sw.Restart();
					return waiter.WaitNext(timeout).First();
				}
			}

			return null;
		}

		/// <summary>
		/// Sends this message using SLNet communication to a specific DataMiner Agent ID/element ID/parameter ID and waits on a reply.
		/// </summary>
		/// <param name="connection">The SLNet connection to use.</param>
		/// <param name="agentId">The DataMiner Agent ID of the destination.</param>
		/// <param name="elementId">The element ID of the destination.</param>
		/// <param name="parameterId">The parameter ID of the destination.</param>
		/// <param name="timeout">The maximum time to wait between each reply. Wait time resets each time a reply is received.</param>
		/// <param name="serializer">A custom serializer that can be used in the background.</param>
		/// <returns>The reply response to this command.</returns>
		public Message Send(IConnection connection, int agentId, int elementId, int parameterId, TimeSpan timeout, ISerializer serializer)
		{
			this.InternalSerializer = serializer;
			return this.Send(connection, agentId, elementId, parameterId, timeout);
		}

		/// <summary>
		/// Serializes this object using the internal ISerializer.
		/// </summary>
		/// <returns>The serialized string of this object.</returns>
		public string Serialize()
		{
			return InternalSerializer.SerializeToString(this);
		}

		private static bool DefaultExecuteFlow(object dataSource, object dataDestination, out Message optionalReturnMessage, MessageExecution.IMessageExecutor executor)
		{
			executor.DataGets(dataSource);
			executor.Parse();
			bool result = executor.Validate();
			if (result)
			{
				executor.Modify();
				executor.DataSets(dataDestination);
			}

			optionalReturnMessage = executor.CreateReturnMessage();

			return result;
		}
	}
}