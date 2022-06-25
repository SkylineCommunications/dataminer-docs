---
uid: Installing_Cassandra_Reaper
---

# Installing Cassandra Reaper

Cassandra-Reaper is an application which will manage the Cassandra cluster repairs on its own without the need of extra external management.

1. Install the Cassandra Reaper software.

   As setting up remote JMX communication port in a secure way can be very challenging on the Cassandra nodes, we advise to deploy the Cassandra reaper application on all the Cassandra nodes and configure it to run in SIDECAR mode. This will allow Cassandra reaper to run its magic without relying on the JMX communication ports on the Cassandra nodes.
   Install the software by following the installation steps on the Cassandra Reaper [Install webpage](http://cassandra-reaper.io/docs/download/install/).

1. Create a keyspace in Cassandra for Reaper to use.

   Run the following CQL command to create the keyspace (adjust the networktopology to your setup).

   CREATE KEYSPACE "reaper_db"
   WITH durable_writes = true
   AND replication = 
   {
    'class' : 'NetworkTopologyStrategy',
    'datacenter1' : 3,
    'datacenter2' : 3,
    'datacenter3' : 3
   };

1. Ensure the firewall ports are open for the webpage.
   
   The default ports used for the webpage are ports 8080 and 8081.

   > [!NOTE]
   > All ports can be customized in the *cassandra-reaper.yaml* file.

1. Configure the *cassandra-reaper.yaml* file.

   The *cassandra-reaper.yaml* file is located in the */etc/cassandra-reaper* folder.
   We suggest to start from the example file *cassandra-reaper-cassandra-sidecar.yaml* located in the */etc/cassandra-reaper/configs* folder and adjust it to your system.
   
   Enable autoscheduling to let reaper schedule the repairs automatically.   
   Under the Cassandra configuration you will need to add the authProvider tag to provide credential for Cassandra.
   For more information on the different options, you can check the [Reaper documentation](http://cassandra-reaper.io/docs/configuration/).
  
1. Start the service.

   Starting Cassandra Reaper: 
   $ systemctl start cassandra-reaper.service
   
   Check if Reaper is running by going to the webpage:
   http://[cassandra_node_ip]:8080/webui
   default credentials: admin/admin