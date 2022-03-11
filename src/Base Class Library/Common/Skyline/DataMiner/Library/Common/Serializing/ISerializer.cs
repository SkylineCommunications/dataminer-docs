namespace Skyline.DataMiner.Library.Common.Serializing
{
	using System;

	/// <summary>
	/// Interface that represents a serializer.
	/// </summary>
	public interface ISerializer
	{
		/// <summary>
		/// Deserializes the specified string into an object of type T.
		/// </summary>
		/// <typeparam name="T">The type of the base class to deserialize into.</typeparam>
		/// <param name="input">A string representing the serialized base class.</param>
		/// <returns>An instance of the selected base class.</returns>
		/// <exception cref="ArgumentException"><paramref name="input"/> had invalid format.</exception>
		T DeserializeFromString<T>(string input);

		/// <summary>
		/// Serializes the specified object in a string.
		/// </summary>
		/// <param name="input">The object to serialize.</param>
		/// <returns>A string representing the serialized object.</returns>
		/// <exception cref="ArgumentException"><paramref name="input"/> had invalid format.</exception>
		string SerializeToString(object input);
	}
}