---
uid: Installing_Cassandra_Reaper
---

# Installing Cassandra Reaper

Cassandra Reaper is an application that can manage Cassandra cluster repairs on its own without the need of extra external management.

> [!NOTE]
> As setting up the remote JMX communication port in a secure way can be very challenging on the Cassandra nodes, we advise that you deploy the Cassandra reaper application on all the Cassandra nodes and configure it to run in SIDECAR mode. This will allow Cassandra Reaper to work without relying on the JMX communication ports on the Cassandra nodes.

1. Install the Cassandra Reaper software by following the installation steps on the [Cassandra Reaper installation page](http://cassandra-reaper.io/docs/download/install/).

1. Create a keyspace in Cassandra for Reaper to use, by running a CQL command as illustrated below, adjusted to match the [Keyspace Replication Strategy](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/architecture/archDataDistributeReplication.html) of your choice:

   Single datacenter example: (Cassandra Cluster where all nodes reside in a single datacenter)
   ```txt
   CREATE KEYSPACE "reaper_db"
   WITH durable_writes = true
   AND replication = 
   {
    'class' : 'SimpleStrategy',
    'replication_factor' : 2
   };
   ```

   Multi datacenter example: (Cassandra Cluster where nodes have been divided over multiple datacenters)
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

    > [!NOTE]
    > It's advised to always use a replication factor greater than value '1' on the newly created keyspace as that will also provide robustness when data is being requested from nodes in the cassandra cluster. With rf < 2 you are at risk that data request can fail in case the node which is hosting the data, is not available to serve the request. When this is the case, Cassandra Reaper will no longer function properly and will present errors in its logging such as: 
    > "Caused by: com.datastax.driver.core.exceptions.NoHostAvailableException: All host(s) tried for query failed (tried: /10.66.117.69:9042 (com.datastax.driver.core.exceptions.UnavailableException: Not enough replicas available for query at consistency LOCAL_ONE (1 required but only 0 alive)), /10.66.117.67:9042 (com.datastax.driver.core.exceptions.UnavailableException: Not enough replicas available for query at consistency LOCAL_ONE (1 required but only 0 alive)))"


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
