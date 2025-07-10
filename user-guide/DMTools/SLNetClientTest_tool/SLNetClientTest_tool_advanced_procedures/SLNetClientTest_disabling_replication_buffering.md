---
uid: SLNetClientTest_disabling_replication_buffering
---

# Disabling replication buffering

As a diagnostic option to verify if certain issues are caused by replication buffering, or in case replication buffering causes issues, it is possible to disable replication buffering using the SLNetClientTest tool.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *DisableReplicationBuffering*.

   A list of the Agents in the cluster will be displayed, indicating for each of them whether replication buffering is disabled.

1. In the *Value* column, right-click the "false" value for the Agent for which you wish to disable replication buffering, and select *Edit value*.

1. Enter "true" and click *OK*.

> [!NOTE]
> This option is saved into the file *MaintenanceSettings.xml* under the *\<SLNet>* tag. It is not synchronized across Agents in the DMS.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
