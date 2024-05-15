---
uid: Migrating_elements_in_a_DataMiner_System
---

# Migrating elements in a DataMiner System

In DataMiner Cube, it is possible to migrate elements from one DMA to another within a DMS.

To do so:

1. In Cube, go to *Apps* > *System Center \> Agents*.

1. Go to the *Status* tab.

   In the *Status* tab, you can see an overview of the DMAs in the DMS, with the number of elements per DMA and several other parameters such as the processor load and the free disk space of each DMA.

1. In the lower right corner of the *Status* tab, click the *Migrate* button.

   This will open the *Element migration* window, which lists the available elements in a table on the left and the possible destination DMAs on the right.

   > [!NOTE]
   >
   > - If you want to estimate the impact of an element on a DMA in order to decided whether it should be migrated or not, you can use the [DataMiner Size tool](xref:DataMinerSizeTool).
   > - Not all elements are included in the migration window:
   >   - If you do not have permission to access and edit certain elements, these elements will not be included.
   >   - Spectrum elements, SLAs, DVE elements, and virtual elements in redundancy groups are never included.

1. In the *Element migration* window, in the list on the left, select the elements you want to migrate from one DMA to another.

1. In the pane on the right, select the DMA to which you want to migrate these elements.

1. Click the *Migrate* button at the bottom of the window.

   After you confirm the migration in a confirmation box, the progress of the migration process will be indicated. When the migration is complete, a pop-up message will indicate if it was successful.

> [!NOTE]
>
> - You need to have the permissions *Elements* > *Access*, *Elements* > *Edit*, *Elements* > *Export DELT* and *Elements* > *Import DELT*. In addition, only elements that you have the right to access will be displayed in the *Element migration* window.
> - It is not possible to migrate spectrum analyzer elements, SLA elements or separate DVE child elements.

> [!TIP]
> See also:
>
> - [Rui's Rapid Recap - DELT](https://community.dataminer.services/video/ruis-rapid-recap-delt/) ![Video](~/user-guide/images/video_Duo.png)
> - [Agents – Migrating elements from one DMA to another](https://community.dataminer.services/video/agents-migrating-elements-from-one-dma-to-another/) ![Video](~/user-guide/images/video_Duo.png)
