namespace Skyline.DataMiner.Library.Common
{
	using System.Collections.Generic;

	/// <summary>
	/// A collection of IElementConnection objects.
	/// </summary>
	public interface IElementConnectionCollection : IEnumerable<IElementConnection>
	{
		/// <summary>
		/// Gets or sets an entry in the collection.
		/// </summary>
		IElementConnection this[int index] { get; set; }

		/// <summary>
		/// Gets the total amount of elements in the collection.
		/// </summary>
		int Length { get; }

		/// <summary>
		/// Returns the collection as a IElementConnection array.
		/// </summary>
		IEnumerable<IElementConnection> Enumerator { get; }

		/// <summary>
		/// Clear any update flags for all the provided connections.
		/// </summary>
		void Clear();

		/// <summary>
		/// Indicates if changes occurred on IElementCommunicationConnection objects requiring an update of the SLNET Message.
		/// </summary>
		/// <returns>A boolean indicating an update is required or not. </returns>
		bool IsUpdateRequired();
	}
}