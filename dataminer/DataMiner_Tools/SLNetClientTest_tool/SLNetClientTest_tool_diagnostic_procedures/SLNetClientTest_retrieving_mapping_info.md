---
uid: SLNetClientTest_retrieving_mapping_info
---

# Retrieving live information about the mapping between elements and the processes they use

From DataMiner 10.5.4/10.6.0 onwards<!--RN 42013-->, it is possible to retrieve live information about the mapping between elements running on a DataMiner Agent and the processes they use, including SLProtocol and SLScripting. The information provided is similar to the information found in the *SLElementInProtocol.txt* log file. This can for instance be useful to monitor and troubleshoot process usage in real time.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Diagnostics* > *DMA* > *Element Process ID Info*.

1. Under the *Properties* tab, double-click the newly created *Message Info Table* entry.

   This will open a new window showing an overview of your elements.

   Row format: *Element/SLProtocol Pid/SLScripting Pid*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
