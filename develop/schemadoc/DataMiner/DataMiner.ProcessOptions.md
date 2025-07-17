---
uid: DataMiner.ProcessOptions
---

# ProcessOptions element

Configures the DataMiner processes.

See [Configuration of DataMiner processes](xref:Configuration_of_DataMiner_processes).

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [portProcesses](xref:DataMiner.ProcessOptions-portProcesses) | int |  | Configures the number of SLPort processes. |
| [protocolProcesses](xref:DataMiner.ProcessOptions-protocolProcesses) | Union |  | Configures the number of SLProtocol processes. |
| [scriptingProcesses](xref:DataMiner.ProcessOptions-scriptingProcesses) | Union |  | Configures the number of SLScripting processes. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [SeparateProcesses](xref:DataMiner.ProcessOptions.SeparateProcesses) | [0, 1] | Defines the protocols that should run in separate SLProtocol and SLScripting instances. |
