---
uid: SLNetClientTest_comparing_views_on_two_dmas
---

# Comparing the views on two Agents in a DMS

In case there are suspected synchronization issues within a DataMiner System, the SLNetClientTest tool makes it possible to compare the in-memory views loaded by two different DataMiner Agents. This is also possible with a backup Agent in a Failover setup.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Clear From* > *Views.xml.*

1. In the *Clear From Views.xml* window, go to the *Compare Agents* tab.

1. Next to *Agent A* and *Agent B*, select the two Agents.

1. Click *Compare.*

   If differences are detected between the Agents, these will be shown in the list at the bottom of the window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
