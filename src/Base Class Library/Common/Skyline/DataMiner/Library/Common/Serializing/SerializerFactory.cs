namespace Skyline.DataMiner.Library.Common.Serializing
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// A factory that creates some specific serializers.
	/// </summary>
	public static class SerializerFactory
	{
		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module.
		/// </summary>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer()
		{

			return null;
		}

		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module.
		/// </summary>
		/// <param name="baseType">The type of the base class to serialize or deserialize.</param>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer(Type baseType)
		{
			return null;
		}

		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module that does not use reflection (faster).
		/// </summary>
		/// <param name="baseType">The type of the base class to serialize or deserialize.</param>
		/// <param name="knownTypes">All possible custom types present in the message.</param>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer(Type baseType, IEnumerable<Type> knownTypes)
		{
			return null;
		}
	}
}
