---
uid: Automatically_displaying_external_and_internal_connections
---

# Automatically displaying external and internal connections

External and internal connections can be displayed automatically based on DataMiner Connectivity Framework data that was either imported or detected.

1. On the page, create a shape and customize its line style.

1. Add a shape data field to the shape of type **Connection** and set its value to "Connectivity".

    The shape will not be displayed in Visual Overview, but its line style will be used for all internal and external connections.

1. Draw shapes that represent the elements. In each of those shapes, draw subshapes that represent the element’s interfaces, and group those into one shape group.

    > [!NOTE]
    >
    > - Microsoft Visio does not automatically add connection points to groups. These must be added manually.
    > - From DataMiner 9.0.0 onwards, virtual primary elements from a redundancy group can be used in a Visual Overview displaying DCF connections. The Visual Overview will then automatically update if the redundancy group switches to a different backup element.
    > - If you want to display external connections to elements that are not displayed in the Visio drawing, shapes representing those elements can be generated dynamically. See [Dynamically generating shapes for elements that are out of scope](xref:Dynamically_generating_shapes_for_elements_that_are_out_of_scope).

1. To each of the subshapes, add a shape data field of type **Interface** and set its value to an interface ID or to an interface name (optionally using wildcards).

    > [!NOTE]
    >
    > - For more information on how to link shapes to interfaces that are generated dynamically, see [Linking shapes to dynamically created interfaces](#linking-shapes-to-dynamically-created-interfaces).
    > - Interfaces do not need to be hard-coded. They can also be assigned automatically. See [Automatically linking interfaces to subshapes](#automatically-linking-interfaces-to-subshapes).
    > - If you want a subshape to display the name of the interface it represents, then enter "\*" in the shape text, add a shape data field of type **Info** to the subshape, and set its value to "NAME".
    > - Changes to interfaces are automatically processed by DataMiner Cube and reflected in Visual Overview. If, for example, an element with a particular interface is stopped, the interface will no longer be shown in Visual Overview.

1. Optionally, specify the following additional options in the **Connection** shape data field:

    - To have multiple connections between two elements displayed as multiple lines instead of a single line, specify the additional option "MultipleLinesMode" or "MultipleCurvedLinesMode" in the **Connection** shape data field.

        | Value                                 | Description                                      |
        | ------------------------------------- | ------------------------------------------------ |
        | Connectivity\|MultipleLinesMode       | Displays multiple connections as straight lines. |
        | Connectivity\|MultipleCurvedLinesMode | Displays multiple connections as curved lines.   |

        > [!NOTE]
        >
        > - Multiple connections are possible between different interfaces on external connections, and between any two interfaces on internal connections. However, multiple connections between the same interfaces on external connections are currently not supported. These are always displayed as a single line.
        > - From DataMiner 9.5.3 onwards, it is possible to group connection lines by table column. See [Grouping multiple connection lines by table column](#grouping-multiple-connection-lines-by-table-column).

    - If "MultipleLinesMode" or "MultipleCurvedLinesMode" are used, add the option "LineDistance=\<*number*\>" to customize the distance between the lines. For example, to display multiple connections as straight lines with a distance of twice the line thickness, specify the following value for the **Connection** shape data field:

        ```txt
        Connectivity|MultipleLinesMode|LineDistance=2
        ```

        If this option is not specified, by default, a distance of five times the line thickness is applied between the lines.

1. To further refine how connections are displayed, you can specify the options detailed in the following sections:

    - [Options for displaying DCF connections](xref:Options_for_displaying_DCF_connections)
    - [Options for highlighting DCF connections](xref:Options_for_highlighting_DCF_connections)

> [!TIP]
> For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[dcf > BASIC]* page.

## Automatically linking interfaces to subshapes

It is possible to have element interfaces linked to subshapes automatically.

To do so, add shape data fields of type **Interface** to the subshapes and set their value to "\[auto\]", if necessary, followed by "\|ActivePath:x", "\|Input", "\|Output", "\|InputOutput" or "\|Connector".

| Value | Description |
| ----- | ----------- |
| \[Auto\] | Link the shape to any interface. |
| \[Auto\]\|ActivePath:x | Link the shape to an interface based on the active path. x represents the x-th interface found in the active path.<br>The elements do not need to be directly connected. If, for example, element01 is connected to element02, and element02 is connected to element03, then a connection can be drawn from element01 to element03.<br>However, note that, if you use drawn connections with the "ConnectivityLines" option, up to DataMiner version 9.0.2, indirect connections are not displayed. |
| \[Auto\]\|Input | Link the shape to an Input interface. |
| \[Auto\]\|Output | Link the shape to an Output interface. |
| \[Auto\]\|InputOutput | Link the shape to an InputOutput interface. |
| \[Auto\]\|Connector | Link the shape to an interface used in an external connection, with a static connector line drawn in Visio. If there is an internal connection between two interfaces of this type, no interfaces will be assigned. |

If a page contains multiple instances of the same element, you can assign group names to the shapes so that internal connections are automatically drawn between parent shapes that share the same group name.

To do so, define different interface subshapes on the different parent shapes, to each of which the shape data field **Option** with value "InternalConnectionGroup=Groupname" has been added.

> [!NOTE]
>
> - Interfaces will be resolved in the following order: Interface ID \> Interface name (optionally containing wildcards) \> "\[Auto\]\|ActivePath" \> "\[Auto\]\|Connector" \> "\[Auto\]\|Input" \> "\[Auto\]\|Output" \> "\[Auto\]\|InputOutput" \> "\[Auto\]".
> - From DataMiner version 8.5.4 onwards, connections to non-existing interfaces of a parent shape are not shown. The default behavior in older versions is for the connections to be redirected to the center of the parent shape. If you want the same behavior to occur from version 8.5.4 onwards, add a shape data field to the parent shape of type **Options**, and set its value to "AllowCentralConnectivity".

## Linking shapes to dynamically created interfaces

To link a shape to an interface that is created dynamically based on protocol table data, add a shape data field of type **Options** to the shape and set its value to "InterfaceParameter:" followed by a parameter ID. The shape will then be linked to the dynamically created interface with that parameter ID.

| Shape data field | Value                         |
| ---------------- | ----------------------------- |
| Options          | InterfaceParameter:\<paramID> |

In addition, you can specify the following conditions (or a combination of them, separated by pipe characters):

| Shape data field | Value | Description |  
| ---------------- | ----- | ----------- |
| Options | InterfaceParameter:\<paramID>\|Protocol=\<Protocol>:\<Version> | Only display the shape on interfaces of elements based on the specified protocol (version). |
| Options | InterfaceParameter:\<paramID>\|Input | Only display the shape on interfaces of type Input. |
| Options | InterfaceParameter:\<paramID>\|Output | Only display the shape on interfaces of type Output. |
| Options | InterfaceParameter:\<paramID>\|InputOutput | Only display the shape on interfaces of type InputOutput. |
| Options | InterfaceParameter:\<paramID>\|Internal | Only display the shape on interfaces of internal connections. By default, this type of shape is otherwise only displayed on interfaces of external connections. |

## Grouping multiple connection lines by table column

From DataMiner 9.5.3 onwards, if multiple connections are displayed between elements with the "MultipleCurvedLinesMode" or "MultipleLinesMode" option, it is possible to these have connection lines grouped by table column.

To configure connection line grouping, add a shape data field of type **GroupBy** to the connection shape, and set its value to "TableColumn=", followed by the ID of the column parameter that you wish to group by.

For example:

| Shape data | Value                                              |
| ---------- | -------------------------------------------------- |
| Connection | 234/39\|8333\|8334\|ALARM\|MultipleCurvedLinesMode |
| GroupBy    | TableColumn=145                                    |

> [!NOTE]
>
> - This can particularly be of use when displaying connections between dynamically positioned shapes that are grouped by table column. See [Enabling grouping of dynamically positioned shapes](xref:Enabling_grouping_of_dynamically_positioned_shapes).
> - It is also possible to apply conditional highlighting on connections based on a table column value. See [Highlighting connections based on the table column value of connected shapes](xref:Options_for_highlighting_DCF_connections#highlighting-connections-based-on-the-table-column-value-of-connected-shapes).
