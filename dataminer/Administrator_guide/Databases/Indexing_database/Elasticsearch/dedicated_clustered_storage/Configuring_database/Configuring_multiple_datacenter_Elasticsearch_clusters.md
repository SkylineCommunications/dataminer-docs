---
uid: Configuring_multiple_datacenter_Elasticsearch_cluster
keywords: allocation awareness, elasticsearch
---

# Configuring a multiple data center Elasticsearch cluster

> [!IMPORTANT]
> Elasticsearch is **only supported up to version 6.8**, which is no longer supported by Elastic. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-managed storage even though this is not recommended, using [OpenSearch](xref:OpenSearch_database).

When the nodes in the Elasticsearch cluster are hosted in different data centers, racks, or zones, you should use **allocation awareness**. This will ensure that the data is correctly spread between the different locations and that you will still have all your data in case the connection to a location is lost.

There are two kinds of allocation awareness: shard allocation awareness and forced awareness. The difference between these two is the way they handle the shards when a location is suddenly unreachable. **Shard allocation awareness** will assign the shards of the missing replicas nodes that can still be reached in the other locations. This can cause a big load on those nodes. If your nodes would not be able to handle this, you can solve this by using **forced awareness** instead. Forced awareness will never allow copies of the same shard to be allocated to the same locations.

> [!IMPORTANT]
> We recommend using **shard allocation awareness**, as we have not yet tested setups with **forced awareness**.

> [!TIP]
> For more information , refer to [Allocation Awareness](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/allocation-awareness.html) in the Elasticsearch documentation.

> [!NOTE]
> A similar configuration exists on OpenSearch. There you can also configure [allocation awareness](xref:Configuring_multiple_datacenter_OpenSearch_cluster).

## Configuring allocation awareness

To configure allocation awareness, you will need to add some parameters in the elasticsearch.yaml file on each node. To do so:

1. Stop the Elasticsearch service on the Linux server.

   For Debian-based systems, you can do this with following command:

   ```debian
   sudo systemctl stop elasticsearch.service
   ```

1. Open the *elasticsearch.yaml* file. By default this is located in the `/etc/elasticsearch/` folder.

1. Adjust the configuration as necessary.

   For example, below you can see what the configuration would look like in a 6-node cluster spread over 2 data centers:

   - Node 1, 2, and 3 in data center 1:

     ```yaml
     node.attr.DC: DC1
     cluster.routing.allocation.awareness.attributes: DC
     ```

   - Node 4, 5, and 6 in data center 2:

     ```yaml
     node.attr.DC: DC2
     cluster.routing.allocation.awareness.attributes: DC
     ```

   With this example configuration, a new attribute called *DC* is created for the allocation awareness, and it is configured with the values *DC1* and *DC2*.

1. When each *elasticsearch.yaml* file has been changed, start the Elasticsearch service again.

   For Debian-based systems, you can use following command:

   ```debian
   sudo systemctl start elasticsearch.service
   ```

1. Notify the Elasticsearch cluster that this has been configured. You can do this with a PUT message.

   This can be done from Kibana or from a Postman session:

   ```PUT
   PUT http://[IP of node]:9200/_cluster/settings
   { 
       "persistent": 
           { 
               "cluster.routing.allocation.awareness.attributes" : "DC" 
           } 
   }
   ```

The Elasticsearch cluster will now start moving data. Depending on how much data is already stored in your database, this can take a while.
