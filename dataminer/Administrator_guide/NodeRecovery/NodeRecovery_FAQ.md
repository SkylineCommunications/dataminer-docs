---
uid: NodeRecovery_FAQ
---

# NodeRecovery Frequently Asked Questions

## Can I mark a node as being in maintenance?

Yes. See [Node states in NodeRecovery](xref:NodeRecovery_States#maintenance) for more information.

## Can NodeRecovery detect DataMiner itself going down?

Not yet. [Outage detection in NodeRecovery](xref:NodeRecovery_Detection) currently only supports outages where machines cannot reach each other over the network. These scenarios include power or network cuts, but do not cover scenarios where the server is still running but DataMiner is unable to start or has crashed.

## How does NodeRecovery deal with network splits?

Network splits are covered in [Outage detection in NodeRecovery](xref:NodeRecovery_Detection). In short, only the part of the cluster that has more than half of the total nodes will be able to detect outages using the global detection mechanism. See [Network splits](xref:NodeRecovery_Detection#network-splits) for more information.

## What technology does NodeRecovery use behind the scenes?

- Heartbeats are sent over the NATS communication bus.
- Scripts are launched through an SLNet connection to the local (healthy) agent.
- The Raft leader election algorithm to determine which agent triggers [global state change scripts](xref:NodeRecovery_Triggers#global-state-change).
For more information, refer to [In Search of an Understandable Consensus Algorithm](https://classpages.cselabs.umn.edu/Spring-2018/csci8980/Papers/Consensus/Raft.pdf)

## What if I install NodeRecovery on a DataMiner agent that does not have Swarming enabled?

The NodeRecovery service will start up but will not send out heartbeats or perform outage detection. It will also not trigger any scripts. Once swarming is enabled, NodeRecovery will automatically start functioning without requiring a restart of the service.

## What actions are required after adding a new node to the cluster?

After adding a new node to the cluster, no actions are required. NodeRecovery will automatically discover the new node through SLNet and start monitoring it.

## What actions are required after removing a node from the cluster?

After removing a node from the cluster, no actions are required. NodeRecovery will automatically detect that the node is no longer present through SLNet and will stop monitoring it.

## Where can I find the NodeRecovery log files?

See [NodeRecovery Troubleshooting](xref:NodeRecovery_Troubleshooting).

## How many DataMiner agents are required to use NodeRecovery?

NodeRecovery requires a cluster of at least 2 DataMiner Agents to monitor each other for outages and launch local state change scripts. However, global state change detection requires at least 3 DataMiner Agents.

## Is there a change log available for NodeRecovery?

See [NodeRecovery change log](xref:NodeRecovery_change_log) for a detailed list of changes per version.
