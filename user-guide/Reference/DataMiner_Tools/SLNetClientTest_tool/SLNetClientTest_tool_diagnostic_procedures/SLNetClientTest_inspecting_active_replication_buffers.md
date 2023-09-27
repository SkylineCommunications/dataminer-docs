---
uid: SLNetClientTest_inspecting_active_replication_buffers
---

# Inspecting the active replication buffers

To solve issues with replication buffering, it is possible to inspect the active replication buffers with the SLNetClientTest tool, and also to drop a specific buffer.

To view a list of all active replication buffers:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Caches & Subscriptions* > *ReplicationBufferStats*.

   In the *Properties* tab of the main window, a new message will appear that lists the number of active buffers. For detailed information, double-click the message, or select the message and check the *Text* pane on the right.

To drop one specific replication buffer:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window.

1. In the *Message Type* drop-down list, select *DiagnoseMessage*.

1. In the *ExtraInfo* field, specify "drop:\[bufferkey\]", where \[bufferkey\] is the key of the replication buffer you want to drop. Replication buffer keys are listed in the replication buffer stats (e.g. "hostname/ipaddress/dmaid/eid")

1. In the *Type* field at the bottom, select *ReplicationBufferStats*.

> [!NOTE]
> When a replication buffer saves files to disk, those files are located in C:\\Skyline DataMiner\\ System Cache\\SLNet and are named "ReplicationBuffer_clienthostname_ip_dmaid_eid_objectid.bin".

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
