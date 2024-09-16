---
uid: EPM_DataMiner_processes_config
---

# DataMiner processes configuration

The collectors in an EPM environment are the powerhouses in the solution. Because of this, you typically want to ensure that they are given all the resources they can.

To do so, you can:

- [set the number of simultaneously running SLProtocol processes](xref:Configuration_of_DataMiner_processes.html#setting-the-number-of-simultaneously-running-slprotocol-processes) and [Configuring a separate SLScripting process for each SLProtocol process](xref:Configuration_of_DataMiner_processes.html#configuring-a-separate-slscripting-process-for-each-slprotocol-process).
- [configure separate SLProtocol and SLScripting instances for specific protocols](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol).

> [!WARNING]
> Above mentioned features are not to be mistaken with following features which should never be used on production as they are only meant to be used for debugging purposes:
> - [Configuring a separate SLProtocol process for every protocol used](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slprotocol-process-for-every-protocol-used)
> - [Configuring a separate SLScripting process for every protocol used](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slscripting-process-for-every-protocol-used)
