---
uid: Installing_Cassandra
---

# Installing Cassandra on a Linux machine

If you want to use a Cassandra cluster as the general database for your DMS, you can install Cassandra on a Linux machine as follows:

1. Install the Apache Cassandra software on a Linux machine.

   For more information on how to install the software, scroll down on the [Download Now](https://cassandra.apache.org/_/download.html) page of the Apache Cassandra website.

1. Ensure the firewall ports are open for Cassandra. See [Firewall ports used with Cassandra](xref:Cassandra_firewall).

1. Prepare your data directory: If you are using a dedicated disk for the Cassandra data (which is advised for production environments), make sure you mount the correct drive to the folder and that the Cassandra user/group is configured on the folder.

1. If Cassandra is running, stop the service and clean up any files that were already created.

   - To stop Cassandra, use the following command:

     `$ sudo systemctl stop cassandra.service`

   - The content in the folders below should be removed, if there is any. In the *cassandra.yaml* file, you can find the configured locations of these folders.

     - data (default location: */var/lib/cassandra/data*)

     - commitlogs (default location: */var/lib/cassandra/commitlog*)

     - hints (default location: */var/lib/cassandra/hints*)

     - saved caches (default location: */var/lib/cassandra/saved_caches*)

1. Configure the *cassandra.yaml* and the *cassandra-rackdc.properties* files.

   - Make the following adjustments in the *cassandra.yaml* file based on your setup:

     - **cluster_name**: This needs to be the same for all nodes in your Cassandra cluster.

     - **authenticator**: Set this to *PasswordAuthenticator*.

     - **data_files_directories**: The location(s) where you want to store the data.

     - **seeds**: The IP address(es) of all the seeds in your Cassandra cluster. 3 seed nodes are recommended for every data center, preferably in different racks. If this node is being added to an existing cluster, ensure that the other nodes are available and reachable (default port is 7000).

     - **listen_address**: The IP address of the node.

     - **listen_on_broadcast_address**: Set this to *true*.

     - **rpc_address**: Set this to *0.0.0.0*.

     - **broadcast_rpc_address**: The IP address of the node.

     - **endpoint_snitch**: Set this to *GossipingPropertyFileSnitch*

     - **hinted_handoff_throttle_in_kb**: Set this to *10240*.

     - **max_hints_delivery_threads**: Set this to *12*.

   - Make the following adjustments in the *cassandra-rackdc.properties* file based on your setup:

     - **dc**: The name of the data center where this node is located.

     - **rack**: The name of the rack where this node is located. These are logical racks and can be different from the physical racks.

     - **prefer_local**: Set this to *true*.
      
      > [!IMPORTANT]
      > To ensure even distribution of the replicas among the nodes within a DC, the RF should be a multiple of the number of racks.
      > When in doubt (general practice), is to put all nodes of a DC into one rack.

1. Start Cassandra and evaluate if the service is up and running.

   - To start Cassandra, use the following command:

     `$ sudo systemctl start cassandra.service`

   - To check if Cassandra is running, use the following command (note that it can take a couple of seconds before the node is started):

     `$ nodetool status`

     If the node does note state UN (Up & Normal) in the *nodetool status* command, evaluate the logging. The logging is located at */var/log/cassandra/system.log*.

1. Configure the Cassandra cluster database in System Center. See [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

> [!NOTE]
> In this setup, the Cassandra database is not managed by DataMiner, so it is important that you manage it yourself (see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster)).
