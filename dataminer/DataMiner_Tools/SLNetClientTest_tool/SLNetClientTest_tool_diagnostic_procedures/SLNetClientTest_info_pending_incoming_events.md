---
uid: SLNetClientTest_info_pending_incoming_events
description: "Use SLNetClientTest to check the pending incoming event count between DMAs and view incoming packages waiting to be processed."
---

# Requesting information about pending incoming events

With the SLNetClientTest tool, there are two ways to request information on the number of events being passed from one DMA to another:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. To see a “Pending Incoming” count, go to *Diagnostics \> SLNet \> DataMinerConnections*.

1. To see the list of incoming event packages waiting to be processed, go to *Diagnostics* > *Connections* > *OpenClientConnections*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
