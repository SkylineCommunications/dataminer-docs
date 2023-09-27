---
uid: SLNetClientTest_active_merge_actions_protocols
---

# Requesting a list of active merge actions for a protocol

From DataMiner 9.5.14 onwards, it is possible to request a list of currently active merge actions for protocols doing aggregation actions. This can be useful as debug information in case aggregated values do not update as intended.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Diagnostics* > *DMA* > *Protocol Active Merge Actions*.

1. Enter either the DMA ID and element ID or the element name, and click *OK*.

   The result will be displayed in the *Output* tab of the tool.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
