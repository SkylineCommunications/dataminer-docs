---
uid: NodeRecovery_Detection
---

# Outage detection

On every node in the DataMiner cluster, a DataMiner NodeRecovery module keeps an eye on the other nodes. It does this by exchanging heartbeats over the NATS communication bus. If a node has not seen heartbeats from a certain node for a period of time, that observing node will mark the other node as being in outage.

Different [node states](xref:NodeRecovery_States) are possible based on this: *Healthy*, *Outage*, or *Unknown*.

Any detected state changes can trigger [outage scripts](xref:NodeRecovery_Triggers). These can perform actions such as rebalancing of functionality to healthy nodes. If multiple state changes are detected at the same time, a trigger script is only executed once.

The intervals at which heartbeats get sent out and outage detection times can be configured in the [Node Recovery settings](xref:NodeRecovery_Settings).

## Supported outage types

At present, DataMiner Node Recovery can detect **full server outages**, where machines cannot reach each other over the network. These scenarios include power or network cuts.

In its current version, NodeRecovery will **not** detect scenarios where a server is still running but the DataMiner software is not running, blocked, or unable to start up.

## Local vs. global detection

### Local detection

Every node managed by Node Recovery maintains a local view of the cluster from its own viewpoint. This means that multiple nodes can see a different state, for example, when a link is down between two specific nodes but not from those nodes to other nodes.

Whenever the local state changes, [a script can be triggered](xref:NodeRecovery_Triggers). Keep in mind that this will trigger the script on any node that has observed a change in its local view.

### Global detection

Node Recovery also maintains a global cluster view. In this view, a consensus is made about which nodes are in outage based on the local views from all nodes in the cluster.

The global state is calculated and maintained by an elected leader node. When a leader node goes down, a new leader is elected automatically, provided the majority of the nodes are still available. If there is no cluster majority, no global state changes will be detected until the cluster majority is restored.

The leader node aggregates local state views from all nodes in the cluster and determines the global consensus state. For detailed information on how the global state is calculated from local view states, refer to [Global state calculation](xref:NodeRecovery_States#global-state-calculation) .

When the global cluster state changes, [a script can be triggered](xref:NodeRecovery_Triggers#global-state-change) on the leader node to perform centralized cluster management actions.

## Network splits

Global outage detection will only be active when **more than half of the total nodes** in the cluster can reach each other.

For example, there will be no global detection while a four-node cluster is temporarily split up into two parts of two nodes each. Alternatively, if a six-node cluster gets split into a group of four nodes and a group of two nodes because of a network split, the group of four nodes will still calculate the global state while reporting the other two nodes as being in outage.

At all times, each individual node will still calculate and update its local view of the cluster, and it can still [trigger a script](xref:NodeRecovery_Triggers) when this local view changes.
