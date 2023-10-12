---
uid: Configuring_Elasticsearch_node_remove
---

# Removing an Elasticsearch cluster node

## Prerequisites

Look up the IP address of the node to be removed. To list the IP addresses of all nodes in the cluster, execute the `_cat/nodes` query.

## Decommissioning the node

Execute the following code to transfer all data to the other nodes (replace `X.X.X.X` by the IP address of the node to be removed):

```txt
PUT _cluster/settings
{
"transient" :{
"cluster.routing.allocation.exclude._ip" : "X.X.X.X"
}
}
```

Execute the `_cluster/health` query to check whether the decommissioning procedure has finished. If the procedure has finished, the number of relocating shards will be 0.

## Removing the node

- Make sure the *elasticsearch.yml* files of the other nodes no longer contain any reference to the IP address of the node that will be removed. Typically, a reference to that IP address can be found in the `discovery.zen.ping.unicast.hosts` setting.
- Make sure the *DB.xml* files of the other nodes no longer contain any reference to the IP address of the node that will be removed.
- Stop the Elasticsearch service.
- Update the *elasticsearch.yml* file of the node that will be removed:

  - Change the cluster name (optional).
  - Remove any seed IP addresses from the `discovery.zen.ping.unicast.hosts` setting.
  - Reset `discovery.zen.minimum_master_nodes` to 1

- On the node that will be removed, make sure the data folder is empty. In the *elasticsearch.yml* file, you can find the data folder in the `path.data` setting.

## Making sure the node can be added again later

When you decide to add a previously decommissioned node to a cluster, by default, no data will be sent to this node. To prevent this from happening, you can overrule this default behavior by running the following code:

```txt
PUT _cluster/settings
{
"transient" :{
"cluster.routing.allocation.exclude._ip" : ""
}
}
```

## Removing a potential master node

After removing a potential master node (i.e. a node of which the `node.master` property was set to true in the *elasticsearch.yml* file), you will probably need to promote another node to potential master node. To do so, change the `node.master` property of that node from false to true, and restart it.

For more information on master nodes, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).
