---
uid: EPM_DataMiner_processes_config
---

# DataMiner processes configuration

The collectors in an EPM environment are the powerhouses in the solution. Because of this, you typically want to ensure that they are given all the resources they can.

To do so, you can:

- [set the number of simultaneously running SLProtocol processes](xref:Configuration_of_DataMiner_processes#setting-the-number-of-simultaneously-running-slprotocol-processes) and [configure separate SLScripting process for each SLProtocol process](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slscripting-process-for-each-slprotocol-process).
- [configure separate SLProtocol and SLScripting instances for specific protocols](xref:Configuration_of_DataMiner_processes#configuring-separate-slprotocol-and-slscripting-instances-for-a-specific-protocol).

> [!WARNING]
> The above-mentioned features are not to be mistaken with the following features, which should never be used on a production system as they are only intended for debugging purposes:
>
> - [Configuring a separate SLProtocol process for every protocol used](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slprotocol-process-for-every-protocol-used)
> - [Configuring a separate SLScripting process for every protocol used](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slscripting-process-for-every-protocol-used)
