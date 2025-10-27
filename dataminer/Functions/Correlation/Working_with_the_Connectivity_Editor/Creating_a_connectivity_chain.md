---
uid: Creating_a_connectivity_chain
---

# Creating a connectivity chain

To create a connectivity chain:

1. In the *Correlation* module, go to the *connectivity editor* tab, and click *Launch connectivity editor*.

   The connectivity editor will be opened in a separate window.

1. In the *Connectivity Editor* window:

   - Click *File \> New Element Chain* to create an element chain.

   - Click *File \> New Internal Service Chain* to create an element chain within a service.

   - Click *File \> New Service Chain* to create a service chain.

1. Drag and drop elements or services to the pane on the right.

1. Make a topology connection between elements or services:

   - Right-click an element or service and select *Link* or *Unlink*, or

   - Drag and drop while pressing the *Ctrl* key.

     > [!NOTE]
     > If you use the drag-and-drop functionality to link the items in a chain, you must drag to the top or bottom border of items. The direction of the link depends on whether you choose the top or bottom border. Dragging to the top border creates a link from the dragged item to the target item, dragging to the bottom border creates a link to the dragged item from the target item.

1. Optionally, narrow down the possible causes for an element or service by selecting only some of its parameters:

   1. Right-click the element and select *Select Parameters*.

   1. Select the option *Include a SELECTION of parameters*.

   1. Select the parameters in the *Available* list, and move them to the *Included* list with the *\<* button.

      > [!NOTE]
      > Only monitored parameters are available in this window.

   1. Click *OK*. The included parameters are now indicated on the item in the chain.

1. If necessary, click the *Options* button in the lower-right corner to configure the following options for the chain:

   - **Require alarms to occur on consecutive elements** **in the chain** ... : If this option is selected, the RCA level is reset if the parent element is not in alarm, even if other elements are in alarm higher up in the chain.

   - **Use unique RCA levels when multiple parameters are combined** ... : If this option is selected, and a block contains multiple parameters, a different RCA level is applied for parameters in that same block. The first parameter that triggers an alarm can for example get RCA level 0, the next one level 1, etc.

1. When all necessary items have been added and linked, click the *Save* button.
