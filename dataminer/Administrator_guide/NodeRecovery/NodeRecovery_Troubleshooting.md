---
uid: NodeRecovery_Troubleshooting
---

# Node Recovery troubleshooting

To troubleshoot Node Recovery issues, follow the instructions below.

## Log files

Consult the log files for Node Recovery in the following location on each DataMiner node:

- `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\DataMiner NodeRecovery.txt`
- `C:\ProgramData\Skyline Communications\DataMiner NodeRecovery\Logs\LastCrash.txt` (only present if the service ever crashed)

These files are also included in SLLogCollector packages (`DxM\DataMiner NodeRecovery\`).

> [!TIP]
> You can adjust the log level in the [Node Recovery settings](xref:NodeRecovery_Settings#logging-settings). This can be done at runtime without restarting the service.

## Configuration

Check the configuration of the [Node Recovery settings](xref:NodeRecovery_Settings) in the following location on each DataMiner node:

- `C:\Program Files\Skyline Communications\DataMiner NodeRecovery\appsettings.json`
- `C:\Program Files\Skyline Communications\DataMiner NodeRecovery\appsettings.custom.json` (only when overrides are present)

These files are also included in SLLogCollector packages (`DxM\DataMiner NodeRecovery\`).

## Services

Ensure that the *DataMiner NodeRecovery* service is running.

## Network connectivity

Node Recovery relies on NATS for communication between nodes. Ensure that the NATS cluster is up and running and that there are no network issues preventing nodes from communicating with each other.

For more information on how to troubleshoot NATS connectivity, see [Investigating NATS issues](xref:Investigating_NATS_Issues).

## SLNet connectivity

Node Recovery relies on SLNet to launch automation scripts as well as for discovering which nodes are available in the cluster. Ensure that SLNet is functioning correctly.

The NodeRecovery module has the following interactions with SLNet:

- It requests basic Agent info (version, name, supported requests and features, etc.).
- It subscribes on `DataMinerInfoEvent` to learn about existing, new, or removed nodes.
- It requests the list of Agents to learn about new or removed nodes during a DataMiner restart.
- It uses SLNet to launch automation scripts on state changes.
- It queries maintenance state flags through SLNet.

> [!NOTE]
> Even without SLNet connectivity, NodeRecovery will still send out heartbeats.
