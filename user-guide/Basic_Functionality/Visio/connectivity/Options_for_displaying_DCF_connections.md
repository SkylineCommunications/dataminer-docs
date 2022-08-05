---
uid: Options_for_displaying_DCF_connections
---

# Options for displaying DCF connections

A number of different options are available for connections displayed in Visual Overview:

| Option | Section |
| ------ | ------- |
| ConnectivityLines\|Highlightpath | [Using existing lines as connectivity lines](#using-existing-lines-as-connectivity-lines) |
| EnableViewConnectivity | [Enabling view connections](#enabling-view-connections) |
| ConnectionLinesOnBackground<br>ConnectionLinesOnForeground<br>InterfaceConnectionLinesOnBackground | [Placing connection lines in the background or in the foreground](#placing-connection-lines-in-the-background-or-in-the-foreground) |
| DisableConnectivity | [Hiding all connections of an element](#hiding-all-connections-of-an-element) |
| InternalInterfaceHopping | [Displaying connections when some interfaces are missing](#displaying-connections-when-some-interfaces-are-missing) |
| Connectionproperty | [Displaying connection properties](#displaying-connection-properties) |
| EnableConnectionOverview | [Displaying DCF connection property information](#displaying-dcf-connection-property-information) |
| FollowPathColor<br>FollowInterfacePathColor<br>FollowPathColorFill<br>FollowInput | [Making connections inherit alarm colors](#making-connections-inherit-alarm-colors) |
| StraightLines | [Using a pathing algorithm to display connection lines](#using-a-pathing-algorithm-to-display-connection-lines) |
| ShowInterfaceAlarmColor | [Making connections take the alarm color of connected interfaces](#making-connections-take-the-alarm-color-of-connected-interfaces) |
| RetrieveInternalConnectivity | [Subscribing to internal connections when using dynamic positioning](#subscribing-to-internal-connections-when-using-dynamic-positioning) |
| LinkConnectionProperty | [Linking connection properties](#linking-connection-properties) |

> [!TIP]
> For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[dcf]* page.

## Using existing lines as connectivity lines

By default, straight lines will be drawn automatically to visualize connectivity. However, it is also possible to manually draw fixed lines and have those used instead.

If you want to use existing lines to visualize connectivity, then add a shape data field of type **Options** to the page and set its value to "ConnectivityLines\|Highlightpath".

> [!NOTE]
>
> - Make sure the manually drawn lines are connected to the correct interfaces. If a line is connected to the parent shape of an interface instead of the interface itself, the path will not be used.
> - If you draw a connection line to a shape that is not linked to a DataMiner object, you will need to make sure a connection point is configured on the shape, as otherwise it will not be clickable and highlightable in DataMiner. To add a connection point, in Visio, select the connection point tool in the ribbon (displayed as a blue X in the *Home* tab), select the shape, and then click the shape again while keeping the *CTRL* key pressed.

## Enabling view connections

In order to make it possible to connect views with DCF connections, add a shape data field of type **Options** to the connectivity shape and set its value to "EnableViewConnectivity".

A view is considered to be connected to another view if the elements in those views are connected. This means that the element connectivity is aggregated in the view connectivity, allowing element connectivity to be grouped by view.

## Placing connection lines in the background or in the foreground

By default, external and internal connections are drawn like this:

| Type of connection                                                          | Background or foreground |
| --------------------------------------------------------------------------- | ------------------------ |
| External connections (without subshapes representing interfaces)            | Background               |
| External connections (with at least one subshape representing an interface) | Foreground               |
| Internal connections                                                        | Foreground               |

If you want to override this default behavior, add a shape data field of type **Options** to the page and set one of the following values:

| Value                                | Description                                                                                                          |
| ------------------------------------ | -------------------------------------------------------------------------------------------------------------------- |
| ConnectionLinesOnBackground          | All connections (internal and external) are drawn in the background.                                                 |
| ConnectionLinesOnForeground          | All connections (internal and external) are drawn in the foreground.                                                 |
| InterfaceConnectionLinesOnBackground | All external connections are drawn in the background.<br>All internal connections are drawn in the foreground. |

## Hiding all connections of an element

If you do not want the connections of a particular element to be displayed, add a shape data field of type **Options** to the shape that represents the element and set its value to "DisableConnectivity".

## Displaying connections when some interfaces are missing

By default, internal connections between interfaces that are not shown in a Visio drawing will not be drawn. If, for example, a connection is present from interface A to interface B and another connection is present from interface B to interface C, no connection will be shown when only interface A and C are shown on the Visio drawing.

However, it is possible to make DataMiner Cube display temporary connections between interfaces if there is a DCF path between the two corresponding interfaces, even if some interfaces in the chain are not displayed. This means that in the example above, the connection between A and C will be drawn.

To do so, add a shape data field of type **Option** to the shape and set its value to "InternalInterfaceHopping".

| Shape data field | Value                    |
| ---------------- | ------------------------ |
| Options          | InternalInterfaceHopping |

> [!NOTE]
> Prior to DataMiner 9.6.11, this option is not compatible with the "FollowPathColor" option. See [Making connections inherit alarm colors](#making-connections-inherit-alarm-colors).

## Displaying connection properties

To have a connection property displayed on top of every connection that contains that property:

1. Add a shape to the drawing and set the shape text to "\*".

1. Add a shape data field of type **Options** with the value "ConnectionProperty:", followed by the name of the property.

    | Shape data field | Value                             |
    | ---------------- | --------------------------------- |
    | Options          | ConnectionProperty:*PropertyName* |

1. By default, these property shapes will be placed in the center of a connection. If instead you want them to be placed on top of interface/connection intersections, add the option "Protocol=ProtocolName:Version".

    | Shape data field | Value                                                                |
    | ---------------- | -------------------------------------------------------------------- |
    | Options          | ConnectionProperty:*PropertyName*\|Protocol=*ProtocolName*:*Version* |

    > [!NOTE]
    > If you use this option, property shapes will only be placed on interfaces of which the protocol of the parent element matches the protocol you specified in the shape data field.

1. If you want a calculated value to be displayed instead of the property itself, add a semicolon, followed by the calculation that has to be made. This can be "Sum", "Min", "Max", "Concat" or "Avg". Note that when you use "Concat", the result will no longer be a numeric value but a string value (e.g. \<value1>, \<value2>).

    | Shape data field | Value                                           |
    | ---------------- | ----------------------------------------------- |
    | Options          | ConnectionProperty:*PropertyName*;*calculation* |

    Example:

    | Shape data field | Value                        |
    | ---------------- | ---------------------------- |
    | Options          | ConnectionProperty:Speed;Avg |

> [!NOTE]
>
> - On connection property shapes, conditional shape manipulation actions can be defined that check conditions such as the value of the property, whether a connection is highlighted, and whether the mouse pointer is on a connection.<br>See [Conditional manipulation of connection shapes](xref:Extended_conditional_shape_manipulation_actions#conditional-manipulation-of-connection-shapes).
> - Displaying connection properties between dynamically generated shapes is only supported from DataMiner 9.0.5 CU1 onwards.

## Displaying DCF connection property information

It is possible to have a pop-up box with more information on the connection properties appear when a user clicks a particular connection.

If the highlighting option "ActivePathHighlighting" is not used, this pop-up box will contain all connection and interface properties of the connection that was clicked. If "ActivePathHighlighting" is used, the pop-up will contain the connection properties that were used to calculate the active, highlighted, path.

> [!TIP]
> See also: [Highlighting connections from a Connectivity.xml chain](xref:Options_for_highlighting_DCF_connections#highlighting-connections-from-a-connectivityxml-chain)

To have a pop-up box displayed with connection property information:

- In a hidden connectivity shape (i.e. the shape in which you have added a shape data field of type **Connection** set to "Connectivity"), add a shape data field of type **Options** set to "EnableConnectionOverview".

| Shape data field | Value                    |
| ---------------- | ------------------------ |
| Connection       | Connectivity             |
| Options          | EnableConnectionOverview |

> [!NOTE]
> If a user clicks a line that represents multiple connections, the connection properties window will list all connections represented by that line, along with the following information for each connection:
>
> - The alarm colors of both connected interfaces.
> - The names of both connected interfaces, each followed by the element name.
> - An arrow that indicates the direction of the connection.
> - All connection and interface properties of the connection.

## Making connections inherit alarm colors

It is possible to activate "follow mode", so that connection lines will automatically adopt the alarm color of the shapes they connect. That way, you can clearly pinpoint a problem in a chain and indicate its impact. Alternatively, you can instead make the connections inherit the alarm color of the interfaces.

- To make the connections inherit the alarm color of the elements they connect, add a shape data field of type **Options** to the page and set its value to "FollowPathColor".

    > [!NOTE]
    > Connections linking an output shape of one element to an input shape of another element (i.e. external connections) will adopt the alarm color of the output shape if the alarm status of the output shape is higher.
    > Connections linking an input shape and an output shape of the same element (i.e. internal connections) will adopt the alarm color of the input shape, except when the element has a higher alarm state. In that case, they will adopt the alarm color of the element.

- To make connections inherit the alarm color of the interfaces, add a shape data field of type **Options** to the page and set its value to "FollowInterfacePathColor".

    > [!NOTE]
    > A connection leaving an interface will inherit the alarm color of that interface if the alarm severity is higher than the alarm severity of the preceding connection.

The following additional options are also available:

- **FollowPathColorFill**: If you want a shape in the chain to be filled with the highlight color, add a shape data field of type **Options** to the shape and set its value to "FollowPathColorFill".

- **FollowInput**: If you want a series of interconnected shapes to take on a specific color by default, then add a shape data field of type **Options** to the first shape in the series and set its value to "FollowInput".

## Using a pathing algorithm to display connection lines

From DataMiner 9.5.1 onwards, it is possible to use a pathing algorithm to automatically draw connection lines as clearly visible as possible, using a combination of horizontal and vertical lines.

To enable this algorithm, in the **Options** shape data field of the **Connection** shape in Visio, add the "StraightLines" option.

The algorithm will attempt to do the following things, in order of priority:

- Only draw a combination of vertical and horizontal lines, with the exception of the line from outside the shape to the center of the shape, which can still be diagonal.

    For an optimal result, we advise you to use the Visio page option **InterfaceConnectionLinesOnBackground** as well. See [Placing connection lines in the background or in the foreground](#placing-connection-lines-in-the-background-or-in-the-foreground).

- Make sure lines do not go through other connectivity shapes.

- Make sure lines do not cross each other, or if it is unavoidable that they cross, make sure they have as few common points as possible, so that the separate lines are always clearly visible.

- Avoid unnecessary corners, to avoid a staircase effect.

- Avoid lines getting too close to other shapes.

- Take the shortest path.

> [!NOTE]
> The "StraightLines" option does not work in conjunction with the "MultipleLinesMode" or "MultipleCurvedLinesMode" options.

## Making connections take the alarm color of connected interfaces

From DataMiner 9.5.2 onwards, you can make connection lines take the alarm color of the interfaces they are connected to.

To do so, add a shape data field of type **Options** to the **Connection** shape, and set it to one of the following values:

| Value                             | Description                                   |
| --------------------------------- | --------------------------------------------- |
| ShowInterfaceAlarmColor<br>ShowInterfaceAlarmColor:both | Shows the alarm color of the most severe alarm of both connected interfaces. |
| ShowInterfaceAlarmColor:forwards  | Connection lines show the alarm color of the preceding interface, depending on the direction of the signal. |
| ShowInterfaceAlarmColor:backwards | Connection lines show the alarm color of the upcoming interface, depending on the direction of the signal.  |

> [!NOTE]
> Using this option together with the "EnableViewConnectivity" option is only supported from DataMiner 9.5.3 onwards.

## Subscribing to internal connections when using dynamic positioning

By default, from DataMiner 9.5.3 onwards, when dynamic positioning is used, internal connections are not subscribed to. If you do want to subscribe to internal connections when using dynamic positioning, specify the following shape data on the **Connectivity** shape:

| Shape data field | Value                        |
| ---------------- | ---------------------------- |
| Options          | RetrieveInternalConnectivity |

## Linking connection properties

From DataMiner 9.5.9 onwards, it is possible to link connection properties of internal connections to connection properties of external connections.

If you do so, internal connections will push their connection properties to the directly linked external connections along the path. The properties will not be passed from an input to an external connection. If multiple connection properties share a name, they will be separated by commas in the connection overview.

To implement this feature, add "LinkConnectionProperty=*X*;*Y*" to the **Options** shape data item of the connection shape, where X and Y are the names of the properties you want to link. Multiple properties can be separated by semicolons.

| Shape data field | Value                          |
| ---------------- | ------------------------------ |
| Options          | LinkConnectionProperty=*X*;*Y* |

> [!NOTE]
> When using dynamic positioning in combination with this feature, set the "RetrieveInternalConnectivity" option on the connection shape to make sure the internal connection properties are retrieved. See [Subscribing to internal connections when using dynamic positioning](#subscribing-to-internal-connections-when-using-dynamic-positioning).
