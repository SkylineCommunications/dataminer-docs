---
uid: Installing_Cassandra
---

# Installing Cassandra on a Linux machine

If you want to use a Cassandra cluster as the general database for your DMS, you can install Cassandra on a Linux machine as follows. As we promoto the use of Ubuntu LTS as prefered linux distribution, the commands below are working on any DEBIAN based system (Ubuntu is DEBIAN based):

1. Install the Apache Cassandra software on a Linux machine.

   For more information on how to install the software, scroll down on the [Download Now](https://cassandra.apache.org/_/download.html) page of the Apache Cassandra website.
   
   Scroll down and follow the steps under: '**Installation from debian packages**'. You can follow step by step the installation process.
   

1. Ensure the firewall ports are open for Cassandra. See [Firewall ports used with Cassandra](xref:Cassandra_firewall).

   On Ubuntu you have a default firewall, however this is disabled.
   
   To enable the firewall, use the following command:
   
   `$ sudo ufw enable`
   
   Below Example shows the commands for a 3 node cluster.
   
   To add the correct ports to the firewall, you have to use following command: 
   
   Commands node1:
   
   `$ sudo ufw allow from [IP node2] to [IP node1] proto tcp port 7000,7001,9042`
   
   `$ sudo ufw allow from [IP node3] to [IP node1] proto tcp port 7000,7001,9042`
   
   Commands node2:
   
   `$ sudo ufw allow from [IP node1] to [IP node2] proto tcp port 7000,7001,9042`
   
   `$ sudo ufw allow from [IP node3] to [IP node2] proto tcp port 7000,7001,9042`
   
   Commands node3:
   
   `$ sudo ufw allow from [IP node1] to [IP node3] proto tcp port 7000,7001,9042`
   
   `$ sudo ufw allow from [IP node2] to [IP node3] proto tcp port 7000,7001,9042`
   
   Important!
   
   If you connect with SSH to your linux server, you also have to add port 22. This is possible with this command:
   
   `$ sudo ufw allow 22/tcp`

1. Prepare your data directory: If you are using a dedicated disk for the Cassandra data (which is advised for production environments), make sure you mount the correct drive to the folder and that the Cassandra user/group is configured on the folder.

1. If Cassandra is running, stop the service and clean up any files that were already created.

   - To stop Cassandra, use the following command:

     `$ sudo systemctl stop cassandra.service`

   - The content in the folders below should be removed, if there is any. In the *cassandra.yaml* file, you can find the configured locations of these folders.

     - data (default location: */var/lib/cassandra/data*)

         `$ sudo rm -r /var/lib/cassandra/data/*`

     - commitlogs (default location: */var/lib/cassandra/commitlog*)

         `$ sudo rm -r /var/lib/cassandra/commitlog/*`

     - hints (default location: */var/lib/cassandra/hints*)

         `$ sudo rm -r /var/lib/cassandra/hints/*`

     - saved caches (default location: */var/lib/cassandra/saved_caches*)

        `$ sudo rm -r /var/lib/cassandra/saved_caches/*`

1. Configure the *cassandra.yaml* and the *cassandra-rackdc.properties* files.

   To change these config files, following commands can be used:
   
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

> [!NOTE]
> In this setup, the Cassandra database is not managed by DataMiner, so it is important that you manage it yourself (see [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster)).
