namespace Skyline.DataMiner.Library.Common.InterAppCalls.MessageExecution
{
	using CallSingle;

	using Skyline.DataMiner.Library.Common.Reflection;

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	/// <summary>
	/// A static factory for the creation of message executors.
	/// </summary>
	public static class MessageExecutorFactory
	{
		/// <summary>
		/// Uses reflection to return the executor for the specified message.
		/// </summary>
		/// <param name="message">The message you want to obtain an executor for.</param>
		/// <exception cref="ArgumentNullException"><paramref name="message"/> is <see langword="null"/>.</exception>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for message with the type of <paramref name="message"/>.</exception>
		/// <returns>The executor for this message.</returns>
		public static IMessageExecutor CreateExecutor(Message message)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}

			Type concreteType = message.GetType();

			Type concreteExecutor = null;

			// Find the Concrete executor for this.
			foreach (var assembly in ReflectionHelper.GetLoadedAssemblies())
			{
				if (concreteExecutor != null) break;

				concreteExecutor = FindTypeInAssembly(assembly, concreteType);
			}

			if (concreteExecutor != null)
			{
				return (IMessageExecutor)Activator.CreateInstance(concreteExecutor, message);
			}
			else
			{
				throw new AmbiguousMatchException("Unable to find executor for message with type:" + concreteType + ". Verify you have a class implementing :MessageExecutor<" + concreteType + ">.");
			}
		}

		/// <summary>
		/// Uses provided mapping to return the executor for the specified message. (Fast than relying on reflection.)
		/// </summary>
		/// <param name="message">The message you want to obtain an executor for.</param>
		/// <param name="messageToExecutorMapping">The mapping you want to use to link a message with its executor.</param>
		/// <exception cref="ArgumentNullException"><paramref name="message"/> is <see langword="null"/>.</exception>
		/// <exception cref="AmbiguousMatchException">Unable to find executor for message with the type of <paramref name="message"/>.</exception>
		/// <returns>The executor for this message.</returns>
		public static IMessageExecutor CreateExecutor(Message message, IDictionary<Type, Type> messageToExecutorMapping)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}

			Type concreteType = message.GetType();

			Type concreteExecutor = null;

			if (messageToExecutorMapping == null)
			{
				throw new ArgumentNullException("messageToExecutorMapping");
			}

			var mappedByName = messageToExecutorMapping.ToDictionary(p => p.Key.FullName, p => p.Value);
			if (mappedByName.TryGetValue(concreteType.FullName, out concreteExecutor))
			{
				return (IMessageExecutor)Activator.CreateInstance(concreteExecutor, message);
			}
			else
			{
				throw new AmbiguousMatchException("Unable to find executor for message with type:" + concreteType + ". Verify you added the message and executor type to the provided mapping.");
			}

		}

		private static Type FindTypeInAssembly(Assembly assembly, Type concreteType)
		{
			foreach (Type type in assembly.GetTypes())
			{
				if (type.IsInterface || type.IsAbstract || !type.BaseType.IsAbstract) continue;

				Type baseType = type.BaseType;
				Type expectedBase = typeof(MessageExecutor<>);

				if (baseType.Name == expectedBase.Name)
				{
					var genericType = baseType.GetGenericArguments()[0];

					if (genericType == concreteType)
					{
						return type;
					}
				}
			}

			return null;
		}
	}
}