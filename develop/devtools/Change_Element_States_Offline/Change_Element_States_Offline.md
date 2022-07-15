---
uid: Change_Element_States_Offline
---

# Change Element States Offline

This tool can be used to change element states while a DMA is not running.

This can be particularly useful to stop all or multiple elements in case a DMA fails to start up and the cause appears to be element-related. After you have stopped the elements, you can then start the DMA and start the elements one by one in order to pinpoint the element causing the problem.

![Change Element States Offline](~/develop/images/Change-Element-States-Offline.png)

To change element states using this tool:

1. Make sure the DMA where you want to change element states is stopped.

1. On the DMA, go to the folder `C:\Skyline DataMiner\Tools` and run *ChangeElementStatesOffline.exe*.

   By default, the *Elements by Name* tab is displayed, where you can see all the elements on the DMA, listed by name. From DataMiner 10.0.13 onwards, the state of the element is displayed in parentheses after the name. From DataMiner 10.0.13 onwards, there is also an *Elements by Protocol* tab, with a tree structure that allows you to drill down to elements using specific protocol and protocol version.

1. Indicate for which elements the state should change:

   - In the *Elements by Name* tab, move the elements for which you want to change the state from the column on the left to the column on the right using the arrow buttons in between the columns. To quickly select all elements in a column, select the first element and then press SHIFT + END. From DataMiner 10.0.13 onwards, you can simply press CTRL + A instead. To filter the displayed elements, add a filter value in the box on the right (available from DataMiner 10.0.13 onwards).

   - In the *Elements by Protocol* tab, select the checkboxes in front of the elements for which you want to change the state. If you select the checkbox in front of a protocol or protocol version, the state of all elements using that protocol or protocol version will be changed. To search for specific items in the tree view, add a search term in the box on the right.

   - From DataMiner 10.0.13 onwards, an option is available to reload the displayed elements, to make sure that any recent changes on the disk are taken into account. This *Reload from Disk* option is available via the file menu.

1. Set the target state. By default, *Stopped* is selected.

   - From DataMiner 10.0.12 onwards, select the target state in the drop-down box on the right, and click SET STATE.
   - Prior to DataMiner 10.0.12, select the target state in the drop-down box at the bottom of the window, and click SET. -

When you have done this, the tool will update all *Element.xml* files with the new state. The *Output* tab of the tool, which lists all warnings and actions of the tool, will display information whether changes have been executed successfully or not.

From DataMiner 10.0.13 onwards, the tool also allows you to export the element states in CSV or XML format. To do so, go to the *File* menu, select *Export*, and select your preferred export format.

> [!NOTE]
> If you are using a version of this tool prior to DataMiner 10.0.12, do not use the *Add Second Port* option. Also note that the tool may not function correctly when updating an element state in case an element folder contains other element folders where an *Element.xml* file is missing.
