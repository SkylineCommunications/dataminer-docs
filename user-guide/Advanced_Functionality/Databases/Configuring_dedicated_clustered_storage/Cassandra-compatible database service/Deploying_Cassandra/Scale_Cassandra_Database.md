---
uid: Scale_Cassandra_Database
---

# Adding and removing nodes in a Cassandra cluster database

## Adding nodes

To add nodes to a Cassandra cluster, install Cassandra as detailed in [Installing Cassandra](xref:Installing_Cassandra).

Initially *nodetool status* will show the node as UJ (Up & Joining). Once a node is fully joined, it will be listed as UN (Up & Normal).

When a node is added, other nodes will push some of the data to the new node, as all data will now be redivided across all nodes. All nodes will now be responsible for a smaller set of data. However, the partitions that no longer need to be hosted by the existing nodes after the new node has joined will still need to be removed. You can do so by running the *nodetool cleanup* command on every node that was already included in the cluster previously.

## Removing nodes

To remove a node, first **check the status** of the node you want to remove using the *nodetool status* command.

- If the node is **up**, run the *nodetool decomission* command on the node you want to remove. You can use the *nodetool netstats* command to monitor the progress.

- If the node is **down**, removing it may lead to data loss if you have keyspaces with RF1. In case your cluster does not use vnodes (which are used by default), you need to adjust the tokens to evenly distribute the data across the remaining nodes. Run the nodetool command *removenode command* for the *Host ID* of the node on one of the nodes that is still up. Then initiate a repair on all data to ensure that all nodes have the correct data.
