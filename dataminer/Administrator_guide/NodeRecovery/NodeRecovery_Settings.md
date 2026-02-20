---
uid: NodeRecovery_Settings
---

# DataMiner NodeRecovery settings

Below you can find an overview of the different settings you can configure in the file *appsettings.custom.json*:

The default configuration should suffice for most scenarios. Should you need to change configuration values anyway, you can do so as follows:

1. Open the folder `C:\Program Files\Skyline Communications\DataMiner NodeRecovery`.
1. Create a new file named *appsettings.custom.json* in this folder.

   This is the file in which you will be able to customize the default configuration from *appsettings.json*. The settings configured in *appsettings.json* will be merged together with the settings configured in *appsettings.custom.json* and these merged settings will be applied by DataMiner NodeRecovery.

   > [!NOTE]
   > Do not make persistent changes to the existing *appsettings.json* file, as this file gets overwritten during updates.

1. Configure the settings you want to override. See further down for a list of available settings.

   > [!NOTE]
   > For correct and predictable cluster behavior, it is strongly recommended to keep these settings identical on all nodes. If settings differ between nodes, this may lead to inconsistent or unexpected behavior, as each node will operate according to its own configuration.

1. Restart the *DataMiner NodeRecovery* service on each of the cluster nodes (e.g., using Windows Task Manager).

> [!NOTE]
> By default, a log file for DataMiner NodeRecovery is stored in `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs`. In case the *DataMiner NodeRecovery* service does not start up after a configuration change, the log file will contain more information.

## Logging Settings

Example:

```json
{
  "logging": {
    "MinimumLevel": "Information",
    "RaftMinimumLevel": "Error"
  }
}
```

The `MinimumLevel` configuration object provides for one of the log event levels to be specified as the minimum. In the example above, log events with level `Information` and higher will be processed and ultimately written to the log file.

The `RaftMinimumLevel` configuration object provides for one of the log event levels to be specified as the minimum for the Raft leader election. In the example above, log events for the Raft leader election with level `Error` and higher will be processed and ultimately written to the log file.

Available levels are `Verbose`, `Debug`, `Information`, `Warning`, `Error`, `Fatal`.

An update of this setting does not require the NodeRecovery process to be restarted. The new level will be applied automatically.

> [!NOTE]
> The NodeRecovery log file can be found at `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\DataMiner NodeRecovery.txt`

## Outage Settings

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

| Setting | Minimal Value | Maximal Value | Comments |
| ------- | ------------- | ------------- | -------- |
| `HeartbeatIntervalMilliseconds` | 20 | 900000 (15 minutes) | |
| `OutageThresholdMilliseconds` | 520 | 900000 (15 minutes) | Must be greater or equal to `HeartbeatIntervalMilliseconds` + 500ms |
| `FirstHeartbeatThresholdMilliseconds` | 520 | 86400000 (24h) | Must be greater or equal to `OutageThresholdMilliseconds`. |

### HeartbeatIntervalMilliseconds

Interval at which heartbeats are sent out, in milliseconds.

> [!NOTE]
> By default this value is set to 250ms. Consider increasing this value if the log files indicate that timer callbacks are taking too long.

### FirstHeartbeatThresholdMilliseconds

Maximum time to wait for the first heartbeat before a node is considered in outage. This is the time allowed for a node (DxM or Windows) to start up (or restart) and send out its first heartbeat.

If this time is exceeded, a node can move from the `Unknown` to the `Outage` state.

### OutageThresholdMilliseconds

Maximum time between heartbeats before a node is considered in outage.

If this time is exceeded, an observing node can move the node from the `Healthy` to the `Outage` state within its local view.

Must be greater than [HeartbeatIntervalMilliseconds](#heartbeatintervalmilliseconds).

The theoretical maximum time it takes for a node to go in outage is 250ms (fixed outage check interval) + [OutageThresholdMilliseconds](#outagethresholdmilliseconds).

### LocalClusterStateChangeScriptName

Name of the automation script that is executed on the local node when one or more nodes in the entire cluster change state (from the viewpoint of this node).

See [Triggering on state changes](xref:NodeRecovery_Triggers)

### GlobalClusterStateChangeScriptName

Name of the automation script that is executed on the leader node when the global cluster state changes. The global state represents the cluster-wide consensus on node states.

See [Triggering on state changes](xref:NodeRecovery_Triggers#global-state-change)
