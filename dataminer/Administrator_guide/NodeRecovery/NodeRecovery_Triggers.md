---
uid: NodeRecovery_Triggers
---

# Triggering a script

When the [state of a node](xref:NodeRecovery_States) changes, DataMiner NodeRecovery can trigger the launch of an automation script to deal with the state change as you see fit. A script can be triggered based on a [local state change](#local-state-change) or based on a [global state change](#global-state-change).

## Local state change

The local state change script is triggered whenever the local node detects one or more state changes for nodes in the cluster.

It will be triggered **on any of the nodes that have an updated state view** of the cluster or when any of the nodes enter [maintenance mode](xref:NodeRecovery_States#maintenance-mode). If one node goes down, each other Agent in the cluster will have the script executed. If you configure a *Local State Change* script, make sure it is able to deal with this. See [pitfalls](#pitfalls-for-local-state-changes) for details.

By default, if there is a script called `NodeRecovery - Local State Change` in the Automation module, this will be used as the local state change script. You can customize this script name in the [Node Recovery settings](xref:NodeRecovery_Settings#outage-settings).

The script requires a custom entry point of type [OnNodeRecoveryLocalStateChange](xref:Skyline.DataMiner.Net.Automation.AutomationEntryPoint.Types.OnNodeRecoveryLocalStateChange). This entry point method should have the [IEngine](xref:Skyline.DataMiner.Automation.IEngine) object as its first argument, a [LocalStateChangeInput](xref:Skyline.DataMiner.Net.NodeRecovery.LocalStateChangeInput) object as its second argument, and an instance of [LocalStateChangeOutput](xref:Skyline.DataMiner.Net.NodeRecovery.LocalStateChangeOutput) as output.

The input provided to the script contains information on the current node as well as the observed states for all nodes in the cluster. It also contains details on what has actually changed.

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

Make sure your script logic is aware of the following:

- The script will be executed on each of the nodes that detects a state change for a node.
- The script will be executed on every state change. This includes going from *Unknown* to *Healthy* on node startup.
- The script will be executed when nodes enter or leave maintenance mode, even if no other state changes occur.
- One script execution can correspond with multiple node state changes at once.
- Even if a node is marked as being in maintenance mode, the state for this node will still be reported as *Healthy*, *Outage*, or *Unknown*. It is up to the script to check the maintenance state if needed and to decide how to handle it.
- If your script requires information about elements hosted on an Agent that is unreachable, it needs to request this info from SLNet via SLNet messages (`engine.GetUserConnection().HandleMessage()`) and not via SLAutomation (~~`engine.FindElement()`~~) as the latter only has access to elements that are currently running and reachable.

We also highly recommend that you have your script check the incoming node IDs, states, and maintenance states before starting any actions.

## Global state change

The global state change script is triggered whenever the global cluster state changes. Unlike local state changes where each node independently detects changes from its own perspective, global state changes represent a cluster-wide consensus.

The script will only be executed **on the leader node** when the global cluster state changes. The leader node gets elected within the cluster and updates if the leader no longer has a view on the majority of the cluster. This ensures that actions based on global state changes are executed only once across the cluster, avoiding duplicate actions that would occur with local state changes. If a cluster has less than three nodes, there cannot be a leader and thus no global state changes will be detected.

By default, if there is a script called `NodeRecovery - Global State Change` in the Automation module, this will be used as the global state change script. You can customize this script name in the [Node Recovery settings](xref:NodeRecovery_Settings#outage-settings).

The script requires a custom entry point of type [OnNodeRecoveryGlobalStateChange](xref:Skyline.DataMiner.Net.Automation.AutomationEntryPoint.Types.OnNodeRecoveryGlobalStateChange). This entry point method should have the [IEngine](xref:Skyline.DataMiner.Automation.IEngine) object as its first argument, a [GlobalStateChangeInput](xref:Skyline.DataMiner.Net.NodeRecovery.GlobalStateChangeInput) object as its second argument, and an instance of [GlobalStateChangeOutput](xref:Skyline.DataMiner.Net.NodeRecovery.GlobalStateChangeOutput) as output.

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

> [!TIP]
> The following trigger script is available in the Catalog by way of example: [Node Recovery - Rebalance across healthy Agents](https://catalog.dataminer.services/details/3de8405e-7156-4a0a-b8c5-80937de0f4ed). Whenever the global cluster state changes, this example script will move elements hosted on nodes that are in outage to healthy nodes, while trying to keep the load balanced across the cluster as much as possible. You can use this script as is or use it as a starting point for your own scripts.

### Pitfalls for global state changes

Make sure your script logic is aware of the following:

- Global outage detection will only be executed on the leader node. This is the only Agent that will have this script executed.
- When a leader node goes down or loses its leader status, a new leader is elected automatically. After a new leader has been elected, an initial global state calculation on the new node will trigger a script execution with the current state, mentioning *Unknown* as the previous state.
- Nodes start out in the *Unknown* state when added to the cluster. They will switch to *Healthy* as soon as nodes start seeing them as such.
- In network split scenarios, only the partition that contains a strict majority of the nodes (i.e., more than half of all nodes in the cluster) will have a leader that can execute this script.
- One script execution can correspond with multiple node state changes at once in the global view.
- If your script requires information about elements hosted on an Agent that is unreachable, it needs to request this info from SLNet via SLNet messages (`engine.GetUserConnection().HandleMessage()`) and not via SLAutomation (~~`engine.FindElement()`~~) as the latter only has access to elements that are currently running and reachable.

## Differences between local and global state changes

| Aspect | Local State Change | Global State Change |
| ------ | ------------------ | ------------------- |
| Script execution location | On every node that detects a change. | Only on the leader node. |
| Perspective | Individual node's view of the cluster. | Cluster-wide consensus. |
| Trigger frequency | Multiple times (once per observing node). | Once per global state change. |
| Use case | Node-specific actions. | Centralized cluster management, rebalancing. |
| Network splits | Can detect partial failures. | Only works within the partition having cluster majority (see [Network splits](xref:NodeRecovery_Detection#network-splits)). |
| Broken links between nodes | Each node may have a different view. | The leader aggregates views to determine consensus. |
