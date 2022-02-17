namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner service replication settings interface.
	/// </summary>
    public interface IReplicationServiceSettings
    {
		/// <summary>
		/// Gets the domain the user belongs to.
		/// </summary>
		/// <value>The domain the user belongs to.</value>
		string Domain { get; }
		
		/// <summary>
		/// Gets the IP address of the DataMiner Agent from which this service is replicated.
		/// </summary>
		/// <value>The IP address of the DataMiner Agent from which this service is replicated.</value>
		string IPAddressSourceAgent { get; }

		/// <summary>
		/// Gets a value indicating whether this service is replicated.
		/// </summary>
		/// <value><c>true</c> if this service is replicated; otherwise, <c>false</c>.</value>
		bool IsReplicated { get; }

		///// <summary>
		///// Gets the additional options defined when replicating the service.
		///// </summary>
		///// <value>The additional options defined when replicating the service.</value>
		//string Options { get; }

		/// <summary>
		/// Gets the password corresponding with the user name to log in on the source DataMiner Agent.
		/// </summary>
		/// <value>The password corresponding with the user name.</value>
		string Password { get; }

		/// <summary>
		/// Gets the system-wide service ID of the source service.
		/// </summary>
		/// <value>The system-wide service ID of the source service.</value>
		DmsServiceId? SourceDmsServiceId { get; }

		/// <summary>
		/// Gets the user name used to log in on the source DataMiner Agent.
		/// </summary>
		/// <value>The user name used to log in on the source DataMiner Agent.</value>
		string UserName { get; }
    }
}