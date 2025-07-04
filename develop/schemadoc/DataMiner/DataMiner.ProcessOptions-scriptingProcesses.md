---
uid: DataMiner.ProcessOptions-scriptingProcesses
---

# scriptingProcesses attribute

Configures the number of SLScripting processes.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***Union*** |  |  |
| &#160;&#160;***string restriction*** |  |  |
| &#160;&#160;&#160;&#160;Enumeration | protocol | Specifies that a separate SLScripting process should be used for every protocol. |
| &#160;&#160;&#160;&#160;Enumeration | [Service] | Specifies that the SLScripting process should be registered as a service. |
| &#160;&#160;***int restriction*** |  |  |

## Parents

[ProcessOptions](xref:DataMiner.ProcessOptions)
