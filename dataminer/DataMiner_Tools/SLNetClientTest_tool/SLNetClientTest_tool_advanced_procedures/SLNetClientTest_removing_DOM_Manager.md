---
uid: SLNetClientTest_removing_DOM_Manager
---

# Removing a DOM manager

From DataMiner 10.3.5/10.4.0 onwards, you can remove a DOM manager from your system using the SLNetClientTest tool.<!-- RN 35550 -->

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *DataMiner Object Model*.

   This will open the *ModuleSettings* window, which lists the different DOM managers.

   > [!NOTE]
   > To view a JSON representation of the module settings of a specific DOM manager, select it in the list and click *View*.

1. Select the DOM manager you want to remove and click *Delete*.

1. Click *Yes* in the confirmation window.

   This will open another confirmation window, listing the data that will be deleted if you continue with the action.

   > [!NOTE]
   > To prevent issues, if there are more than 100&thinsp;000 DOM instances, you will not be able to continue with the deletion. Prior to DataMiner 10.5.6/10.6.0<!-- RN 42788 -->, this already applies when there are more than 10&thinsp;000 instances.

1. Click *OK*.

   The deletion progress will be shown. With the *Abort* button at the bottom of the progress window, you can stop the deletion process if needed. When the deletion is progress is complete, another confirmation box will be shown.

1. Click *OK*.

> [!IMPORTANT]
> Removing the DOM manager will not remove the corresponding indices from the Elasticsearch database. These indices have to be deleted manually. If you do not delete them manually, make sure you do not reuse the module ID, as this could cause configuration conflicts. For more information, see [Removing DOM indices in Elasticsearch or OpenSearch](xref:DOM_data_storage#removing-dom-indices-in-elasticsearch-or-opensearch).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
