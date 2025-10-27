---
uid: Creating_an_internal_connectivity_chain
---

# Creating an internal connectivity chain

To create a connectivity chain between parameters in an element:

1. In the *Correlation* module, go to the *connectivity editor* tab, and click *Launch connectivity editor*.

   The *Connectivity Editor* will be opened in a separate window.

1. In the *Connectivity Editor*, click *File \> New Internal Element Chain*.

   > [!NOTE]
   > An alarm template has to be defined on the element before parameters can be used in the connectivity editor.

1. In the *Select Element* window, select an element.

1. Drag and drop parameters from the *Parameters* pane to the pane on the right.

1. Make a topology connection between the parameters:

   - Right-click a parameter and select *Link* or *Unlink*, or

   - Drag and drop while pressing the *Ctrl* key.

     > [!NOTE]
     > If you use the drag-and-drop functionality to link the items in a chain, you must drag to the top or bottom border of items. The direction of the link depends on whether you choose the top or bottom border. Dragging to the top border creates a link from the dragged item to the target item, dragging to the bottom border creates a link to the dragged item from the target item.

1. Optionally, you can put multiple parameters together:

   1. Right-click a parameter and select *Select Parameters*.

   1. Select the parameters in the *Available* list, and move them to the *Included* list with the *\<* button.

   1. Click *OK*. The included parameters are now indicated together as one item in the internal chain.

1. If necessary, click the *Options* button in the lower-right corner to configure the following options for the chain:

   - **Require alarms to occur on consecutive elements** ... : If this option is selected, the RCA level is reset if the parent parameter is not in alarm, even if other parameters are in alarm higher up in the chain.

   - **Use unique RCA levels when multiple parameters are combined** ... : If this option is selected, and a block contains multiple parameters, a different RCA level is applied for parameters in that same block. The first parameter that triggers an alarm can for example get RCA level 0, the next one level 1, etc.

1. When all necessary parameters have been added and linked, click the *Save* button.
