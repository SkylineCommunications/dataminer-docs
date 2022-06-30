---
uid: Viewing_element_connections
---

# Viewing element connections

> [!NOTE]
> In DataMiner Cube, there is also an *Element Connections* module, which is in fact not related to the DataMiner Connectivity Framework functionality. For more information on this module, refer to [Virtual elements used for element connections](xref:Virtual_elements#virtual-elements-used-for-element-connections).

## Viewing the element connections in the Properties window

To view the connections that have been set for an element:

1. Right-click the element and select *Properties*.

1. Select the *Connectivity* tab.

   The *Connectivity* tab has two subtabs:

   - *internal*: Shows what interfaces are connected within the element, and what filters have been configured.

   - *external*: Shows what interfaces are connected on each of the connected elements, the name of the destination element, and what filters have been configured.

> [!NOTE]
> The *Connectivity* tab is only available for elements that have in/out interfaces defined in their protocol.

## Navigating between connected elements

In Cube, it is possible to quickly navigate between connected elements. To do so:

1. Right-click the element in the Surveyor or on a view card.

1. In the shortcut menu, select *Navigate*.

   In the *Navigate* submenu, all elements connected to this element will be displayed.

1. In the submenu, select the name of the element to which you wish to navigate.

   The element card of the element will be opened.

> [!NOTE]
> If no connections have been configured for an element, the *Navigate* command is not displayed in the Surveyor shortcut menu.
