---
uid: Scripted_Connectors
---

# Scripted Connectors

Scripted Connectors are executed by the Data Aggregator DxM and operate independently from DataMiner. To use Scripted Connectors, Data Aggregator must be installed on the same server as DataMiner. Consequently, the scripts are stored on the same machine as DataMiner. It's worth mentioning that the execution of Scripted Connectors is carried out separately from any other DataMiner processes.

Once added, Scripted Connectors run every minute.

These connectors can be written in PowerShell and Python. Data Aggregator comes with Python 3.12.0. If a Scripted Connector requires additional Python packages, you can [install extra Python packages](xref:Data_Sources_Setup).

The scripts then send JSON data through a local HTTP call to the Data API.
