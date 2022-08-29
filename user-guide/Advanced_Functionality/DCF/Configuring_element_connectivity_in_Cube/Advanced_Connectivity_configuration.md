---
uid: Advanced_Connectivity_configuration
---

# Advanced Connectivity configuration

Element Connectivity information is stored in four tables in the element protocol. It is possible to view and edit these tables within the Cube interface.

To do so:

1. Go to the element’s *General parameters* page.

1. Scroll down to the bottom of the page and click the *Configure* button next to *DataMiner Connectivity Framework*.

   A window with the four tables will then be displayed, each with an expandable details pane on the right side.

## The Interfaces table

This table displays the interfaces defined in the protocol, with their interface name and type. the table also displays the interface alarm state, which depends on the alarm state of the parameter that the interface is designed for.

In this table, you can give an interface a custom name by entering a custom value in the *Custom Name* column.

## The Connections table

The connections table allows you to view and configure the connections between interfaces.

> [!NOTE]
>
> - When an element is restarted, connections and properties that cannot be linked to an existing interface will automatically be deleted.
> - Resolving multiple external connections on the same interface is only supported from DataMiner 9.5.5 onwards.

### Adding a connection

1. Next to *\[Add Connection\]*, click the *Add* button.

1. In the column *\[Connections Name\]*, enter a name for the connection. E.g. “input 1 –> output 3”

1. In the column *\[Source Interface\]*, enter the Interface ID of the source.

1. In the column *\[Destination DataMiner/Element\]*, enter the original DMA ID and element ID of the destination element.

1. In the column *\[Destination Interface\]*, enter the Interface ID of the destination.

1. Optionally, enter a filter in the column *\[Connections Filter\]*.

    This filter is the same as the filter you can add in the Connectivity tab of the element’s Properties window. See [Editing element connections in the Properties window](xref:Editing_element_connections_in_the_Properties_window).

> [!NOTE]
> If you want to set up a connection between two elements, make sure to add a connection to the connections table of both elements.
>
> Say you want to connect interface 1 of element A to interface 2 of element B:
>
> - In the connections table of element A, add the following connection:
>   - Source interface: 1
>   - Destination element: B
>   - Destination interface: 2
> - In the connections table of element B, add the following connection:
>   - Source interface: 2
>   - Destination element: A
>   - Destination interface: 1

### Deleting a connection

1. Enter the connection ID in the box under *\[Connection to delete\]* and click the green check mark.

1. Next to *\[Add Connection\]*, click the *Delete* button.

1. If a confirmation window appears, click *Yes* to confirm deletion.

## The Interface Properties table and Connection Properties table

In these tables, it is possible to add and delete custom properties. This is done in the same way as the adding and deleting of connections in the Connections table.

However, in normal circumstances users will not need to make use of this functionality, as properties are usually managed by the protocol itself.

> [!NOTE]
> If you have set up a connection between two elements, you have to add a connection to the connections table of both elements. If you want to add properties to such a connection, make sure to add those properties both to the connection you added in element A and to the connection you added in element B.
