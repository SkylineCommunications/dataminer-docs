---
uid: Copilot_DxM
---

# Copilot DxM

The DataMiner Copilot module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)) and is responsible for bringing conversational AI into DataMiner.

The [natural language to GQI](xref:NL2GQI) feature is available from Copilot 1.0.0 onwards.

## Installation

Copilot is currently not included in DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

For Copilot to run correctly, the following **prerequisites** must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Copilot\Logs` folder. If this folder does not exist, it will be created automatically.
