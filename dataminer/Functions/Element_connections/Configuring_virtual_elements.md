---
uid: Configuring_virtual_elements
description: "Learn how to use the Element Connections module in DataMiner Cube to link parameters of a virtual element to parameters of other elements."
keywords: Element Connections module, virtual elements
---

# Configuring virtual elements

Use the following procedure to link the parameters of a virtual element to parameters of other elements:

1. In DataMiner Cube, go to *Apps* > *Element Connections*.

   The module consists of two tabs:

   - The *configure* tab on the left is where you configure element connections.

   - The *overview* tab on the right provides an overview of existing element connections.

1. In the *configure* tab, expand the element for which you want to configure element connections.

   > [!NOTE]
   > Only elements with at least one virtual parameter in their protocol are displayed in the module.

1. For each virtual element parameter that you want to connect to a parameter from another element, complete the following steps:

   1. In the *Instance* column, select the table index if necessary.

   1. In the *Linked element* column, select the element you want to link to the selected parameter.

   1. In the *Linked parameter* column, select the parameter you want to link to the selected parameter.

   1. In the *Linked instance* column, select the table index if necessary.

   1. In the *Include element* column, clear the checkbox if you do not want the state of the connected element to influence the state of the virtual element. Otherwise, keep the checkbox selected.

   > [!TIP]
   > To duplicate a row, for example because different rows in the same table need to be linked to a different element, right-click the row and select *Duplicate*.

1. Click the *Save* button at the bottom of the card.

   The linked parameters are now updated whenever the parameter values of the linked elements change.

> [!NOTE]
>
> - You can export an overview of the element connections to a CSV file using the *Export* button in the lower-right corner of the module.
> - If there is incorrect or corrupt data in the element connections configuration, the *Element Connections* module is only available for users with full root view access.
