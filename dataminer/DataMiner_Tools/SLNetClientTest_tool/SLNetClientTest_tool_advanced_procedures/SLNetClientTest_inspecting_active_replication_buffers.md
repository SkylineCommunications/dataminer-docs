---
uid: SLNetClientTest_inspecting_active_replication_buffers
---

# Inspecting the active replication buffers

To solve issues with replication buffering, it is possible to [inspect the active replication buffers](#inspecting-the-active-replication-buffers) with the SLNetClientTest tool, and also to [drop a specific buffer](#dropping-a-replication-buffer). After an upgrade to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7, it may also be necessary to [flush the replication buffer](#managing-replication-buffer-files) to the DMA.

## Viewing all active replication buffers

To view a list of all active replication buffers:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Caches & Subscriptions* > *ReplicationBufferStats*.

   In the *Properties* tab of the main window, a new message will appear that lists the number of active buffers. For detailed information, double-click the message, or select the message and check the *Text* pane on the right.

## Dropping a replication buffer

To drop one specific replication buffer:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window.

1. In the *Message Type* drop-down list, select *DiagnoseMessage*.

1. In the *ExtraInfo* field, specify "drop:\[bufferkey\]", where \[bufferkey\] is the key of the replication buffer you want to drop. Replication buffer keys are listed in the replication buffer stats (e.g. "hostname/ipaddress/dmaid/eid")

1. In the *Type* field at the bottom, select *ReplicationBufferStats*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Managing replication buffer files

When a replication buffer saves files to disk, those files are located in `C:\Skyline DataMiner\System Cache\SLNet` and are named as follows:

- From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39428-->: `ReplicationBuffer_clienthostname_ip_dmaid_eid.bin`

  These files do not include a unique hash in their filenames. As a result there is only one file per replicated element.

- Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7: `ReplicationBuffer_clienthostname_ip_dmaid_eid_objectid.bin`

  These files include a unique hash in their filenames.

  From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39428-->, these older files will remain in the SLNet folder, but the new changes prevent further growth.

  - If older data is no longer needed, you can manually delete the files.

  - To keep the data, you can flush it to the Agent using the SLNetClientTest tool:

    1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

    1. Go to the *Build Message* tab of the main window.

    1. In the *Message Type* drop-down list, select *DiagnoseMessage*.

    1. In the *ExtraInfo* field, specify "flush:\[fileNamePattern]".

       Examples:

       | Command | Action |
       |--|--|
       | `flush:*` | Flushes all files |
       | `flush:slc-h32-g06_*` | Flushes all files for Agent slc-h32-g06 |
       | `flush:slc-h32-g06_10.11.6.32_223_4` | Flushes files for a specific element on the Agent |

    1. In the *Type* field at the bottom, select *ReplicationBufferStats*.

    > [!IMPORTANT]
    >
    > - DataMiner can only flush the replication buffer if the replication connection for that specific subscription is active. If not, the flush will fail and the file will remain.
    > - Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
