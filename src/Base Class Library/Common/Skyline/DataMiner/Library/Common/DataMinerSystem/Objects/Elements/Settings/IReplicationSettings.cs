namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// DataMiner element replication settings interface.
	/// </summary>
    public interface IReplicationSettings
    {
		/// <summary>
		/// Gets the domain the user belongs to.
		/// </summary>
		/// <value>The domain the user belongs to.</value>
		string Domain { get; }

		///// <summary>
		///// Gets a value indicating whether it is allowed to perform the logic of a protocol on the replicated element instead of only showing the data received on the original element.
		///// By Default, some functionality is not allowed on replicated elements (get, set, QAs, triggers etc.).
		///// </summary>
		///// <value><c>true</c> if it is allowed to perform the logic of a protocol on the replicated element; otherwise, <c>false</c>.</value>
		//bool ConnectsToExternalProbe { get; }

		/// <summary>
		/// Gets the IP address of the DataMiner Agent from which this element is replicated.
		/// </summary>
		/// <value>The IP address of the DataMiner Agent from which this element is replicated.</value>
		string IPAddressSourceAgent { get; }

		/// <summary>
		/// Gets a value indicating whether this element is replicated.
		/// </summary>
		/// <value><c>true</c> if this element is replicated; otherwise, <c>false</c>.</value>
		bool IsReplicated { get; }

		///// <summary>
		///// Gets the additional options defined when replicating the element.
		///// </summary>
		///// <value>The additional options defined when replicating the element.</value>
		//string Options { get; }

		/// <summary>
		/// Gets the password corresponding with the user name to log in on the source DataMiner Agent.
		/// </summary>
		/// <value>The password corresponding with the user name.</value>
		string Password { get; }

		/// <summary>
		/// Gets the system-wide element ID of the source element.
		/// </summary>
		/// <value>The system-wide element ID of the source element.</value>
		DmsElementId SourceDmsElementId { get; }

		/// <summary>
		/// Gets the user name used to log in on the source DataMiner Agent.
		/// </summary>
		/// <value>The user name used to log in on the source DataMiner Agent.</value>
		string UserName { get; }
    }
}