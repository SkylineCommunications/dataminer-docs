---
uid: Options_for_highlighting_DCF_connections
---

# Options for highlighting DCF connections

In addition to the options determining how connections are displayed, there are also a number of options that determine how they can be highlighted:

| Option | Section |
| ------ | ------- |
| ActivePathHighlighting | [Highlighting connections from a Connectivity.xml chain](#highlighting-connections-from-a-connectivityxml-chain) |
| HighlightAnimation | [Displaying an animated shape on highlighted connections](#displaying-an-animated-shape-on-highlighted-connections) |
| HighlightPath | [Controlling highlighting when using physical connectors](#controlling-highlighting-when-using-physical-connectors) |
| HighlightShapesOnly | [Applying highlighting to shapes only](#applying-highlighting-to-shapes-only) |
| HighlightStyle | [Customizing the highlight style](#customizing-the-highlight-style) |
| HighlightStyle\|LineProperty | [Applying only certain highlight style properties](#applying-only-certain-highlight-style-properties) |
| HighlightTarget | [Conditionally applying a highlight style](#conditionally-applying-a-highlight-style) |
| IgnoreInternalConnections | [Ignoring internal connections](#ignoring-internal-connections) |
| NoHighlightLineStyle<br>NoHighlightFillStyle<br>NoHighlightTextStyle | [Ignoring the highlight style](#ignoring-the-highlight-style) |
| SelectionHighlighting | Available from DataMiner 10.0.3 onwards.<br>[Disabling path highlighting when a connection line is clicked](#disabling-path-highlighting-when-a-connection-line-is-clicked) |

> [!NOTE]
>
> - When connectivity has been defined in a drawing, you can highlight the connectivity chain using a shortcut menu command. Right-click a shape, and select *Display connectivity*.
> - As of DataMiner version 8.5.4, when a shape or connection is highlighted, only the connections before and after the shape will be highlighted, instead of the entire connected framework.
> - If multiple kinds of highlighting are used in one drawing, and only a single highlighting style is used, all highlight conditions must be true for an object to be highlighted.
> - If multiple kinds of highlighting are used in one drawing, i.e. connectivity highlighting using the **HighlightTarget** shape data combined with redundancy group highlighting and/or conditional shape highlighting, and a different highlighting style is used for each type, a shape is highlighted as soon as one of the highlight conditions is true.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[dcf]* page.

> [!TIP]
> See also: [Highlighting a connection chain based on a filter shape](xref:Highlighting_a_connection_chain_based_on_a_filter_shape)

## Controlling highlighting when using physical connectors

When shapes are physically connected via drawn connectors, you can use the "HighlightPath" option to make sure the chain is highlighted when users click a shape or a connection in the chain.

Add a shape data field of type **Options** to the page, and set its value to "HighlightPath".

## Customizing the highlight style

If you want to customize the highlight style, create a shape or a connection, apply a custom style to it, add a shape data field of type **Options** to it and set its value to "HighlightStyle". The shape or connection you created will not be displayed, but its line style will be used for all shapes and connections in the chain.

> [!NOTE]
> If no highlight style has been defined, the thickness of a highlighted line or border will be three times the normal thickness (with a minimum of 3 px).

## Displaying an animated shape on highlighted connections

From DataMiner 9.5.12 onwards, you can use the "HighlightAnimation" option to display an animated shape on a highlighted DCF connection line.

When you do so, you can also configure the animation speed and interval with the "LineAnimationSpeed" and "LineAnimationInterval" options respectively. The animation speed is measured in pixels/second and the interval is measured in milliseconds.

For example:

| Shape data field | Value                                                                 |
| ---------------- | --------------------------------------------------------------------- |
| Options          | HighlightAnimation\|LineAnimationSpeed=100\|LineAnimationInterval=500 |

> [!NOTE]
>
> - The shape will follow the path of the line, even when "MultipleCurvedLinesMode" is used.
> - Configuring an offset is possible by positioning the rotation point of the animated shape.

## Ignoring internal connections

From DataMiner 9.5.1 onwards, to ignore the internal structure of elements for path highlighting, add a shape data field of type **Options** to the page, and set its value to "IgnoreInternalConnections".

> [!NOTE]
> Up to DataMiner 9.0.4, if no interfaces are displayed, an element in a chain will still be highlighted even if it is not connected internally. This option allows you to return to this behavior when using DataMiner version 9.5.1 and higher.

## Ignoring the highlight style

If you want a particular shape to ignore parts of the custom highlight style you configured, you can add a shape data field of type **Options** to that shape and set its value to one or more of the following options:

| Option               | Description                                                        |
| -------------------- | ------------------------------------------------------------------ |
| NoHighlightLineStyle | Keeps a shape from changing its line style when it is highlighted. |
| NoHighlightFillStyle | Keeps a shape from changing its fill style when it is highlighted. |
| NoHighlightTextStyle | Keeps a shape from changing its text style when it is highlighted. |

If you specify more than one option, separate the options with pipe characters as shown in the following example:

```txt
NoHighlightLineStyle|NoHighlightFillStyle|NoHighlightTextStyle
```

## Applying only certain highlight style properties

If you want to apply only certain line properties of a **HighlightStyle** shape to the shapes and connections, add the "LineProperty=" option to the shape's **Options** shape data field, followed by one or more of the following properties. If you specify multiple properties, separate them by commas.

- Thickness
- Color
- Dash

Example:

| Shape data field | Value                                       |
| ---------------- | ------------------------------------------- |
| Options          | HighlightStyle\|LineProperty=Dash,Thickness |

## Applying highlighting to shapes only

If you only want the shapes to be highlighted and not the connections between them, then add a shape data field of type **Options** to the page, and set its value to "HighlightShapesOnly".

## Conditionally applying a highlight style

- [Applying a highlight style depending on a connection property](#applying-a-highlight-style-depending-on-a-connection-property)
- [Applying highlight styles depending on various conditions](#applying-highlight-styles-depending-on-various-conditions)
- [Highlighting connections based on the table column value of connected shapes](#highlighting-connections-based-on-the-table-column-value-of-connected-shapes)
- [Highlighting connections based on the source and target of the connection](#highlighting-connections-based-on-the-source-and-target-of-the-connection)

### Applying a highlight style depending on a connection property

To have the highlight style applied conditionally depending on whether a specific connection property condition is fulfilled, add an additional shape data field of type **Highlight** to the shape determining the highlight style, and specify the following value:

```txt
property:[PropertyName]=[Regular expression matching the property value]
```

The style of this shape will then be applied to all connections of which the value of the specified property matches the specified regular expression.

> [!NOTE]
> The condition in the shape data field of type **Highlight** can contain placeholders referring to session variables (e.g. "\[var:mySessionVariable\]").

### Applying highlight styles depending on various conditions

To make a highlighting style conditional, in the **Options** shape data field of the shape that defines the highlight style, add the option "HighlightTarget=", followed by one or more of the methods listed below. If you specify multiple methods, separate them by commas.

| Method | Description |
| ------ | ----------- |
| ActivePath | Shapes and connections will be highlighted if they are part of the active path. |
| ConnectionProperty | Shapes and connections will be highlighted if they have a specific property.<br>In that case, the property and the property value have to be specified as "Property:PropertyName=RegularExpression" in a shape data field of type **Highlight**.<br>When you specify a highlight style without HighlightTarget, and there is a shape data field of type **Highlight**, DataMiner Cube will automatically set the HighlightTarget to "ConnectionProperty". |
| Filter | Shapes and connections will be highlighted if a connection filter matches. |
| Select | Shapes and connections will be highlighted if they are logically linked to the shape or connection that was clicked. |
| SourceDestination | Available from DataMiner 9.6.1 onwards. See [Highlighting connections based on the source and target of the connection](#highlighting-connections-based-on-the-source-and-target-of-the-connection). |
| TableColumn | Available from DataMiner 9.5.3 onwards. See [Highlighting connections based on the table column value of connected shapes](#highlighting-connections-based-on-the-table-column-value-of-connected-shapes). |

Example:

| Shape data field | Value                                         |
| ---------------- | --------------------------------------------- |
| Options          | HighlightStyle\|HighlightTarget=Select,Filter |

> [!NOTE]
>
> - By creating different HighlightStyle shapes with different conditions applied, you can combine several highlight styles within the same Visual Overview.
> - The "HighlightTarget" option can be combined with the "LineProperty" option. For example: "HighlightStyle\|HighlightTarget=ConnectionProperty,Select\|LineProperty=Color".<br>See [Applying only certain highlight style properties](#applying-only-certain-highlight-style-properties).

### Highlighting connections based on the table column value of connected shapes

From DataMiner 9.5.3 onwards, a specific type of conditional connection highlighting is available where connections are highlighted depending on the table column value corresponding to the connected shapes.

To enable highlighting based on table column value, add a highlight shape to the Visio page with the following shape data items:

| Shape data | Value                                       |
| ---------- | ------------------------------------------- |
| Options    | HighlightStyle\|HighlightTarget=TableColumn |
| Highlight  | TableColumn:*ColumnParameterID*=*Value*     |

### Highlighting connections based on the source and target of the connection

From DataMiner 9.6.1 onwards, it is possible to configure a highlight style that is only applied if the path comes from a certain source and (optionally) goes to a certain destination.

To do so, add the following fields in the **Options** shape data field next to the "HighlightStyle" option, using a pipe character ("\|") as a separator:

| Option | Description |
| ------ | ------*---- |
| HighlightTarget=<br>SourceDestination | This option must be added to indicate that the type of highlighting to be used is source-to-destination highlighting. |
| Source:\<x> | This option must be added to indicate where the highlighted path should start. \<x> can take the following values:<br>- *Element=*\[Element name or DMA ID/Element ID of the source element\]<br>- *Protocol=*\[Protocol name of the source element (not including the version)\]<br>- *Tag=*\[tag name\]<br>To use the *Tag* option, a shape elsewhere in the drawing will need to be configured with the shape data **Tag**, of which the value is set to the tag name. |
| Destination:\<y> | This is an optional field that can be added to indicate where the highlighted path should end. The highlighted path will then only include shapes and lines that run towards this destination.<br>\<y> is configured in the same manner as \<x>, allowing the same three kinds of values. |
| Priority:\<z> | This optional field allows you to give a highlight style priority over another style. \<z> is a number indicating the priority of the style. This way, multiple of these source-to-destination highlight styles can be defined with different priorities. If this field is not defined, the style will get the lowest priority. |
| Direction=<br>Forwards/<br>Backwards/<br>Both | This optional field (available from DataMiner 9.6.6 onwards) allows you to specify the direction in which DataMiner should crawl through the DCF network.<br>- Using "Direction=Backwards" together with "Source:Tag=MySource" will highlight all paths that lead to the "MySource" shape.<br>- Using "Direction=Forwards" will highlight all paths starting from the source shape.<br>Default direction: Forwards |

Examples:

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Element=231/88|Priority=3
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Protocol=MyDCFProtocol|Destination:Tag=Antenna|Priority=2
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Tag=MySource|Direction=Backwards
```

## Highlighting connections from a Connectivity.xml chain

In a Visio drawing that contains connected elements, it is possible to highlight DCF connectivity chains configured in *Connectivity.xml* files located in *C:\Skyline DataMiner\Connectivity* and its subfolders.

To do so:

1. Make sure the Visio drawing is uploaded to a service.

1. On the page where you want to visualize a connectivity chain, add a page-level shape data field of type **Options**, and set it to one of the following values:

    | Value | Description |
    | ----- | ----------- |
    | ActivePathHighlighting=Service | Any active path that has an entry point on this service will be highlighted. If several paths are available, you can choose which one to highlight. |
    | ActivePathHighlighting=*\[folder name\]* | The specified folder name must refer to a folder containing a *Connectivity.xml* file.<br>The connections configured in the connectivity chain in this *Connectivity.xml* file will be highlighted. |
    | ActivePathHighlighting=*\[GUID\]* | The specified GUID must be the GUID of a *Connectivity.xml* file. You can find the GUID for such a file by checking in the file.<br>The connections configured in the connectivity chain in this *Connectivity.xml* file will be highlighted. |

> [!NOTE]
>
> - Only connection properties that determine the connectivity path will be displayed. All other connection properties will be hidden.
> - When you use path highlighting in conjunction with connection property highlighting, connection property highlighting is reinstated when you click the background of the Visio drawing.

> [!TIP]
> See also: [Connectivity.xml files representing chains](xref:Connectivity_xml_files_representing_chains#connectivityxml-files-representing-chains)

## Disabling path highlighting when a connection line is clicked

By default, when you click a connection line between shapes, the path connected to that line is highlighted. From DataMiner 10.0.3 onwards, you can change this default behavior by adding a "SelectionHighlighting" option to the shape that represents the connection and setting it to "False".

Example:

| Shape data field | Value                       |
| ---------------- | --------------------------- |
| Connection       | Connectivity                |
| Options          | SelectionHighlighting=False |
