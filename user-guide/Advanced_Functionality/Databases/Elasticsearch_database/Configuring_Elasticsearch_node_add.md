---
uid: Configuring_Elasticsearch_node_add
---

# Adding an Elasticsearch cluster node

## Prerequisites

- On the node to be added, make sure the data folder is empty. In the *elasticsearch.yml* file, you can find the data folder in the `path.data` setting.
- Make sure the Elasticsearch service is stopped. Data will be added to the data folder as soon as the service is started again.
- On the node to be added, make sure port 9200 and 9300 are open. Note that these are the default ports and that alternative ports can be defined in the *elasticsearch.yml* file.
- If you intend to add the node to a single-node cluster, make sure that node also has ports 9200 and 9300 open. Note that these are the default ports and that alternative ports can be defined in the *elasticsearch.yml* file.
- Make sure the `network.host` is bound to an IP address that is accessible to the other nodes in the cluster (other than `127.0.0.1`).
- Make sure the `network.publish_host` is bound to an IP address that is accessible to the other nodes in the cluster (other than `127.0.0.1`). If this setting is not explicitly defined, its value will be inherited from `network.host`.

## Adding the node

1. On the node to be added to the cluster, open the *elasticsearch.yml* file and configure the following settings:

    | Setting | Description |
    |---------|-------------|
    | cluster.name:NAME | This name should be identical to the cluster name specified on the other nodes. |
    | network.host:IP | Make sure the `network.host` is bound to an IP address that is accessible to the other nodes in the cluster (other than `127.0.0.1`). |
    | Network.publish_host:IP | Make sure the `network.publish_host` is bound to an IP address that is accessible to the other nodes in the cluster (other than `127.0.0.1`). If this setting is not explicitly defined, its value will be inherited from `network.host`. |
    | discovery.zen.minimum_master_nodes:X | This value should be identical to the `discovery.zen.minimum_master_nodes` values specified on the other nodes. For more information on this setting, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes). |
    | node.master:false | In most cases, this setting will be set to false. For more information on this setting, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes). |
    | discovery.zen.ping.unicast.hosts:[“IP1”, “IP2”, ...] | This setting should contain the IP addresses of the (master) nodes in the cluster. |

1. Start the node to have it added to the cluster.

> [!TIP]
> See also: [Standalone Elasticsearch Cluster Installer](xref:Standalone_Elasticsearch_Cluster_Installer)

## Confirming that the node has been added

To get confirmation that the node has successfully been added to the cluster, execute the `_cat/nodes` query on any of the other nodes in the cluster.

## Adding a potential master node

In some cases, (multiple) potential master nodes should be added to the cluster.

On those potential master nodes, `node.master` must be set to true and `discovery.zen.minimum_master_nodes` must contain the minimum number of potential master nodes in the cluster. Note that the latter should also be adjusted on the existing potential master nodes.

After configuring the necessary settings on the potential master node to be added, restart the existing (potential) master nodes, and then start the potential master node to be added.

For more information on master nodes, see [Configuring the master nodes](xref:Configuring_master_Elasticsearch_nodes).
