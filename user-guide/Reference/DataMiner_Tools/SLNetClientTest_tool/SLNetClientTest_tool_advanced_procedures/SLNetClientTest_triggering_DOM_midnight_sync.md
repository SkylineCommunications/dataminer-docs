---
uid: SLNetClientTest_triggering_DOM_midnight_sync
---

# Triggering a midnight sync for a DOM manager

From DataMiner 10.3.9/10.4.0 onwards<!-- RN 36412 -->, you can manually trigger a midnight sync for a specific DOM manager. That way, you can force any enabled [DOM cache](xref:DOM_data_storage#caching) to reload its data from the database. This can be useful in case connection issues between Agents caused the DOM caches to be out of sync.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *DataMiner Object Model*.

   This will open the *ModuleSettings* window, which lists the different DOM managers.

1. Select the DOM manager you want to open and click *Open*.

1. Open the *Maintenance* tab.

1. In the *Midnight Sync* section, click *Trigger*.

> [!NOTE]
>
> - When the sync is complete, a dialog will show the Agents for which the midnight sync has been executed. This list should contain all the DMA IDs of the Agents where the DOM manager was initialized.
> - The midnight sync can take a while, depending on the configuration of the DOM manager and the server performance. You may have to wait up to a minute until the window will be responsive again.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
