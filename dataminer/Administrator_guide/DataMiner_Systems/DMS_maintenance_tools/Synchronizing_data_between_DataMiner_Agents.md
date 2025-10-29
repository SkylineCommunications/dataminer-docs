---
uid: Synchronizing_data_between_DataMiner_Agents
---

# Synchronizing data between DataMiner Agents

In normal circumstances, the information on all DMAs in a cluster is synchronized at midnight. However, it may be necessary to force a synchronization earlier, either partially or completely.

> [!NOTE]
>
> - In case of conflicting changes during a synchronization, the most recent change gets precedence.
> - For more information on which files and folders are synchronized during this process, refer to [Overview of the files found in the root folder](xref:Overview_of_the_files_found_in_the_root_folder) and [Overview of the different subfolders](xref:Overview_of_the_different_subfolders), respectively.

## Synchronizing your DMA with the DMS

To make a DMA synchronize its changes with other Agents in the cluster, you can manually execute the midnight synchronization code on this one DMA.

1. In Cube, go to *Apps* > *System Center.*

1. In the *System Center* module, select the *Tools* page.

1. In the second column, select *Synchronization*.

1. In the dropdown list next to *Type*, make sure *This DataMiner Agent* is selected.

1. Click the *Sync now* button at the bottom of the card.

1. In the confirmation window, click *Yes*.

> [!NOTE]
> In a DMS with several Agents, if a sync from one DMA is initiated, it is possible that some Agents in the DMS are not fully synchronized. For example, in a DMS with 3 DMAs, DMA A, B and C, If DMA A is synchronized with the DMS, first DMA A and DMA B will be synchronized, then DMA A and DMA C will be synchronized. However, this means that if DMA C had a more recent file than DMA B, only DMA A and C will have this newest file. As such, in most circumstances, a DMS sync is to be preferred over a DMA sync.

## Synchronizing all Agents in your DMS

To synchronize all Agents in the cluster, you can manually execute the complete midnight synchronization at any time.

1. In Cube, go to *Apps* > *System Center.*

1. In the *System Center* module, select the *Tools* page.

1. In the second column, select *Synchronization*.

1. In the dropdown list next to *Type*, select *This DMS*.

1. Click the *Sync now* button at the bottom of the card.

1. In the confirmation window, click *Yes*.

## Forcing synchronization of a file with the DMS

When a file has been changed on a particular DMA, you can force the synchronization of this file across the cluster.

1. In Cube, go to *Apps* > *System Center.*

1. In the *System Center* module, select the *Tools* page.

1. In the second column, select *Synchronization*.

1. In the dropdown list next to *Type*, select *File*.

1. In the *File* box enter the path of the file in question, e.g. `C:\Skyline DataMiner\Views.xml`.

1. Click the *Sync now* button at the bottom of the card.

1. In the confirmation window, click *Yes*.

## Synchronizing all Visio files within a DMS

To synchronize all Visio templates used in the cluster, you can execute a file synchronization for Visio files only.

1. In Cube, go to *Apps* > *System Center.*

1. In the *System Center* module, select the *Tools* page.

1. In the second column, select *Synchronization*.

1. In the dropdown list next to *Type*, select *Visio*.

1. Click the *Sync now* button at the bottom of the card.

1. In the confirmation window, click *Yes*.
