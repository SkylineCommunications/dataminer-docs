---
uid: Configuring_multiple_datacenter_Elasticsearch_cluster
keywords: allocation awareness, elasticsearch
---

# Configuring multiple datacenter Elasticsearch cluster

> [!IMPORTANT]
> Elasticsearch is **only supported up to version 6.8**. We therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-hosted storage, using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch.
> A similar configuration exists on OpenSearch, there you can also configure [allocation awareness](xref:Configuring_Allocation_Awareness_OpenSearch).

## Allocation Awareness

 When hosting your ElasticSearch nodes in different data centers or racks or zones it's advised to use a functionality called **Allocation Awareness**. With this configuration you're sure your data is correctly spread between the different locations, and in case a location loses connection you still have all your data.

 You have 2 kinds of Allocation Awareness: Shard Allocation Awareness and Forced Awareness.
 The difference between both is how they handle the shards when a location is suddenly unreachable.

**Allocation Awareness** will assign all the missing replica's shards to the still running nodes in the other location(s). This can cause a big load on the still running nodes. If your nodes wouldn't be able to handle this, you can solve this by using **Forced Awareness**. Forced Awareness will **never** allowing copies of the same shard to be allocated to the same location(s).

You also can find more information on this topic on the website of [ElasticSearch](xref:https://www.elastic.co/guide/en/elasticsearch/reference/6.8/allocation-awareness.html).

> [!IMPORTANT]
> We advise to use the **Allocation Awareness**, as the **Forced Awareness** hasn't been tested yet.

## Configuration of Allocation Awareness

To configure the Allocation Awareness you need to add some parameters in the elasticsearch.yaml file on each node. To do this, stop the ElasticSearch service on your linux server. For debian based systems you can do this with following command:

```debian
sudo systemctl stop elasticsearch.service
```

Now change the elasticsearch.yml file that is standard located in /etc/elasticsearch/ folder.

In below example you can see how the configuration would look like in a 6 node cluster spread over 2 data centers:

node 1, 2 and 3 in data center 1:

```yaml
node.attr.DC: DC1
cluster.routing.allocation.awareness.attributes: DC
```

node 4, 5 and 6 in data center 2:

```yaml
node.attr.DC: DC2
cluster.routing.allocation.awareness.attributes: DC
```

with above configuration we create a new attribute for the Allocation Awareness called **DC**, and we configure it with the value DC1 or DC2.

Once every elasticsearch.yaml file has been changed. You can now start the service again. For debian based OS, you can use following command:

```debian
sudo systemctl start elasticsearch.service
```

Once the service is running, we have to let our ElasticSearch cluster know that we configured this. You can do this easily with a PUT message. This can be done from Kibana or from a postman session:

```PUT
PUT http://[IP of node]:9200/_cluster/settings
{ 
    "persistent": 
        { 
            "cluster.routing.allocation.awareness.attributes" : "DC" 
        } 
}
```

After doing this, the ElasticSearch cluster will start moving data, this can take a while depending on how many data is already stored in your database.
