---
uid: KI_Contents_Elements_folder_deleted_from_offline_Agents_in_Failover_cluster
---

# Contents of Elements folder deleted from offline Agents in Failover cluster

## Affected versions

All Failover systems.

## Cause

This issue is triggered by a specific sequence of events:

1. A DVE parent element is removed or migrated.

   > [!NOTE]
   > The issue may also occur if the DVE parent element no longer generates DVEs, but has generated DVEs in the past.

1. Because of a naming conflict in the cluster, an entry containing only `<INVALID NAME>` is created in the DVE element info in the database.

1. As a result, DataMiner attempts to delete the DVE child elements from the cluster.

1. On offline Agents, this causes the entire `C:\Skyline DataMiner\Elements` folder to be deleted instead of only the specific DVEs.

> [!NOTE]
>
> - This issue is more likely to occur if the `noElementPrefix` option is used, as this removes the parent element name from DVE names and increases the chance of name conflicts.
> - Entries in the database like `<INVALID NAME> element name` (i.e. also containing the element name in addition to `<INVALID NAME>`) do not trigger this issue.

## Fix

No fix is available yet.

## Workaround

1. Locate the element info:

   - Look for a zipped folder named `Element   deleted` in the `C:\Skyline DataMiner\Recycle Bin` folder, or

   - Copy the element files from the online DMA.

1. Copy the elements to the `C:\Skyline DataMiner\Elements` folder of the offline DMA.

1. Restart the DMA.

## Description

On offline Agents in a Failover cluster, the `C:\Skyline DataMiner\Elements` folder may be partially or fully emptied. In some cases, no elements remain.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.

- Check the offline Agent’s Recycle Bin for entries named `Element   deleted`, indicating a deletion occurred without a known element name.
