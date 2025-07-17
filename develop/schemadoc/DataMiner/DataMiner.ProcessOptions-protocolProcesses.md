---
uid: DataMiner.ProcessOptions-protocolProcesses
---

# protocolProcesses attribute

Configures the number of SLProtocol processes.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***Union*** |  |  |
| &#160;&#160;***string restriction*** |  |  |
| &#160;&#160;&#160;&#160;Enumeration | protocol | Specifies that a separate SLProtocol process should be used for every protocol. |
| &#160;&#160;&#160;&#160;Enumeration | replicationIP | Specifies that all replicated elements from the same remote DataMiner Agent have to be handled by the same SLProtocol process. |
| &#160;&#160;***int restriction*** |  |  |

## Parents

[ProcessOptions](xref:DataMiner.ProcessOptions)
