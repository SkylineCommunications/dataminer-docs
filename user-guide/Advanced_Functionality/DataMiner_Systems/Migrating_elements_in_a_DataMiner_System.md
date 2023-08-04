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

    This will open the *Element migration* window, which lists the available elements in a table on the left and the possible destination DMAs on the right.     The following information in the table may be useful to help you decide which elements should be migrated:

    | Column | Description |
    |--------|-------------|
    | Weight | Number from 1 to 10, indicating the impact of the element on the DMA hosting it. This is a relative weight for each DMA, so comparing the weight only makes sense between elements hosted on the same DMA.<br>The weight can be interpreted as the percentage of parameter sets originating from this element. Less than 10 percent will result in a weight of 1, between 10 and 20 percent will result in weight 2, etc. |
    | Change | The number of parameter changes that enter in SLElement.exe. For a single parameter, this is every change; for a table, this reflects the way it is updated by the protocol. If the table is updated in bulk, this will be counted as one change, if it is updated cell by cell, the counter will be much higher. |
    | Polling | Represents the "change" value multiplied by 2. |
    | Agent | The DMA currently hosting the element. |

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
