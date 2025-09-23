---
uid: KI_Contents_Elements_folder_deleted_from_offline_Agents_in_Failover_cluster
---

# Contents of Elements folder deleted from offline Agents in Failover cluster

## Affected versions

All Failover systems.

## Cause

On offline Agents in a Failover cluster, an unexpected deletion of element content can occur. This issue is only triggered under a specific set of conditions:

1. A naming conflict in the cluster leads to the creation of an entry containing only `<INVALID NAME>` in the DVE element info in the database.

1. The DVE parent element associated with that `<INVALID NAME>` entry is removed or migrated.

   > [!NOTE]
   > The issue may also occur if the DVE parent element no longer generates DVEs, but has generated DVEs in the past.

1. On offline Agents, this may result in all contents of the `C:\Skyline DataMiner\Elements` folder being deleted, instead of only the intended DVEs.

> [!NOTE]
>
> - This issue is more likely to occur if the `noElementPrefix` option is used, as this removes the parent element name from DVE names and increases the chance of name conflicts.
> - Entries in the database like `<INVALID NAME> element name` (i.e. also containing the element name in addition to `<INVALID NAME>`) do not trigger this issue.

## Fix

No fix is available yet. <!--Task ID: 275052-->

## Workaround

1. Locate the element info:

   - Look for a zipped folder named "Element&nbsp;&nbsp;&nbsp;deleted" in the `C:\Skyline DataMiner\Recycle Bin` folder, or

   - Copy the element files from the online DMA.

1. Copy the elements to the `C:\Skyline DataMiner\Elements` folder of the offline DMA.

1. Restart the DMA.

## Description

In Failover clusters, the `C:\Skyline DataMiner\Elements` folder on offline Agents may be unexpectedly cleared, sometimes leaving no elements behind. This can happen in rare cases where specific conditions related to DVE element handling and naming conflicts are met.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.

- Check the offline Agent’s Recycle Bin for entries named "Element&nbsp;&nbsp;&nbsp;deleted", indicating a deletion occurred without a known element name.
