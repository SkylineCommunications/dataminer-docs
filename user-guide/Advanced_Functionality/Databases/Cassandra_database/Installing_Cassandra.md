---
uid: Installing_Cassandra
---

# Installing Cassandra on a Linux machine

1. Install the Apache Cassandra software on a Linux machine.

   For more information on how to install the software, scroll down on the [Download Now](https://cassandra.apache.org/_/download.html) page of the Apache Cassandra website.

1. Ensure the firewall ports are open for Cassandra.

   All ports can be customized in the *cassandra.yaml* file. By default you will need port 7000 (inter-node) and 9042 (client), but below you can see all default ports.
   
   - 7000: Cassandra inter-node cluster communication.
   - 7001: Cassandra SSL inter-node cluster communication.
   - 7199: Cassandra JMX monitoring port.
   - 9042: Cassandra client port.

1. Prepare your data directory.

   If you are using a dedicated disk for the Cassandra data (which is advised for production environments). Make sure you mount the correct drive to the folder and that the Cassandra user/group is configured on the folder.

1. If Cassandra is/was already running, stop the service and clean up any files that were already created.

   Stopping Cassandra: 
   $ sudo systemctl stop cassandra.service
   
   Remove the content from the below folders if any. Evaluate your *cassandra.yaml* file to know the configured locations of these folders.
   - data (default location: */var/lib/cassandra/data*)
   - commitlogs (default location: */var/lib/cassandra/commitlog*)
   - hints (default location: */var/lib/cassandra/hints*)
   - saved caches (default location: */var/lib/cassandra/saved_caches*)

1. Configure the *cassandra.yaml* and the *cassandra-rackdc.properties* files.

   We suggest to make the following adjustments in the *cassandra.yaml* based on your setup:
   - cluster_name
   This needs to be the same for all nodes in your Cassandra cluster.
   - authenticator
   Set this to *PasswordAuthenticator*.
   - data_files_directories
   Put here the location(s) wher you want to store the data
   - seeds
   Put the IP address(es) of all the seeds in your Cassandra cluster. It is advised to have 3 seed nodes for every datacenter, preferably in different racks. If this node is being added to an existing cluster, ensure the other nodes are available and reachable (default port is 7000).
   - listen_address
   Set this to the IP of the node.
   - listen_on_broadcast_address
   *true*
   - rpc_address
   *0.0.0.0*
   - broadcast_rpc_address
   Set this to the IP of the node.
   - endpoint_snitch
   *GossipingPropertyFileSnitch*
   - hinted_handoff_throttle_in_kb
   *10240*
   - max_hints_delivery_threads
   *12*
   
   We suggest to make the following adjustments in the *cassandra-rackdc.properties* based on your setup:
   - dc
   The name of the datacenter in which this node is located.
   - rack
   The name of the rack in which this node is located.
   - prefer_local
   *true*
  
1. Start Cassandra and evaluate if the service is up and running.

   Starting Cassandra: 
   $ sudo systemctl start cassandra.service
   
   Check if Cassandra is running (could take a couple of seconds before the node is started):
   $ nodetool status
   
   If the node is not stating UN (Up & Normal) in the *nodetool status* command, evaluate the logging. The logging is located at */var/log/cassandra/system.log*.

Next Step: [Configuring Cassandra in System Center](xref:Configuring_DataMiner_Cassandra)