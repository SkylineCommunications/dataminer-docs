---
uid: SLNetClientTest_removing_references
---

# Removing references to items that no longer exist

With the SLNetClientTest tool, you can check if the *Views.xml* contains references to elements, services, or redundancy groups that no longer exist, and if so, remove them. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Clear From* > *Views.xml.*

1. In the *Clear From Views.xml* window, go to the *Clear by Removed Element* tab, and click *Find Removed Elements*.

   A dialog box will open with the IDs of all elements, services and redundancy groups that no longer exist but are still mentioned in *Views.xml*.

1. Click *Yes* to confirm the deletion.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
