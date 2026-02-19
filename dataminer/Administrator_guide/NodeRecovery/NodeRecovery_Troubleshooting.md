---
uid: NodeRecovery_Troubleshooting
---

# NodeRecovery Troubleshooting

> [!IMPORTANT]
> This is preliminary documentation. Eventually these docs will be moved to the official docs.

To troubleshoot NodeRecovery issues, consider the following steps:

## Log files

Log files for NodeRecovery can be found in the following location on each DataMiner node:

- `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\DataMiner NodeRecovery.txt`
- `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\LastCrash.txt` (only present if the service ever crashed)

These files are also included in LogCollector packages (`DxM\DataMiner NodeRecovery\`).

> [!TIP]
> The log level for NodeRecovery can be adjusted in the [NodeRecovery settings](xref:NodeRecovery_Settings#logging-settings). This can be done at runtime without restarting the service.

## Configuration

[Configuration for NodeRecovery](xref:NodeRecovery_Settings) can be found in the following location on each DataMiner node:

- `C:\Program Files\Skyline Communications\DataMiner NodeRecovery\appsettings.json`
- `C:\Program Files\Skyline Communications\DataMiner NodeRecovery\appsettings.custom.json` (only when overrides are present)

These files are also included in LogCollector packages (`DxM\DataMiner NodeRecovery\`).

## Services

Ensure that the `DataMiner NodeRecovery` service is running.

## Network connectivity

NodeRecovery relies on NATS for communication between nodes. Ensure that the NATS cluster is up and running and that there are no network issues preventing nodes from communicating with each other.

## SLNet connectivity

NodeRecovery relies on SLNet to launch automation scripts as well as for discovering which nodes are available in the cluster. Ensure that SLNet is functioning correctly.

SLNet interactions:

- NodeRecovery requests basic agent info (version, name, supported requests and features, ...)
- NodeRecovery subscribes on `DataMinerInfoEvent` to learn about existing, new or removed nodes
- NodeRecovery requests the list of agents to learn about new or removed nodes during DataMiner restart.
- NodeRecovery uses SLNet to launch automation scripts on state changes.
- NodeRecovery queries maintenance state flags through SLNet.

> [!NOTE]
> Even without SLNet connectivity, NodeRecovery will still send out heartbeats.
