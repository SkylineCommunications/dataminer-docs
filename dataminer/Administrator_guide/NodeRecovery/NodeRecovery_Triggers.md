---
uid: NodeRecovery_Triggers
---

# Triggering on state changes

On node changes, DataMiner NodeRecovery can launch an automation script. The script can then deal with the updated local or global view as it sees fit.

## Local state change

The local state change script executes whenever the local node detects one or more state changes for nodes in the cluster.

> [!NOTE]
> This *Local State Change* script will execute on any of the nodes that have an updated state view of the cluster or when any of the nodes change [maintenance state](xref:NodeRecovery_States#maintenance). If one node goes down, each other agent in the cluster will have the script executed. Your script should be able to deal with this. Also see [pitfalls](#pitfalls-for-local-state-changes).

To enable, create a script called "NodeRecovery - Local State Change" (name can be changed in [Settings](xref:NodeRecovery_Settings#localclusterstatechangescriptname)).

The scripts that will be executed require a custom entry point of type [OnNodeRecoveryLocalStateChange](xref:Skyline.DataMiner.Net.Automation.AutomationEntryPoint.Types.OnNodeRecoveryLocalStateChange). This entry point method should have the `IEngine` object as its first argument, a [LocalStateChangeInput](xref:Skyline.DataMiner.Net.NodeRecovery.LocalStateChangeInput) object as its second argument, and an instance of [LocalStateChangeOutput](xref:Skyline.DataMiner.Net.NodeRecovery.LocalStateChangeOutput) as output.

The input provided to the script contains information on the current node as well as the observed states for all nodes in the cluster. It also contains details on what actually changed compared to before.

A script with this entry point can look like this:

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.NodeRecovery;

namespace NodeRecovery_Local_Action_Example
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnNodeRecoveryLocalStateChange)]
        public LocalStateChangeOutput OnNodeRecoveryLocalStateChange(IEngine engine, LocalStateChangeInput input)
        {
          engine.GenerateInformation($"Hello From OnNodeRecoveryLocalStateChange, " 
                                    + $"executing dma: {input.LocalNodeId}, "
                                    + $"local state: {input.ClusterState[input.LocalNodeId]}");
        
          return new LocalStateChangeOutput();
        }
    }
}
```

### Pitfalls for local state changes

It is important to have your script logic aware of the following:

- The script will be executed on each of the nodes that detects a state change for a node.
- The script will be executed on every state change. This includes going from *Unknown* to *Healthy* on node startup.
- The script will be executed when nodes enter or leave maintenance mode, even if no other state changes occur.
- One script execution can contain multiple node state changes at once.
- Even if a node is marked as being in maintenance mode, the state for these nodes will still be reported as *Healthy*, *Outage* or *Unknown*. It is up to the script to check the maintenance state if needed and decide how to handle it.

It is highly advised to have your script check the incoming node ids, states and maintenance states before starting any actions.

## Global state change

The global state change script executes whenever the global cluster state changes. Unlike local state changes where each node independently detects changes from its own perspective, global state changes represent a cluster-wide consensus.

> [!NOTE]
> The *Global State Change* script will only execute on the leader node when the global cluster state changes. The leader node gets elected within the cluster and updates if the leader no longer has a view on the majority of the cluster. This ensures that actions based on global state changes are executed only once across the cluster, avoiding duplicate actions that would occur with local state changes. If a cluster has less than 3 nodes, there cannot be a leader and thus no global state changes will be detected.

To enable, create a script called "NodeRecovery - Global State Change" (name can be changed in [Settings](xref:NodeRecovery_Settings#globalclusterstatechangescriptname)).

The scripts that will be executed require a custom entry point of type [OnNodeRecoveryGlobalStateChange](xref:Skyline.DataMiner.Net.Automation.AutomationEntryPoint.Types.OnNodeRecoveryGlobalStateChange). This entry point method should have the `IEngine` object as its first argument, a [GlobalStateChangeInput](xref:Skyline.DataMiner.Net.NodeRecovery.GlobalStateChangeInput) object as its second argument, and an instance of [GlobalStateChangeOutput](xref:Skyline.DataMiner.Net.NodeRecovery.GlobalStateChangeOutput) as output.

The input provided to the script contains information about the global cluster state as calculated by the leader node. It includes the consensus view of all node states across the cluster.

A script with this entry point can look like this:

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.NodeRecovery;

namespace NodeRecovery_Global_Action_Example
{
    public class Script
    {
        [AutomationEntryPoint(AutomationEntryPointType.Types.OnNodeRecoveryGlobalStateChange)]
        public GlobalStateChangeOutput OnNodeRecoveryGlobalStateChange(IEngine engine, GlobalStateChangeInput input)
        {
          engine.GenerateInformation($"Hello From OnNodeRecoveryGlobalStateChange, " 
                                    + $"executing on leader node: {input.LeaderNodeId}, "
                                    + $"global cluster state has changed");
        
          return new GlobalStateChangeOutput();
        }
    }
}
```

### Pitfalls for global state changes

It is important to have your script logic aware of the following:

- Global outage detection will only be executed on the leader node. This is the only agent that will have this script executed.
- When a leader node goes down or loses its leader status, a new leader is elected automatically. After a new leader has been elected, an initial global state calculation on the new node will trigger a script execution with the current state, mentioning Unknown as the previous state.
- Nodes start out in the Unknown state when added to the cluster. They will switch to Healthy as soon as nodes start seeing them as Healthy.
- In network split scenarios, only the partition that contains a strict majority of the nodes (i.e. more than half of all nodes in the cluster) will have a leader that can execute this script.
- One script execution can contain multiple node state changes at once in the global view.

## Differences between local and global state changes

| Aspect | Local State Change | Global State Change |
| ------ | ------------------ | ------------------- |
| Script execution location | On every node that detects a change | Only on the leader node |
| Perspective | Individual node's view of the cluster | Cluster-wide consensus |
| Trigger frequency | Multiple times (once per observing node) | Once per global state change |
| Use case | Node-specific actions | Centralized cluster management, rebalancing |
| Network splits | Can detect partial failures | Only works within the partition having cluster majority. See [Network Splits](xref:NodeRecovery_Detection#network-splits) |
| Broken links between nodes | Each node may have a different view | Leader aggregates views to determine consensus |
