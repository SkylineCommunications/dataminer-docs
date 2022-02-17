namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner element property interface.
	/// </summary>
	public interface IDmsElementProperty : IDmsProperty<IDmsElementPropertyDefinition>
	{
		/// <summary>
		/// Gets the element this property belongs to.
		/// </summary>
		IDmsElement Element { get; }
	}
}