---
uid: SLNetClientTest_info_on_open_gqi_sessions
---

# Retrieving information on open GQI sessions

> [!NOTE]
> The SLNetClientTest tool can only retrieve GQI sessions that are running in SLHelper. To retrieve information for active GQI sessions running in the [GQI DxM](xref:GQI_DxM), from DataMiner 10.5.0 [CU12]/10.6.3 onwards, you can use the [GQI Monitor](https://catalog.dataminer.services/details/faded63d-795f-422b-968a-89ae98ce0a2d) app.

From DataMiner 10.2.0/10.1.7 onwards, you can retrieve information on how many GQI (i.e., generic queries interface, the interface used for queries in the Dashboards app) sessions are currently open.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *GQI* > *Sessions*.

   This will open a window with the session ID, creation time and last update time of each of the current sessions.

   You can refresh the displayed information with the *Refresh* button at the top of the window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
