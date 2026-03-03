---
uid: NodeRecovery_Settings
---

# Node Recovery settings

## Customizing the settings

The default configuration should suffice for most scenarios. If you do need to customize the settings, you can do so as follows:

1. Open the folder `C:\Program Files\Skyline Communications\DataMiner NodeRecovery`.

1. Create a new file named *appsettings.custom.json* in this folder.

   This is the file where you will be able to customize the default configuration from *appsettings.json*. The settings configured in *appsettings.json* will be merged together with the settings configured in *appsettings.custom.json* and these merged settings will be applied by the NodeRecovery DxM.

   Do not make persistent changes to the existing *appsettings.json* file, as this file gets overwritten during updates.

1. Configure the settings you want to override (see below).

   > [!IMPORTANT]
   > For correct and predictable cluster behavior, we strongly recommend keeping these settings identical on all nodes. If settings differ between nodes, this may lead to inconsistent or unexpected behavior, as each node will operate according to its own configuration.

1. Restart the *DataMiner NodeRecovery* service on each of the cluster nodes (e.g., using Windows Task Manager).

> [!NOTE]
> By default, a log file for DataMiner NodeRecovery is stored in `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs`. In case the *DataMiner NodeRecovery* service does not start up after a configuration change, the log file will contain more information.

## Logging settings

Example:

```json
{
  "logging": {
    "MinimumLevel": "Information",
    "RaftMinimumLevel": "Error"
  }
}
```

The following logging settings are available:

- `MinimumLevel`: Determines the minimum level for the log events. In the example above, only log events with level `Information` or higher will be processed and written to the log file.

- `RaftMinimumLevel`: Determines the minimum level for the log events for the Raft leader election. In the example above, log events for the Raft leader election with level `Error` and higher will be processed and written to the log file.

Available log levels are `Verbose`, `Debug`, `Information`, `Warning`, `Error`, and `Fatal`.

An update of these settings does not require the NodeRecovery process to be restarted. The new level will be applied automatically.

> [!NOTE]
> you can find the NodeRecovery log file at `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\DataMiner NodeRecovery.txt`.

## Outage settings

Example:

```json
{
  "outage": {
    "HeartbeatIntervalMilliseconds": 250,
    "FirstHeartbeatThresholdMilliseconds": 1800000,
    "OutageThresholdMilliseconds": 20000,
    "LocalClusterStateChangeScriptName": "NodeRecovery - Local State Change",
    "GlobalClusterStateChangeScriptName": "NodeRecovery - Global State Change"
  }
}
```

The following outage settings are available:

- `HeartbeatIntervalMilliseconds`: The interval at which heartbeats are sent out, in milliseconds.

  - Minimum value: 20.
  - Maximum value: 900000 (15 minutes).
  - Default value: 250. Consider increasing this value if the log files indicate that timer callbacks are taking too long.

- `FirstHeartbeatThresholdMilliseconds`: The maximum time to wait for the first heartbeat before a node is considered in outage. This is the time allowed for a node (DxM or Windows) to start up (or restart) and send out its first heartbeat. If this time is exceeded, a node can move from the *Unknown* to the *Outage* state.

  - Minimum value: 520.
  - Maximum value: 86400000 (24 hours).
  - Must be greater than or equal to `OutageThresholdMilliseconds`.

- `OutageThresholdMilliseconds`: The maximum time between heartbeats before a node is considered in outage. If this time is exceeded, an observing node can move the node from the *Healthy* to the *Outage* state within its local view.

  - Minimum value: 520.
  - Maximum value: 900000 (15 minutes).
  - Must be greater than or equal to `HeartbeatIntervalMilliseconds` + 500 ms. The theoretical maximum time it takes for a node to go in outage is 250 ms (fixed outage check interval) + `OutageThresholdMilliseconds`.

- `LocalClusterStateChangeScriptName`: The name of the automation script that is executed on the local node when one or more nodes in the cluster change state (from the viewpoint of this node). See [Local state change](xref:NodeRecovery_Triggers#local-state-change).

- `GlobalClusterStateChangeScriptName`: The name of the automation script that is executed on the leader node when the global cluster state changes. The global state represents the cluster-wide consensus on node states. See [Global state change](xref:NodeRecovery_Triggers#global-state-change).
