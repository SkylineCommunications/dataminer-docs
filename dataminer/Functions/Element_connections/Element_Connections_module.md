---
uid: Element_Connections_module
description: "Learn how to use the Element Connections module in DataMiner Cube to link parameters and configure virtual elements."
---

# Element Connections module

Use the *Element Connections* module to link parameters in virtual elements to parameters in other elements. For an overview of virtual elements, see [Virtual elements](xref:Virtual_elements).

> [!NOTE]
> The *Element Connections* module does not configure DataMiner Connectivity Framework connections between protocol interfaces. To configure those connections, see [Configuring element connectivity in Cube](xref:Editing_element_connections_in_the_Properties_window).

## Configuring virtual elements

1. In DataMiner Cube, go to *Apps \> Element Connections*.

   The module consists of two tabs:

   - The *configure* tab on the left is where you configure element connections.

   - The *overview* tab on the right provides an overview of existing element connections.

1. In the *configure* tab, expand the element for which you want to configure element connections.

   > [!NOTE]
   > Only elements with at least one virtual parameter in their protocol are displayed in the module.

1. For each parameter of the virtual element that you want to connect to a parameter from another element:

   1. In the *Instance* column, select the table index if necessary.

   1. In the *Linked element* column, select the element you want to link to the selected parameter.

   1. In the *Linked parameter* column, select the parameter you want to link to the selected parameter.

   1. In the *Linked instance* column, select the table index if necessary.

   1. In the *Include element* column, clear the checkbox if you do not want the state of the connected element to influence the state of the virtual element. Otherwise, keep the checkbox selected.

   > [!NOTE]
   > To duplicate a row, for example because different rows in the same table need to be linked to a different element, right-click the row and select *Duplicate*.

1. Click the *Save* button at the bottom of the card.

> [!NOTE]
>
> - You can export an overview of the element connections to a CSV file using the *Export* button in the lower-right corner of the module.
> - If there is incorrect or corrupt data in the element connections configuration, the *Element Connections* module is only available for users with full root view access.
