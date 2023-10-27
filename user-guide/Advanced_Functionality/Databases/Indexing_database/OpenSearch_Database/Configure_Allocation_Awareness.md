---
uid: Configuring_Allocation_Awareness_OpenSearch
keywords: allocation awareness, opensearch
---

# Configuring multiple datacenter Elasticsearch cluster

## Allocation Awareness

 When hosting your OpenSearch nodes in different data centers or racks or zones it's advised to use a functionality called **Allocation Awareness**. With this configuration you're sure your data is correctly spread between the different locations, and in case a location loses connection you still have all your data.

 You have 2 kinds of Allocation Awareness: Shard Allocation Awareness and Forced Awareness.
 The difference between both is how they handle the shards when a location is suddenly unreachable.

**Allocation Awareness** will assign all the missing replica's shards to the still running nodes in the other location(s). This can cause a big load on the still running nodes. If your nodes wouldn't be able to handle this, you can solve this by using **Forced Awareness**. Forced Awareness will **never** allowing copies of the same shard to be allocated to the same location(s).

You also can find more information on this topic on the website of [Opensearch](https://opensearch.org/docs/latest/tuning-your-cluster/index/#shard-allocation-awareness).

> [!IMPORTANT]
> We advise to use the **Allocation Awareness**, as the **Forced Awareness** hasn't been tested yet.

## Configuration of Allocation Awareness

To configure the Allocation Awareness you need to add some parameters in the opensearch.yaml file on each node. To do this, stop the OpenSearch service on your linux server. For debian based systems you can do this with following command:

```debian
sudo systemctl stop opensearch.service
```

Now change the opensearch.yaml file that is standard located in /etc/opensearch/ folder.

In below example you can see how the configuration would look like in a 6 node cluster spread over 2 data centers:

node 1, 2 and 3 in data center 1:

```yaml
node.attr.zone: zoneA
```

node 4, 5 and 6 in data center 2:

```yaml
node.attr.zone: zoneB
```

with above configuration we assigned a new atrribute called zone a specific value for the Allocation Awareness , in the example we used zoneA and zoneB.

Once every opensearch.yaml file has been changed. You can now start the service again. For debian based OS, you can use following command:

```debian
sudo systemctl start opensearch.service
```

Once the service is running, we have to let our OpenSearch cluster know that we configured this. You can do this easily with a PUT message. This can be done from Kibana or from a postman session:

```PUT
PUT http://[IP of node]:9200/_cluster/settings
{ 
    "persistent": 
        { 
            "cluster.routing.allocation.awareness.attributes" : "zone" 
        } 
}
```

After doing this, the OpenSearch cluster will start moving data, this can take a while depending on how many data is already stored in your database.
