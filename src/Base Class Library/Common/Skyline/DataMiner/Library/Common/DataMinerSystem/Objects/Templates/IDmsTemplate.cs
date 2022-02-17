namespace Skyline.DataMiner.Library.Common.Templates
{
	/// <summary>
	/// DataMiner template interface.
	/// </summary>
	public interface IDmsTemplate : IDmsObject
	{
		/// <summary>
		/// Gets the template name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the protocol this template corresponds with.
		/// </summary>
		IDmsProtocol Protocol { get; }
	}
}