---
uid: Migrating_elements_in_a_DataMiner_System
description: If Swarming is not enabled in your DataMiner cluster, you can instead migrate elements from the System Center > Agents > Status page in DataMiner Cube.
---

# Migrating elements within a cluster

In DataMiner clusters where [Swarming](xref:Swarming) is not enabled, you can migrate elements from one node to another. When you do so, DELT (DataMiner Element Location Transparency) will be used to export the elements from the first node and then import them on the other node.

> [!NOTE]
> If Swarming is enabled, elements can be [swarmed](xref:SwarmingElements) instead. Swarming is a much more robust way of moving elements between DataMiner nodes, as the element configuration remains in the shared database and the element is simply unloaded from one node and loaded onto another. With element migration there is a greater risk of problems; for example, if the export works and the element is deleted in the original location, but the import fails for some reason, the element will end up missing.

To migrate elements:

1. In Cube, go to *Apps* > *System Center \> Agents*.

1. Go to the *Status* tab.

   ![Status tab](~/dataminer/images/Status_Tab.png)<br>*System Center > Agents > Status in DataMiner 10.6.5*

   In the *Status* tab, you can see an overview of the nodes in the cluster, with the number of elements per node and several other parameters such as the processor load and the free disk space of each node.

1. In the lower-right corner of the *Status* tab, click the *Migrate* button.

   This will open the *Element migration* window, which lists the available elements in a table on the left and the possible destination nodes on the right.

   ![Element migration](~/dataminer/images/Element_Migration.png)<br>*Element migration window in DataMiner 10.4.5*

   > [!NOTE]
   >
   > - If you want to estimate the impact of an element on a node in order to decided whether it should be migrated or not, you can use the [DataMiner Size tool](xref:DataMinerSizeTool).
   > - Not all elements are included in the migration window:
   >   - If you do not have permission to access and edit certain elements, these elements will not be included.
   >   - Spectrum elements, SLAs, DVE elements, and virtual elements in redundancy groups are never included.

1. In the *Element migration* window, in the list on the left, select the elements you want to migrate from one node to another.

1. In the pane on the right, select the node to which you want to migrate these elements.

1. Click the *Migrate* button at the bottom of the window.

   After you confirm the migration in a confirmation box, the progress of the migration process will be indicated. When the migration is complete, a pop-up message will indicate if it was successful.

> [!NOTE]
>
> - You need to have the permissions *Elements* > *Access*, *Elements* > *Edit*, *Elements* > *Export DELT* and *Elements* > *Import DELT*. In addition, only elements that you have the right to access will be displayed in the *Element migration* window.
> - It is not possible to migrate spectrum analyzer elements, SLA elements or separate DVE child elements.
