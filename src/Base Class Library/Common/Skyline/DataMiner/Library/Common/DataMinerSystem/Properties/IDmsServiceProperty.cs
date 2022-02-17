namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner service property interface.
	/// </summary>
	public interface IDmsServiceProperty : IDmsProperty<IDmsServicePropertyDefinition>
	{
		/// <summary>
		/// Gets the service this property belongs to.
		/// </summary>
		IDmsService Service { get; }
	}
}