using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Class representing a Virtual connection. 
	/// </summary>
	public class VirtualConnection : ConnectionSettings, IVirtualConnection
	{

		private readonly int id;

		/// <summary>
		/// Initiates a new VirtualConnection class.
		/// </summary>
		/// <param name="info"></param>
		internal VirtualConnection(ElementPortInfo info)
		{
			this.id = info.PortID;
		}

		/// <summary>
		/// Initiates a new VirtualConnection class.
		/// </summary>
		public VirtualConnection()
		{
			this.id = -1;
		}

		/// <summary>
		/// Gets the zero based id of the connection.
		/// </summary>
		public int Id
		{
			get { return id; }
		}
	}
}