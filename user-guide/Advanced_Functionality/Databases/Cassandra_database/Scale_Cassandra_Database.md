---
uid: Scale_Cassandra_Database
---

# Scaling the Cassandra database

1. Adding nodes

   When you want to add nodes to you Cassandra cluster. You must install Cassandra by following the steps from the [Installing Cassandra](xref:Installig_Cassandra) page. Initially *nodetool status* will show the node as UJ (Up & Joining), once the node is fully joined it will be listed as UN (Up & Normal). Once the node has been added, the data other nodes will have pushed some of the data to the new node as all data will have been redivided between all nodes. All nodes will now be responsible for a smaller set of data. The partitions that no longer need to be hosted by the nodes that were on there prior to the join of the new node will still need to be removed. This can be done by running the *nodetool cleanup* command on every node that was previously in the cluster.

1. Removing nodes

   Check through the *nodetool status* command the state of the node you want to remove.

   If the node is up:
   Run the *nodetool decomission* command on the node you want to remove. You can use the *nodetool netstats* command to monitor the progress.
      
   If the node is down (might lead to data loss if you have keyspaces with RF1):
   In case your cluster does not use vnodes (by default vnodes are used), you need to adjust the tokens to evenly distribute the data across the remaining nodes. 
   Run the nodetool *removenode command* command for the *Host ID* of the node on one of the nodes that is still up. Initiate a repair on all data to ensure all nodes have the correct data.