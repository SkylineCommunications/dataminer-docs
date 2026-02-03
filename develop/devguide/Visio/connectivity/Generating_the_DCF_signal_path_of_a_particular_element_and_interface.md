---
uid: Generating_the_DCF_signal_path_of_a_particular_element_and_interface
---

# Generating the DCF signal path of a particular element and interface

You can configure a Visio drawing to show the DCF signal path of a certain element and interface.

To do so, define the following shapes in Visio:

- A **Connection** shape, configured as described in [Automatically displaying external and internal connections](xref:Automatically_displaying_external_and_internal_connections).

  A **Filter** shape data field can be added to this shape, which is then taken into account for the creation of the signal path.

  Example:

  | Shape data field | Value |
  |------------------|-------|
  | Connection       | `Connectivity` |
  | Filter           | `<A>-A\|Connection\|Property:ServiceID\|Regex=[property:Service ID]` |

- A parent shape, representing the area in which the signal path will be drawn. This parent shape will not be displayed in Visio, but instead determines the possible size and position of the signal path.

  For more information on the shape data you should configure for this shape, see [Configuration of the signal path shape](#configuration-of-the-signal-path-shape).

- Placeholder shapes, representing the different possible elements in the signal path. These are child shapes within the signal path parent shape. These child shapes will be converted into element shapes and placed in the correct position of the signal path where required.

  For more information on the shape data you should configure for these shapes, see [Configuration of the placeholder shapes](#configuration-of-the-placeholder-shapes).

- Within each placeholder shape, child shapes representing its interfaces. Though these are not needed for other DCF functionality in Visio, in this case such interface child shapes are required within the placeholder shapes, because the signal path can have different element shapes with different interfaces, all automatically assigned within the same Visual Overview.

  To make sure that the signal path itself can determine which interfaces should be assigned to which element shape, we suggest setting the **Interface** shape data for these shapes to one of the following values:

  - *\[Auto\]\|Input*

  - *\[Auto\]\|InputOutput*

  - *\[Auto\]\|Output*

- Optional additional child shapes in the placeholder shape, for example to display the element name of the shape. For the latter, a child shape should be added with shape data **Element** set to "\*" and shape data **Info** set to "Name".

## Configuration of the signal path shape

The parent shape can contain the following shape data:

| Shape data | Description |
|------------|--------------------------|
| SignalPath | Specify this shape data field to indicate that the shape is the container shape for a signal path.<br> Fill in one of the following values for this shape data:<br> - *Forwards*<br> - *Backwards*<br> - *Both*<br> The value determines in what direction from the starting point the signal path logic will search. For example, if you specify *Forwards* and the starting point is an output, the next hop will either be the input of another element or an inout interface. |
| Element    | Specify this shape data field to determine the element from which the signal path starts. |
| Interface  | Specify this shape data field to determine the interface from which the signal path starts. The value for the shape data must be the exact ID or name of the DCF interface, or a variable referring to the exact ID or name. |
| Filter     | In this optional shape data field, you can define a service filter, by specifying a value with the format *ServiceScope=x* where x is a service name or service ID. Only elements that are in this service will be displayed. |
| Options    | In this optional shape data field, you can specify the following options, separated from each other with pipe (“\|”) characters, to determine how the signal path is displayed:<br> - **MaxHops=x**, where x is the maximum number of hops displayed (not counting the first shape). For example, if there is only enough room in your signal path container for 3 columns, specify *MaxHops=2*. The default value is 5.<br> - **MaxShapes=x**, where x is the maximum number of parent element shapes displayed within a single column or hop. For example, if there is room to display many shapes in one column, you could specify *MaxShapes=10*. The default value is 3. |

### Configuration of the placeholder shapes

A placeholder shape can have any shape data a normal parent element shape would have, except for the element shape data itself, which is instead determined by the signal path.

In addition, it can also have the following shape data:

| Shape data | Description |
|------------|---------------------------|
| Protocol   | In this (required) shape data field, specify which protocol and version the element in the signal path should have. For example, for the protocol “Generic Matrix 8x8” with version “1.0.0.3DCF”, specify *Generic Matrix 8x8:1.0.0.3DCF*.<br> To create a default placeholder shape, set the value to *Default*. Ideally, every signal path shape should contain a default placeholder child shape. |
| Options    | Numerous options available for normal element shapes can be specified in this shape data field. However, in addition, the following option can be used:<br> - **NoDuplicate**: When this option is specified, the shape will not be duplicated in different hops. This means that if, for example, a signal path goes from Element A to Element B and back to Element A, the shape for Element A is not recreated for hop 2. Instead the connection from the output of Element B loops back to the initial hop. If this option is not specified, there can be multiple shapes for the same element in different hops. |
