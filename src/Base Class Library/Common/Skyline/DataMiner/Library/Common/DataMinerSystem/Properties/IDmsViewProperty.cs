namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner view property interface.
	/// </summary>
	public interface IDmsViewProperty : IDmsProperty<IDmsViewPropertyDefinition>
	{
		/// <summary>
		/// Gets the view this property belongs to.
		/// </summary>
		IDmsView View { get; }
	}
}