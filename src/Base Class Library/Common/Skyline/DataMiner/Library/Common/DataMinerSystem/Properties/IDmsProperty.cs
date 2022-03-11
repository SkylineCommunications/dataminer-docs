namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner property interface.
	/// </summary>
	/// <typeparam name="T">The property type.</typeparam>
	public interface IDmsProperty<out T> where T : IDmsPropertyDefinition
	{
		/// <summary>
		/// Gets the property value.
		/// </summary>
		string Value { get; }

		/// <summary>
		/// Gets the property definition.
		/// </summary>
		T Definition { get; }
	}
}