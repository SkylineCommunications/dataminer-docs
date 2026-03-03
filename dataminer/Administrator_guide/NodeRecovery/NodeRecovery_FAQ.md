---
uid: NodeRecovery_FAQ
---

# Frequently asked questions about Node Recovery

## Can I mark a node as being in maintenance?

Yes. See [Maintenance mode](xref:NodeRecovery_States#maintenance-mode) for more information.

## Can Node Recovery detect DataMiner itself going down?

Not yet. Node Recovery's [outage detection](xref:NodeRecovery_Detection) currently only supports outages where machines cannot reach each other over the network. These scenarios include power or network cuts, but do not cover scenarios where the server is still running but DataMiner is unable to start or is no longer running correctly.

## How does NodeRecovery deal with network splits?

Only the part of the cluster that has more than half of the total nodes will be able to detect outages using the global detection mechanism. See [Network splits](xref:NodeRecovery_Detection#network-splits) for more information.

## What technology does Node Recovery use behind the scenes?

- Heartbeats are sent over the NATS communication bus.
- Scripts are launched through an SLNet connection to the local (healthy) Agent.
- The Raft leader election algorithm is used to determine which Agent triggers [global state change scripts](xref:NodeRecovery_Triggers#global-state-change).

> [!TIP]
> For more information, refer to [In Search of an Understandable Consensus Algorithm](https://classpages.cselabs.umn.edu/Spring-2018/csci8980/Papers/Consensus/Raft.pdf)

## What happens if Node Recovery is installed on a DataMiner Agent where Swarming is not enabled?

The *NodeRecovery* service will start up but will not send out heartbeats or perform outage detection. It will also not trigger any scripts. Once swarming is enabled, Node Recovery will automatically start functioning without requiring a restart of the service.

## Are any actions required after adding a new node to the cluster or removing a node from the cluster?

After adding a new node to the cluster or removing a node from the cluster, no actions are required.

If a node is added, Node Recovery will automatically discover the new node through SLNet and start monitoring it.

If a node is removed, NodeRecovery will automatically detect that the node is no longer present through SLNet and will stop monitoring it.

## Where can I find the NodeRecovery log files?

See [Node Recovery troubleshooting](xref:NodeRecovery_Troubleshooting).

## How many DataMiner Agents are required to use Node Recovery?

NodeRecovery requires a cluster of at least two DataMiner Agents to monitor each other for outages and launch local state change scripts. However, global state change detection requires at least three DataMiner Agents.

## Is there a change log available for Node Recovery?

Yes. See [Node Recovery change log](xref:NodeRecovery_change_log) for a detailed list of changes per version.
