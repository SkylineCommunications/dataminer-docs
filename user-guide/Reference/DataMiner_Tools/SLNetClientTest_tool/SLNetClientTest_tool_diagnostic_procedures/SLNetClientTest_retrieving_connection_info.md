---
uid: SLNetClientTest_retrieving_connection_info
---

# Retrieving connection info for a particular element

From DataMiner 9.6.13 onwards, it is possible to retrieve connection information for a particular element. This can for instance be useful to detect the reason for timeouts.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Diagnostics* > DMA \> *Protocol Connection States*.

1. In the pop-up window, enter the name or the DMA ID/Element ID of the element and click *OK*.

   The connection information will be displayed in the *Output* tab of the tool.     If a timeout status is listed, this is the internal timeout status, without taking the configured element timeout time into account (which means that the element might not yet be considered to be in timeout in DataMiner).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
