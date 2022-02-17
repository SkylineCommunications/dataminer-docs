namespace Skyline.DataMiner.Library.Common.InterAppCalls.CallBulk
{
	using Skyline.DataMiner.Library.Common.InterAppCalls.CallSingle;

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Represents a collection of messages.
	/// </summary>
	public class Messages : ICollection<Message>
	{
		private readonly Dictionary<string, Message> content = new Dictionary<string, Message>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Messages"/> class.
		/// </summary>
		public Messages()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Messages"/> class using the specified parent inter-app call.
		/// </summary>
		/// <param name="parentCall">The parent inter-app call.</param>
		public Messages(IInterAppCall parentCall)
		{
			ParentCall = parentCall;
		}

		/// <summary>
		/// Gets the number of messages contained in this object.
		/// </summary>
		/// <value>The number of messages contained in this object.</value>
		public int Count
		{
			get { return content.Count; }
		}

		/// <summary>
		/// Gets a value indicating whether this object is read-only.
		/// </summary>
		/// <value><c>true</c> if read-only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Gets or sets the parent inter-app call.
		/// </summary>
		/// <value>The parent inter-app call or <see langword="null"/> if there is no parent.</value>
		public IInterAppCall ParentCall { get; set; }

		/// <summary>
		/// Adds a new message.
		/// </summary>
		/// <param name="item">The message to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The provided message should not implement the <see cref="MessageExecution.IMessageExecutor"/> interface.
		/// -or-
		/// An item with the same GUID was already added.
		/// -or-
		/// The GUID of the item is <see langword="null"/>.
		/// </exception>
		public void Add(Message item)
		{
			AddMessage(item);
		}

		/// <summary>
		/// Adds the specified messages to the collection.
		/// </summary>
		/// <param name="messages">The messages to add.</param>
		/// <exception cref="ArgumentNullException"><paramref name="messages"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The provided message should not implement the <see cref="MessageExecution.IMessageExecutor"/> interface.
		/// -or-
		/// An item with the same GUID was already added.
		/// -or-
		/// A message or the GUID of the message is <see langword="null"/>.
		/// </exception>
		public void AddMessage(params Message[] messages)
		{
			if (messages == null)
			{
				throw new ArgumentNullException("messages");
			}

			Type executorType = typeof(MessageExecution.IMessageExecutor);

			for (int i = 0; i < messages.Length; i++)
			{
				if (executorType.IsAssignableFrom(messages[i].GetType()))
				{
					throw new ArgumentException("Message provided should not implement IMessageExecutor. Make sure you decouple data and logic.", "messages");
				}

				if (messages[i] == null || messages[i].Guid == null)
				{
					throw new ArgumentException("message or message GUID must not be null");
				}

				content.Add(messages[i].Guid, messages[i]);
			}
		}

		/// <summary>
		/// Clears the current collection.
		/// </summary>
		public void Clear()
		{
			content.Clear();
		}

		/// <summary>
		/// Checks if the collection contains the specified message.
		/// </summary>
		/// <param name="item">The item to check.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The <see cref="Message.Guid"/> property of <paramref name="item"/> is <see langword="null" />.</exception>
		/// <returns><c>true</c> if <paramref name="item"/> is present in the collection; otherwise, <c>false</c>.</returns>
		public bool Contains(Message item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (item.Guid == null)
			{
				throw new ArgumentException("the GUID of the specified item must not be null.");
			}

			return content.ContainsKey(item.Guid);
		}

		/// <summary>
		/// Copies the full content of this collection to a different one.
		/// </summary>
		/// <param name="array">The target collection to copy into.</param>
		/// <param name="arrayIndex">The index to start from on the destination collection.</param>
		public void CopyTo(Message[] array, int arrayIndex)
		{
			var valuesArray = content.Values.ToArray();
			Array.Copy(valuesArray, 0, array, arrayIndex, valuesArray.Length);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<Message> GetEnumerator()
		{
			return content.Values.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Removes a message from this collection.
		/// </summary>
		/// <param name="item">The message item you want to remove.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The <see cref="Message.Guid"/> property of <paramref name="item"/> is <see langword="null" />.</exception>
		/// <returns>A boolean indicating if the removal was successful.</returns>
		public bool Remove(Message item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (item.Guid == null)
			{
				throw new ArgumentException("the GUID of the specified item must not be null.");
			}

			return RemoveMessage(item.Guid);
		}

		/// <summary>
		/// Removes one or more messages from this collection by using the GUIDs.
		/// </summary>
		/// <param name="guids">The global unique identifiers for messages you want to remove.</param>
		/// <exception cref="ArgumentNullException"><paramref name="guids"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">A GUID must not be <see langword="null" />.</exception>
		/// <returns>A boolean indicating if the removal was successful.</returns>
		public bool RemoveMessage(params string[] guids)
		{
			if (guids == null)
			{
				throw new ArgumentNullException("guids");
			}

			bool result = true;
			foreach (var guid in guids)
			{
				if (guid == null)
				{
					throw new ArgumentException("guid must not be null");
				}

				bool innerResult = content.Remove(guid);
				result = result && innerResult;
			}

			return result;
		}

		/// <summary>
		/// Gets the message associated with the specified GUID.
		/// </summary>
		/// <param name="guid">The global unique identifier representing the message.</param>
		/// <param name="message">The message if found; <see langword="null"/> if not found.</param>
		/// <exception cref="ArgumentNullException"><paramref name="guid"/> is <see langword="null"/>.</exception>
		/// <returns>A boolean indicating if the message was found.</returns>
		public bool TryGetMessage(string guid, out Message message)
		{
			return content.TryGetValue(guid, out message);
		}
	}
}