---
uid: Virtual_elements
description: "Learn about virtual elements in DataMiner, including virtual elements used in redundancy groups and for linking parameters."
---

# Virtual elements

The term “virtual element” is used for two different kinds of elements:

- [Virtual elements in a redundancy group](#virtual-elements-in-a-redundancy-group)

- [Virtual elements used for element connections](#virtual-elements-used-for-element-connections)

## Virtual elements in a redundancy group

When a redundancy group is created, for each of the primary elements a virtual element is created. The virtual element will either represent the corresponding primary element or its backup, depending on which is operational. Typically these elements will have names surrounded by curly brackets, e.g., {Virtual Element 1}.

For more information, see [About redundancy groups](xref:About_redundancy_groups).

## Virtual elements used for element connections

It is possible that for a certain element, not all parameters can be communicated through the regular connection. For instance, for an element with an SNMP connection, there may be a few sensors that require an extra element, e.g., an ADAM I/O Box, to communicate their readings to DataMiner. In that case, a virtual element can be created that combines a number of parameters from different “real” elements. In contrast to those “real” elements, the virtual element does not represent a physical device.

A virtual element can also be used to combine multiple elements into a single virtual element (i.e., element consolidation). For instance, a TX element and an RX element can be combined into one virtual RX/TX element.

A virtual element is based on a virtual protocol. This is different from a normal protocol in that it only consists of a list of parameters to be included to the virtual element. When a virtual element is added, the parameters listed in the virtual protocol will be linked to their counterparts found in the “real” elements.

A virtual element can also have new parameters, which often contain the result of a mathematical calculation based on the values of one or more parameters from “real” elements. You could, for instance, retrieve the output level and the input level from a “real” element, calculate the transmission loss and store the result in a new parameter of your virtual element.

To link parameters and configure virtual elements, use the [Element Connections module](xref:Element_Connections_module).
