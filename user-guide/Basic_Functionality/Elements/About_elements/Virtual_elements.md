---
uid: Virtual_elements
---

# Virtual elements

The term “virtual element” is used for two different kinds of elements:

- [Virtual elements in a redundancy group](#virtual-elements-in-a-redundancy-group)

- [Virtual elements used for element connections](#virtual-elements-used-for-element-connections)

## Virtual elements in a redundancy group

When a redundancy group is created, for each of the primary elements a virtual element is created. The virtual element will either represent the corresponding primary element or its backup, depending on which is operational. Typically these elements will have names surrounded by curly brackets, e.g. {Virtual Element 1}.

For more information, see [About redundancy groups](xref:About_redundancy_groups).

## Virtual elements used for element connections

It is possible that for a certain element, not all parameters can be communicated through the regular connection. For instance, for an element with an SNMP connection, there may be a few sensors that require an extra element, e.g. an ADAM I/O Box, to communicate their readings to DataMiner. In that case, a virtual element can be created that combines a number of parameters from different “real” elements. In contrast to those “real” elements, the virtual element does not represent a physical device.

A virtual element can also be used to combine multiple elements into a single virtual element (i.e. element consolidation). For instance, a TX element and an RX element can be combined into one virtual RX/TX element.

A virtual element is based on a virtual protocol. This is different from a normal protocol in that it only consists of a list of parameters to be included to the virtual element. When a virtual element is added, the parameters listed in the virtual protocol will be linked to their counterparts found in the “real” elements.

A virtual element can also have new parameters, which often contain the result of a mathematical calculation based on the values of one or more parameters from “real” elements. You could, for instance, retrieve the output level and the input level from a “real” element, calculate the transmission loss and store the result in a new parameter of your virtual element.

### Configuring virtual elements with the Element Connections module

To configure virtual elements in Cube, the *Element Connections* module can be used:

1. In DataMiner Cube, go to *Apps \> Element Connections*.

   The module consists of two tabs:

   - The *configure* tab on the left is where element connections can be configured.

   - The *overview* tab on the right provides an overview of the existing element connections.

1. In the list of elements in the *configure* tab, expand the element for which you want to configure the element connections.

   > [!NOTE]
   >
   > - Only elements of which the protocol has at least one virtual parameter are displayed in the module.
   > - Elements that have been migrated from one DMA to another can only be used for element connections from DataMiner version 9.5.1 onwards.

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
> - You can export an overview of the element connections to a CSV file using the *Export* button in the lower right corner of the module.
> - If there is incorrect or corrupt data in the element connections configuration, the *Element Connections* module is only available for users with full root view access.
