---
uid: NodeRecovery_Detection
---

# NodeRecovery Detection

## Types of outages supported

NodeRecovery can detect full server outages, where machines cannot reach each other over the network. These scenarios include power or network cuts.

In the future, NodeRecovery will also be able to detect scenarios where a server is still running but the DataMiner software is either not running, blocked, or unable to start up.

## Outage detection

On every node in the DataMiner cluster, a DataMiner NodeRecovery module keeps an eye on the other nodes. It does this by exchanging heartbeats over NATS. If a node has not seen heartbeats from a certain node for a period of time, that observing node will mark the other node as being in outage.

See [Node States](xref:NodeRecovery_States) for an overview of available node states (Healthy, Outage, Unknown).

Any detected state changes trigger [outage scripts](xref:NodeRecovery_Triggers), which can perform actions such as rebalancing of functionality to healthy nodes. If multiple state changes are detected at the same time, the script is only executed once.

The intervals at which heartbeats get sent out and outage detection times can be configured in the [NodeRecovery settings](xref:NodeRecovery_Settings).

## Local vs global detection

### Local

Within NodeRecovery, every node maintains a local view of the cluster from its own viewpoint. This means that multiple nodes can see a different state, e.g., when there is a link down between two nodes specifically but not from those nodes to other nodes.

Whenever the local state changes, [a script can be triggered](xref:NodeRecovery_Triggers). Be aware that the script will trigger on any node that has observed a change in its local view.

### Global

NodeRecovery also maintains a global cluster view. In this view, a consensus is made about which nodes are in outage based on the local views from all nodes in the cluster.

The global state is calculated and maintained by an elected leader node. When a leader node goes down, a new leader is elected automatically, provided there is still a majority of nodes available. If there is no cluster majority, no global state changes will be detected until the cluster majority is restored.

The leader node aggregates local state views from all nodes in the cluster and determines the global consensus state. See [Node States](xref:NodeRecovery_States#global-state-calculation) for detailed information on how global state is calculated from local view states.

When the global cluster state changes, [a script can be triggered](xref:NodeRecovery_Triggers#global-state-change) on the leader node to perform centralized cluster management actions.

## Network splits

Global outage detection will only be active when more than half of the total nodes in the cluster can reach each other. For example, there will be no global detection while a 4-node cluster is temporarily split up into two parts of 2 nodes each. If a 6 node cluster gets split into a group of 4 nodes and a group of 2 nodes because of a network split, the group of 4 nodes will still calculate global state while reporting the other 2 nodes as being in outage.

At all times, each individual node will still calculate and update its local view of the cluster and will still [trigger](xref:NodeRecovery_Triggers) when this local view changes.
