---
uid: Installing_Cassandra
---

# Installing Cassandra on a Linux machine

If you want to use a Cassandra cluster as the general database for your DMS, you can install Cassandra on a Linux machine as detailed below.

> [!NOTE]
> We promote the use of Ubuntu LTS as the preferred linux distribution. As such, the commands mentioned below will work on any Debian-based system, including Ubuntu.

1. Install the Apache Cassandra software on a Linux machine.

   For more information on how to install the software, scroll down on the [Download Now](https://cassandra.apache.org/_/download.html) page of the Apache Cassandra website, and follow the steps of the installation process detailed under *Installation from Debian packages*.

1. Ensure the firewall ports are open for Cassandra. See [Firewall ports used with Cassandra](xref:Cassandra_firewall).

   - There is a default firewall on Ubuntu, but this is disabled by default. To enable the firewall, use the following command:

     `$ sudo ufw enable`

   - To add the correct ports to the firewall, you can for example use the following commands for a 3-node cluster:

     - Commands node 1:

       `$ sudo ufw allow from [IP node 2] to [IP node 1] proto tcp port 7000,7001,9042`

       `$ sudo ufw allow from [IP node 3] to [IP node 1] proto tcp port 7000,7001,9042`

     - Commands node 2:

       `$ sudo ufw allow from [IP node 1] to [IP node 2] proto tcp port 7000,7001,9042`

       `$ sudo ufw allow from [IP node 3] to [IP node 2] proto tcp port 7000,7001,9042`

     - Commands node 3:

       `$ sudo ufw allow from [IP node 1] to [IP node 3] proto tcp port 7000,7001,9042`

       `$ sudo ufw allow from [IP node 2] to [IP node 3] proto tcp port 7000,7001,9042`

   > [!IMPORTANT]
   > If you connect to your linux server with SSH, you also have to add port 22. You can use the following command for this:
   >
   > `$ sudo ufw allow 22/tcp`

1. Prepare your data directory: If you are using a dedicated disk for the Cassandra data (which is advised for production environments), make sure that you mount the correct drive to the folder and that the Cassandra user/group is configured on the folder.

1. If Cassandra is running, stop the service and clean up any files that were already created.

   - To stop Cassandra, use the following command:

     `$ sudo systemctl stop cassandra.service`

   - The content of the folders below should be removed, if there is any. You can use the specified commands to do so. In the *cassandra.yaml* file, you can find the configured locations of these folders.

     - data (default location: */var/lib/cassandra/data*)

       `$ sudo rm -r /var/lib/cassandra/data/*`

     - commitlogs (default location: */var/lib/cassandra/commitlog*)

       `$ sudo rm -r /var/lib/cassandra/commitlog/*`

     - hints (default location: */var/lib/cassandra/hints*)

       `$ sudo rm -r /var/lib/cassandra/hints/*`

     - saved caches (default location: */var/lib/cassandra/saved_caches*)

       `$ sudo rm -r /var/lib/cassandra/saved_caches/*`

1. Configure the *cassandra.yaml* and the *cassandra-rackdc.properties* files.

   To change these config files, you can use the following commands:

   `$ sudo nano /etc/cassandra/cassandra.yaml`

   `$ sudo nano /etc/cassandra/cassandra-rackdc.properties`

   - Make the following adjustments in the *cassandra.yaml* file based on your setup:

     - **cluster_name**: This needs to be the same for all nodes in your Cassandra cluster.

     - **hinted_handoff_throttle_in_kb**: Set this to *10240*.

     - **max_hints_delivery_threads**: Set this to *12*.

     - **authenticator**: Set this to *PasswordAuthenticator*.

     - **data_files_directories**: The location(s) where you want to store the data.

     - **seeds**: The IP address(es) of all the seeds in your Cassandra cluster. 3 seed nodes are recommended for every data center, preferably in different racks. If this node is being added to an existing cluster, ensure that the other nodes are available and reachable (default port is 7000).

     - **listen_address**: The IP address of the node.

     - **listen_on_broadcast_address**: Set this to *true*.

     - **rpc_address**: Set this to *0.0.0.0*.

     - **broadcast_rpc_address**: The IP address of the node.

     - **endpoint_snitch**: Set this to *GossipingPropertyFileSnitch*

     - **tombstone_warn_threshold**: Set to 1000000. Cassandra warns in the Debug.log whenever there are more tombstones than this threshold. This provides a good indication of when the *tombstone_failure_threshold* might be exceeded.

     - **tombstone_failure_threshold**: Set to 2000000. Queries will fail if a record has more tombstones than the value set here. Increases of this value will slow down your reads but might be manageable depending on the use case.

       > [!NOTE]
       > Tombstones are generated for each delete in the Cassandra database. The value of the *tombstone_failure_threshold* setting could influence data saved in an element. If an element has many updates on the same parameter in a short time span, this value might be exceeded, and saved data might not get displayed on the element card.

   - Make the following adjustments in the *cassandra-rackdc.properties* file based on your setup:

     - **dc**: The name of the data center where this node is located.

     - **rack**: The name of the rack where this node is located. These are logical racks and can be different from the physical racks.

     - **prefer_local**: Set this to *true*.

      > [!IMPORTANT]
      > To ensure even distribution of the replicas among the nodes within a data center, the replication factor should be a multiple of the number of racks.
      > General practice is to put all nodes of a data center in one rack.

1. Start Cassandra and evaluate if the service is up and running.

   - To start Cassandra, use the following command:

     `$ sudo systemctl start cassandra.service`

   - To check if Cassandra is running, use the following command (note that it can take a couple of seconds before the node is started):

     `$ nodetool status`

     If the node does note state UN (Up & Normal) in the *nodetool status* command, evaluate the logging. The logging is located at */var/log/cassandra/system.log*.

1. Configure the Cassandra cluster database in System Center. See [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

> [!IMPORTANT]
> In this setup, the Cassandra database is not managed by DataMiner, so it is essential that you manage it yourself (see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster)).
