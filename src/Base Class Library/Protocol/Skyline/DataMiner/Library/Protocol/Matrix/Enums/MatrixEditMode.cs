namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	/// <summary>
	/// Used to determine if existing input port connections to the output port should be removed or not.
	/// </summary>
	public enum MatrixEditMode
	{
		/// <summary>
		/// Existing input port connections to the output port will not be removed. This will throw an exception when maximum one input per output is supported.
		/// </summary>
		Add,

		/// <summary>
		/// Existing input port connections to the output port will be removed.
		/// </summary>
		Replace
	}
}
