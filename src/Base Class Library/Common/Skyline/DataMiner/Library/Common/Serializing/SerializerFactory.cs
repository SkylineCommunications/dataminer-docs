namespace Skyline.DataMiner.Library.Common.Serializing
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// A factory that creates some specific serializers.
	/// </summary>
	public static class SerializerFactory
	{
		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module.
		/// </summary>
		/// <param name="baseType">The type of the base class to serialize or deserialize.</param>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer()
		{
			NoTagSerializing.SerializerBuilder builder = new NoTagSerializing.SerializerBuilder();
			builder.WithSerializer(NoTagSerializing.XmlSerializerType.JsonNewtonSoft);

			return builder.Build();
		}

		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module.
		/// </summary>
		/// <param name="baseType">The type of the base class to serialize or deserialize.</param>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer(Type baseType)
		{
			NoTagSerializing.SerializerBuilder builder = new NoTagSerializing.SerializerBuilder();
			builder.WithSerializer(NoTagSerializing.XmlSerializerType.JsonNewtonSoft);
			builder.WithBaseType(baseType);

			return builder.Build();
		}

		/// <summary>
		/// Creates a serializer specifically for use by the InterApp module that does not use reflection (faster).
		/// </summary>
		/// <param name="baseType">The type of the base class to serialize or deserialize.</param>
		/// <param name="knownTypes">All possible custom types present in the message.</param>
		/// <returns>An instance of type ISerializer.</returns>
		public static ISerializer CreateInterAppSerializer(Type baseType, IEnumerable<Type> knownTypes)
		{
			NoTagSerializing.SerializerBuilder builder = new NoTagSerializing.SerializerBuilder();
			builder.WithSerializer(NoTagSerializing.XmlSerializerType.JsonNewtonSoft);
			builder.WithBaseType(baseType);
			builder.WithPossibleTypes(knownTypes.ToArray());

			return builder.Build();
		}
	}
}