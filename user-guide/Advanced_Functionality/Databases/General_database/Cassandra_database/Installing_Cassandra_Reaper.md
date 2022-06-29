---
uid: Installing_Cassandra_Reaper
---

# Installing Cassandra Reaper

Cassandra Reaper is an application that can manage Cassandra cluster repairs on its own without the need of extra external management.

> [!NOTE]
> As setting up the remote JMX communication port in a secure way can be very challenging on the Cassandra nodes, we advise that you deploy the Cassandra reaper application on all the Cassandra nodes and configure it to run in SIDECAR mode. This will allow Cassandra Reaper to work without relying on the JMX communication ports on the Cassandra nodes.

1. Install the Cassandra Reaper software by following the installation steps on the [Cassandra Reaper installation page](http://cassandra-reaper.io/docs/download/install/).

1. Create a keyspace in Cassandra for Reaper to use, by running a CQL command as illustrated below, adjusted to match your network topology:

   ```txt
   CREATE KEYSPACE "reaper_db"
   WITH durable_writes = true
   AND replication = 
   {
    'class' : 'NetworkTopologyStrategy',
    'datacenter1' : 3,
    'datacenter2' : 3,
    'datacenter3' : 3
   };
   ```

1. Make sure the firewall ports are open for the webpage.

   The default ports used for the webpage are ports 8080 and 8081.

   > [!NOTE]
   > All ports can be customized in the *cassandra-reaper.yaml* file.

1. Configure the *cassandra-reaper.yaml* file.

   You can find this file in the */etc/cassandra-reaper* folder.

   We suggest that you start from the example file *cassandra-reaper-cassandra-sidecar.yaml* located in the */etc/cassandra-reaper/configs* folder and adjust it to your system:

   - Enable autoscheduling to let reaper schedule the repairs automatically.

   - Under the Cassandra configuration, add the authProvider tag to provide credential for Cassandra.

   For more information on the different options, refer to the [Reaper documentation](http://cassandra-reaper.io/docs/configuration/).
  
1. Start the service by running the following command:

   `$ systemctl start cassandra-reaper.service`

1. Check if Reaper is running by going to the webpage `http://[cassandra_node_ip]:8080/webui`. The default credentials are admin/admin.
