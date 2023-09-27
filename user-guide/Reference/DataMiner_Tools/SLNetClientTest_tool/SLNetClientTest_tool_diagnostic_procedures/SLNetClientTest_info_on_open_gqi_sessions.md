---
uid: SLNetClientTest_info_on_open_gqi_sessions
---

# Retrieving information on open GQI sessions

From DataMiner 10.2.0/10.1.7 onwards, you can retrieve information on how many GQI (i.e. generic queries interface, the interface used for queries in the Dashboards app) sessions are currently open.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *GQI* > *Sessions*.

   This will open a window with the session ID, creation time and last update time of each of the current sessions.

   You can refresh the displayed information with the *Refresh* button at the top of the window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
