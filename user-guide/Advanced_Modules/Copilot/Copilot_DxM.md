---
uid: Copilot_DxM
---

# Copilot DxM

The DataMiner Copilot module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)) and is responsible for bringing conversational AI into DataMiner.

The [Natural language to GQI](xref:NL2GQI) feature is available from Copilot 1.0.0 onwards.

## Installation 

Copilot is currently not included in DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).
The following dependencies hold in order for Copilot to run correctly:

- **Cloud connection**: the DataMiner system [needs to be connected to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: The [GQI DxM](xref:GQI_DxM) needs to be installed in order for the Natural language to GQI feature to work.

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Copilot\Logs` folder.
If this folder does not exist, it will be created automatically.

