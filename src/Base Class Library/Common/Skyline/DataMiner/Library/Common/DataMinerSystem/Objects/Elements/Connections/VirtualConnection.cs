using System;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Library.Common
{
	using System.Linq;

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

		/// <summary>
		/// Create an ElementPortInfo object from the properties.
		/// </summary>
		/// <returns></returns>
		internal override ElementPortInfo CreateElementPortInfo(int portPosition,bool isCompatibilityIssueDetected)
		{
			ElementPortInfo portInfo = new ElementPortInfo
			{
				PortID = portPosition,
				ProtocolType = Net.Messages.ProtocolType.Virtual

			};
				
			return portInfo;
		}

		/// <summary>
		/// Update an ElementPortInfo object based on the performed changes.
		/// </summary>
		/// <param name="portInfo"></param>
		/// <param name="isCompatibilityIssueDetected"></param>
		internal override void UpdateElementPortInfo(ElementPortInfo portInfo, bool isCompatibilityIssueDetected)
		{
			//nothing to update but no exception can be thrown.
		}

		/// <summary>
		/// Returns whether a property has been set or not.
		/// </summary>
		internal override bool IsUpdated
		{
			get
			{
				return (ChangedPropertyList.Any());
			}
		}

		/// <summary>
		/// Clear the performed update flags of the properties of the object.
		/// </summary>
		internal override void ClearUpdates()
		{
			this.ChangedPropertyList.Clear();
		}
	}
}