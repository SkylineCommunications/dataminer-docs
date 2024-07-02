namespace Skyline.DataMiner.Net.Topology
{
	/// <summary>
	/// Protocol topology chain interface.
	/// </summary>
	public interface IProtocolTopologyChain
	{
		/// <summary>
		/// Gets the index within the list of chains/searchchains (1..n).
		/// </summary>
		/// <value>The index within the list of chains/searchchains (1..n).</value>
		int Index { get; }

		/// <summary>
		/// Gets the name of the chain.
		/// </summary>
		/// <value>The name of the chain.</value>
		string Name { get; }
	}
}
