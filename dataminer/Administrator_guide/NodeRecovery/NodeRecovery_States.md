---
uid: NodeRecovery_States
---

# Node states in NodeRecovery

## Available states

When one node looks at another node, it can see this node in three different states. These states exist both in the local view (how one specific node sees another node) and in the global view (the cluster-wide consensus on node states).

### Healthy

**Local view:** The node is considered to be alive from the observing node's perspective. Heartbeats have been received from this node recently.

**Global view:** In general, a node is marked as Healthy as soon as one voting node sees it as Healthy. See [Global state calculation](#global-state-calculation) for detailed information.

### Outage

**Local view:** When no heartbeats have been received for a period of time from the observing node's perspective, the node is considered to be in outage.

**Global view:** In general, a node gets marked as being in Outage state when no voting node sees it as Healthy and a cluster majority of voters agrees that the node is in outage. See [Global state calculation](#global-state-calculation) for detailed information.

### Unknown

**Local view:** Initial state for nodes before an initial heartbeat has been received from that node. This occurs when the NodeRecovery module starts up or after remote nodes have notified that they expect to have downtime (e.g., on restarts).

**Global view:** A node gets marked as Unknown globally in scenarios where it cannot be determined whether it is Healthy or in Outage. See [Global state calculation](#global-state-calculation) for detailed information.

## Local state transitions

Based on the [detection](xref:NodeRecovery_Detection), nodes can transition between local view states.

On startup of a NodeRecovery node, all nodes in that node's local view state will start out in the `Unknown` state.

| From State | To State | Trigger |
| ---------- | -------- | ------- |
| Unknown | Healthy | First heartbeat received from the node |
| Unknown | Outage | `FirstHeartbeatThresholdMilliseconds` exceeded without receiving a heartbeat |
| Healthy | Outage | `OutageThresholdMilliseconds` exceeded without receiving a heartbeat |
| Healthy | Unknown | Remote node notifies of expected downtime (e.g., restart) |
| Outage | Healthy | Heartbeat received from the node after outage |
| Outage | Unknown | Remote node notifies of expected downtime (e.g., restart) |

```mermaid
---
config:
  themeCSS: |
    #edge1, #edge2 { stroke: red; }
    #edge0, #edge4 { stroke: lightgreen; }
    #edge3, #edge5 { stroke: lightgray; }
---
stateDiagram-v2
    Unknown --> Healthy:  heartbeat
    Unknown --> Outage: no heartbeat
    Healthy --> Outage: no heartbeat
    Healthy --> Unknown: expected downtime 
    Outage --> Healthy: heartbeat
    Outage --> Unknown: expected downtime
```

## Global state calculation

How global state is calculated from local view states:

- If the cluster does not have an elected leader node, global outage detection is not active. There is no leader if the cluster has less than three nodes or if each node sees a majority of other nodes as Outage (when a majority of nodes is actually down, or because of certain [network splits](xref:NodeRecovery_Detection#network-splits)).
- Nodes that get to vote are those observed from the leader's perspective as being Healthy. If there are not enough voters to reach a cluster majority, global outage detection is not active.
- A node is marked as Healthy as soon as one voter sees it as Healthy
- A node is marked as being in Outage state when no voter sees the node as Healthy and a cluster majority of voters agrees that the node is in outage (e.g. in a 4 or 5 node cluster, at least 3 voters need to see it as Outage).
- A node is marked as Unknown when in other scenarios, e.g. no voters see the node as Healthy and there is no cluster majority agreement on Outage among voters

## Maintenance

Next to the above states, nodes can also be put into maintenance mode. This is a separate flag that can be set on a node, on top of the Healthy, Outage and Unknown states.

Setting one or more nodes into maintenance mode does not affect the sending or receiving of heartbeats, nor does it affect outage detection in any way.

The [triggered scripts](xref:NodeRecovery_Triggers) do receive extra information about whether a node is in maintenance mode or not, so that custom logic can be applied when needed. The scripts are also executed whenever one or more nodes enter or leave maintenance mode, even if no other state changes occur.
